using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using smoscripter;
using System.Data.SqlClient;
namespace HXG.SMO
{
    public partial class createscript : Form
    {
        //成员变量-全局变量
        ServerConnection conn;
        Server svr;
        Database db;

        StringCollection strColl;
        StringCollection reftables = new StringCollection();
        ScriptingOptions scpopt = new ScriptingOptions();

        string serverstr = "";
        string userstr = "";
        string pwdstr = "";
        StringBuilder stroutput = new StringBuilder();

        public createscript()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetServerList();
            txtSaveDir.Text = Application.StartupPath;
        }

        private void ok_Click(object sender, EventArgs e)
        {
            output.Text = "";
            output.Enabled = false;
            reftables.Clear();
            try
            {
                //连接服务器
                if (svr == null)
                    connect();
                DateTime start = DateTime.Now;
                scriptoption();

                //脚本页头
                scripthead();

                //脚本主体
                scriptall();

                //脚本页脚
                scripttail(start);

                output.Enabled = true;

            }
            //异常报告
            catch (Exception err)
            {
                MessageBox.Show("错误:" + err.Message);
            }

        }

        private void scripthead()
        {
            //脚本说明
            stroutput = new StringBuilder();
            stroutput.AppendLine();
            stroutput.AppendLine("--该脚本由SMO对象程序生成");
            stroutput.AppendLine("--开始时间@" + DateTime.Now);
            stroutput.AppendLine("--不要急，慢慢等待奥.........");
            stroutput.AppendLine();
            output.AppendText(stroutput.ToString());
            stroutput = new StringBuilder();
        }

        private void scripttail(DateTime start)
        {
            //脚本结束，打开另存对话框
            stroutput = new StringBuilder();
            btnCopyDB.Enabled = true;
            stroutput.AppendLine("--恭喜，成功完成脚本编写！");
            stroutput.AppendLine("--完成时间@" + DateTime.Now);
            stroutput.AppendLine("--耗时：" + DateTime.Now.Subtract(start).TotalSeconds.ToString());
            stroutput.AppendLine();
            output.AppendText(stroutput.ToString());
            stroutput = new StringBuilder();
        }
        private void scriptoption()
        {
            //配置脚本通用选项
            if (isDrop.Checked)
            {
                scpopt.ContinueScriptingOnError = true;
                scpopt.IncludeIfNotExists = true;
                scpopt.NoCollation = true;

                scpopt.ScriptDrops = true;
                scpopt.IncludeIfNotExists = true;
                scpopt.ContinueScriptingOnError = true;
                scpopt.DriAllConstraints = false;
                scpopt.WithDependencies = false;
                scpopt.DriForeignKeys = false;
                scpopt.DriPrimaryKey = false;
                scpopt.DriDefaults = false;
                scpopt.DriChecks = false;
                scpopt.DriUniqueKeys = false;
                scpopt.Triggers = false;
                scpopt.Indexes = false;
                scpopt.ExtendedProperties = false;
            }
            else
            {
                scpopt.ContinueScriptingOnError = true;
                scpopt.IncludeIfNotExists = true;
                scpopt.NoCollation = true;

                scpopt.ScriptDrops = false;
                scpopt.ContinueScriptingOnError = true;
                //scpopt.DriAllConstraints = true;
                scpopt.WithDependencies = false;
                scpopt.DriForeignKeys = true;
                scpopt.DriPrimaryKey = true;
                scpopt.DriDefaults = true;
                scpopt.DriChecks = true;
                scpopt.DriUniqueKeys = true;
                scpopt.Triggers = true;
                scpopt.ExtendedProperties = true;
                scpopt.NoIdentities = false;

            }

            //是否生成索引
            if (isIndex.Checked)
                scpopt.Indexes = true;
            else
                scpopt.Indexes = false;
        }
        private void scriptall()
        {
            stroutput = new StringBuilder();

            //生成表脚本
            #region 生成表脚本
            output.AppendText("\r\n");
            output.AppendText("--以下为表对象脚本\r\n");
            output.AppendText("\r\n");

            foreach (Table tb in db.Tables)
            {
                if (!tb.IsSystemObject && !inreftables(tb.Name, reftables))
                {
                    scripttable(tb);
                }
            }
            output.AppendText("\r\n");
            output.AppendText("--以上为表对象脚本\r\n");
            output.AppendText("\r\n");
            #endregion
            #region 生成存储过程脚本



            output.AppendText("\r\n");
            output.AppendText("--以下为存储过程对象脚本\r\n");
            output.AppendText("\r\n");

            foreach (StoredProcedure proc in db.StoredProcedures)
            {
                if (!proc.IsSystemObject)
                {
                    stroutput = new StringBuilder();

                    stroutput.AppendLine();
                    stroutput.AppendLine("--存储过程[" + proc.Name + "]脚本");

                    if (!proc.IsEncrypted)
                    {

                        strColl = proc.Script(scpopt);

                        foreach (String str in strColl)
                        {

                            stroutput.AppendLine(str);
                            stroutput.AppendLine("GO");
                        }
                    }
                    else
                    {
                        stroutput.AppendLine();
                        stroutput.AppendLine("--存储过程被加密");
                        stroutput.AppendLine();
                    }
                    output.AppendText(stroutput.ToString());
                    stroutput = new StringBuilder();

                }
            }
            output.AppendText("\r\n");
            output.AppendText("--以上为存储过程对象脚本\r\n");
            output.AppendText("\r\n");
            #endregion

            #region 生成函数过程脚本
            output.AppendText("\r\n");
            output.AppendText("--以下为函数对象脚本\r\n");
            output.AppendText("\r\n");
            foreach (UserDefinedFunction func in db.UserDefinedFunctions)
            {
                if (!func.IsSystemObject)
                {
                    stroutput = new StringBuilder();

                    stroutput.AppendLine();
                    stroutput.AppendLine("--函数[" + func.Name + "]脚本");

                    if (!func.IsEncrypted)
                    {
                        strColl = func.Script(scpopt);

                        foreach (String str in strColl)
                        {
                            stroutput.AppendLine(str);
                            stroutput.AppendLine("GO");
                        }
                    }
                    else
                    {
                        stroutput.AppendLine("--函数被加密");
                        stroutput.AppendLine();
                    }
                    output.AppendText(stroutput.ToString());
                    SaveFile(stroutput.ToString(), txtSaveDir.Text + "\\" + svr.Name.Replace(",7001", string.Empty) + "_" + db.Name + ".fuc");
                    stroutput = new StringBuilder();
                }
            }
            output.AppendText("\r\n");
            output.AppendText("--以上为函数对象脚本\r\n");
            output.AppendText("\r\n");
            #endregion

            #region 生成视图过程脚本

            output.AppendText("\r\n");
            output.AppendText("--以下为视图对象脚本\r\n");
            output.AppendText("\r\n");
            foreach (Microsoft.SqlServer.Management.Smo.View viw in db.Views)
            {
                if (!viw.IsSystemObject)
                {
                    stroutput = new StringBuilder();
                    stroutput.AppendLine();
                    stroutput.AppendLine("--视图[" + viw.Name + "]脚本");

                    if (!viw.IsEncrypted)
                    {
                        strColl = viw.Script(scpopt);

                        foreach (String str in strColl)
                        {
                            stroutput.AppendLine(str);
                            stroutput.AppendLine("GO");
                        }
                    }
                    else
                    {
                        stroutput.AppendLine("--视图被加密");
                        stroutput.AppendLine();
                    }
                    output.AppendText(stroutput.ToString());
                    stroutput = new StringBuilder();
                }
            }
            output.AppendText("\r\n");
            output.AppendText("--以上为视图对象脚本\r\n");
            output.AppendText("\r\n");
            #endregion
            #region 安全性

            //用户
            output.AppendText("\r\n");
            output.AppendText("--以下为数据库用户对象脚本\r\n");
            output.AppendText("\r\n");
            foreach (User user in db.Users)
            {
                if (!user.IsSystemObject)
                {
                    stroutput = new StringBuilder();

                    stroutput.AppendLine();
                    stroutput.AppendLine("--数据库用户[" + user.Name + "]脚本");

                    foreach (string str in user.Script(scpopt))
                    {
                        stroutput.AppendLine(str);
                        stroutput.AppendLine("GO");
                    }
                    foreach (string str in user.EnumRoles())
                    {
                        stroutput.AppendLine("EXEC sp_addrolemember N'" + str + "', N'" + user.Name + "'");
                        stroutput.AppendLine("GO");
                    }
                    output.AppendText(stroutput.ToString());
                    SaveFile(stroutput.ToString(), txtSaveDir.Text + "\\" + svr.Name.Replace(",7001", string.Empty) + "_" + db.Name + ".usr");
                    stroutput = new StringBuilder();
                }
            }
            output.AppendText("\r\n");
            output.AppendText("--以上为数据库用户对象脚本\r\n");
            output.AppendText("\r\n");
            //角色
            output.AppendText("\r\n");
            output.AppendText("--以下为数据库角色对象脚本\r\n");
            output.AppendText("\r\n");
            foreach (DatabaseRole role in db.Roles)
            {
                if (!role.IsFixedRole)
                {
                    stroutput = new StringBuilder();

                    stroutput.AppendLine();
                    stroutput.AppendLine("--数据库角色[" + role.Name + "]脚本");

                    foreach (string str in role.Script(scpopt))
                    {
                        stroutput.AppendLine(str);
                        stroutput.AppendLine("GO");
                    }
                    output.AppendText(stroutput.ToString());
                    SaveFile(stroutput.ToString(), txtSaveDir.Text + "\\" + svr.Name.Replace(",7001", string.Empty) + "_" + db.Name + ".rol");
                    stroutput = new StringBuilder();
                }
            }
            output.AppendText("\r\n");
            output.AppendText("--以上为数据库角色对象脚本\r\n");
            output.AppendText("\r\n");

            #endregion

        }

        private Boolean inreftables(string s, StringCollection sc)
        {
            foreach (string a in sc)
            {
                if (s == a)
                    return true;
            }
            return false;

        }

        //生成表脚本的方法
        private void scripttable(Table tb)
        {
            string ids;
            Table table = new Table();
            if (reftables.Contains(tb.Name))
                return;

            //对外键表编写脚本
            foreach (ForeignKey fk in tb.ForeignKeys)
            {
                //迭代算法

                foreach (Table temptb in db.Tables)
                {
                    if (temptb.Name == fk.ReferencedTable)
                    {
                        table = temptb;
                        break;
                    }
                }

                if (table.Name != tb.Name)
                {
                    scripttable(table);
                }
            }

            //编写本表的的脚本
            stroutput = new StringBuilder();

            stroutput.AppendLine();
            stroutput.AppendLine("--表[" + tb.Name + "]脚本");

            strColl = tb.Script(scpopt);

            foreach (String str in strColl)
            {
                //此处修正smo的bug
                if (str.Contains("ADD  DEFAULT") && str.Contains("') AND type = 'D'"))
                {
                    ids = str.Substring(str.IndexOf("OBJECT_ID(N'") + "OBJECT_ID(N'".Length, str.IndexOf("') AND type = 'D'") - str.IndexOf("OBJECT_ID(N'") - "OBJECT_ID(N'".Length);
                    stroutput.AppendLine(str.Insert(str.IndexOf("ADD  DEFAULT") + 4, "CONSTRAINT " + ids));
                }
                else
                    stroutput.AppendLine(str);

                stroutput.AppendLine("GO");
            }
            output.AppendText(stroutput.ToString());
            SaveFile(stroutput.ToString(), txtSaveDir.Text + "\\" + svr.Name.Replace(",7001", string.Empty) + "_" + db.Name + ".tab");
            stroutput = new StringBuilder();

            //将编写完的表写入已完成表集合内
            reftables.Add(tb.Name);

        }
        #region 数据库连接
        private void connect()
        {
            serverstr = instance.Text;
            userstr = user.Text;
            pwdstr = pwd.Text;

            try
            {
                if (isnt.Checked)
                    conn = new ServerConnection(serverstr);
                else
                    conn = new ServerConnection(serverstr, userstr, pwdstr);

                svr = new Server(conn);

            }
            catch (Exception err)
            {
                MessageBox.Show("错误:" + err.Message);
            }
        }
        private void disconnect()
        {
            ok.Enabled = false;
            dblist.Items.Clear();
            dblist.Text = null;
            db = null;
            svr = null;
            try
            {
                conn.Disconnect();
            }
            catch
            {
                conn = null;
            }
            finally
            {
                conn = null;
            }
        }
        #endregion

        private void instance_TextChanged(object sender, EventArgs e)
        {
            disconnect();
        }

        #region 用户验证
        private void user_TextChanged(object sender, EventArgs e)
        {
            disconnect();
        }
        private void pwd_TextChanged(object sender, EventArgs e)
        {
            disconnect();
        }
        private void nt_CheckedChanged(object sender, EventArgs e)
        {

            if (isnt.Checked)
            {
                user.Enabled = false;
                pwd.Enabled = false;
            }
            else
            {
                user.Enabled = true;
                pwd.Enabled = true;
            }
            disconnect();
        }
        #endregion

        private void btnLink_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime start = DateTime.Now;
                if (svr == null)
                    connect();
                DateTime end = DateTime.Now;
                // MessageBox.Show(end.Subtract(start).TotalSeconds.ToString());
                start = DateTime.Now;
                if (dblist.Items.Count < 1)
                {
                    foreach (Database db in svr.Databases)
                    {
                        if (Regex.Match(db.Name, @"20([1-9][0-9])(0[1-9]|1[0-2])$").Success)
                        {
                            // && db.IsAccessible
                            dblist.Items.Add(db);
                        }
                    }
                }

                dblist.DroppedDown = true;
                end = DateTime.Now;
                //MessageBox.Show(end.Subtract(start).TotalSeconds.ToString());
            }
            catch (Exception err)
            {
                MessageBox.Show("错误:" + err.Message);
            }
        }
        private void btnServerState_Click(object sender, EventArgs e)
        {
            if (svr == null)
            {
                MessageBox.Show("数据库未连接");
                return;
            }
            DataSet ds = svr.Databases["master"].ExecuteWithResults("exec master..xp_fixeddrives");
            MsgShow show = new MsgShow();
            show.DataSource = ds;
            show.ShowDialog();
        }
        private void dblist_SelectedIndexChanged(object sender, EventArgs e)
        {

            db = (Database)dblist.SelectedItem;
            txtDbName.Text = db.Name;
            if (db != null)
            {
                ok.Enabled = true;
            }
            else
            {
                ok.Enabled = false;
            }
        }

        private void savefile_Click(object sender, EventArgs e)
        {
            StreamWriter filewrite;
            DialogResult result;
            savefiledialog.Filter = "SQL脚本(*.sql)|*.sql|所有文件|(*.*)";
            result = savefiledialog.ShowDialog();
            if (result.ToString() == "OK")
            {
                filewrite = new StreamWriter(savefiledialog.FileName, false);
                filewrite.Write(output.Text.ToString());
                filewrite.Close();
            }

        }

        private void isDrop_CheckedChanged(object sender, EventArgs e)
        {
            if (isDrop.Checked)
            {
                isIndex.Enabled = false;
                isIndex.Checked = false;
            }

        }

        private void savefiledialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            folderBrowserDialog1.ShowDialog();
            txtSaveDir.Text = folderBrowserDialog1.SelectedPath;
            //savefiledialog.ShowDialog();
        }

        private void SaveFile(string input, string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.Write(input);
                }
            }
        }
        private string ReadFile(string filename)
        {
            if (!File.Exists(filename))
                return string.Empty;
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        #region 数据库创建
        private void ExcuteSQL(string sqlStr, Database current)
        {
            if (svr == null)
            {
                MessageBox.Show("链接失败，请重新登录！");
                return;
            }
            current.ExecuteNonQuery(sqlStr, ExecutionTypes.Default);
        }
        private void btnCopyDB_Click(object sender, EventArgs e)
        {
            if (svr.Databases.Contains(txtDbName.Text))
            {
                MessageBox.Show("数据库[" + txtDbName.Text + "]已经存在");
                return;
            }
            Database newDb = new Database(svr, txtDbName.Text);
            newDb.Create();
            //文件增长方式
            newDb.FileGroups[newDb.DefaultFileGroup].Files[0].GrowthType = FileGrowthType.KB;
            newDb.FileGroups[newDb.DefaultFileGroup].Files[0].Growth = Int32.Parse(txtDatafileSize.Text.Trim()) * 1024;

            newDb.LogFiles[0].GrowthType = FileGrowthType.KB;
            newDb.LogFiles[0].Growth = Int32.Parse(txtLogfileSize.Text.Trim()) * 1024;
            //还原模式
            newDb.RecoveryModel = RecoveryModel.Simple;
            newDb.Alter();
            try
            {
                ExcuteSQL(output.Text, newDb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show(string.Format("数据库[{0}]创建成功", newDb.Name));
        }
        #endregion

        #region
        private void GetServerList()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Config.xml");
            XmlNode cons = doc.SelectSingleNode("connections");
            XmlNodeList servers = cons.SelectNodes("server");
            foreach (XmlNode server in servers)
            {
                TreeNode newnode = new TreeNode();
                newnode.Text = server.Attributes["name"].Value;
                newnode.Name = server.Attributes["name"].Value;
                NetbarServer newserv = new NetbarServer(server["ip"].InnerText, server["un"].InnerText, server["pw"].InnerText);
                newnode.Tag = newserv;
                tvServers.Nodes.Add(newnode);
            }
        }
        private void GetSubServer(TreeNode node)
        {
            NetbarServer dbser = (NetbarServer)node.Tag;
            using (SqlConnection con = new SqlConnection(string.Format("server={0};database=master;uid={1};pwd={2};", dbser.IP, dbser.UN, dbser.PW)))
            {
                using (SqlCommand cmd = new SqlCommand("select * from netbar..s_center_ip where flag=1", con))
                {
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        string sname;
                        while (sdr.Read())
                        {
                            sname = dbser.ServerName(sdr.GetValue(0).ToString());
                            if (!sname.Equals(string.Empty))
                            {
                                TreeNode newnode = new TreeNode();
                                newnode.Text = sname;
                                newnode.Name = sdr.GetValue(0).ToString();
                                NetbarServer subserv = new NetbarServer(sdr.GetValue(1).ToString(), "sa", dbser.PW);
                                newnode.Tag = subserv;
                                tvSubServers.Nodes.Add(newnode);
                            }

                        }
                    }
                }
            }
        }
        private void tvServers_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (tvSubServers.Nodes.Count > 0)
                tvSubServers.Nodes.Clear();
            GetSubServer(e.Node);

        }
        private void tvSubServers_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            NetbarServer serv = (NetbarServer)e.Node.Tag;
            this.Text = string.Format("{0}-[{1}]", e.Node.Text,serv.IP);
            instance.Text = serv.IP;
            user.Text = serv.UN;
            pwd.Text = serv.PW;
        }
        #endregion
        #region 控件状态变化事件
        private void createscript_Resize(object sender, EventArgs e)
        {
            output.Size = new System.Drawing.Size(this.Size.Width - 40, this.Size.Height - 200);
        }
        #endregion
        #region 排序
        /// <summary>
        /// 位图排序，根据数组索引标志位排序
        /// 不支持重复数据
        /// </summary>
        /// <param name="arr"></param>
        private void BitmapSort(Int32[] arr)
        {
            //get the max value and min value of the array
            Int32 max = arr[0];
            Int32 min = arr[0];
            foreach (Int32 i in arr)
            {
                if (max < i)
                    max = i;
                if (min > i)
                    min = i;
            }
            //declare a new array,the length is max-min of the old array
            //遍历旧数组，并在新数组对应索引位上 赋值为1，标识该索引位上有值。
            Int32[] newArr = new Int32[max - min + 1];
            foreach (Int32 i in arr)
            {
                newArr[i - min] = 1;
            }
            //遍历新数组（从低位到高位），根据数组上有值（1），判定旧数组存在该值，而且是较小的。
            for (Int32 i = 0; i < newArr.Length; i++)
            {
                if (newArr[i] == 1)
                {
                    output.AppendText((min + i).ToString());
                    output.AppendText(",");
                }
            }
        }
        #endregion
    }
    public class NetbarServer
    {
        private string _ip;
        public string IP { get { return _ip; } }

        private string _un;
        public string UN { get { return _un; } }

        private string _pw;
        public string PW { get { return _pw; } }

        public NetbarServer(string ip, string un, string pw)
        {
            _ip = ip;
            _un = un;
            _pw = pw;
        }

        public string ServerName(string enName)
        {

            string retname = enName;
            switch (enName.ToLower())
            {
                case "netbarhis":
                    retname = "实名";
                    break;
                case "qqmsghis":
                    retname = "聊天";
                    break;
                case "posthis":
                    retname = "帖子";
                    break;
                case "lphis":
                    retname = "照片";
                    break;
                case "dummyhisip":
                    retname = "虚拟";
                    break;
                case "netbarurlhis":
                    retname = "URL";
                    break;
                default:
                    retname = string.Empty;
                    break;
            }
            return retname;
        }
    }

}
