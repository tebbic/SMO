namespace HXG.SMO
{
    partial class createscript
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.output = new System.Windows.Forms.TextBox();
            this.ok = new System.Windows.Forms.Button();
            this.user = new System.Windows.Forms.TextBox();
            this.pwd = new System.Windows.Forms.TextBox();
            this.instance = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLink = new System.Windows.Forms.Button();
            this.issql = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.isnt = new System.Windows.Forms.RadioButton();
            this.dblist = new System.Windows.Forms.ComboBox();
            this.savefiledialog = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtSaveDir = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCopyDB = new System.Windows.Forms.Button();
            this.isIndex = new System.Windows.Forms.CheckBox();
            this.isDrop = new System.Windows.Forms.CheckBox();
            this.txtDbName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tvServers = new System.Windows.Forms.TreeView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDatafileSize = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLogfileSize = new System.Windows.Forms.TextBox();
            this.btnServerState = new System.Windows.Forms.Button();
            this.tvSubServers = new System.Windows.Forms.TreeView();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // output
            // 
            this.output.BackColor = System.Drawing.SystemColors.Window;
            this.output.HideSelection = false;
            this.output.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.output.Location = new System.Drawing.Point(12, 148);
            this.output.MaxLength = 999990000;
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.output.Size = new System.Drawing.Size(1158, 228);
            this.output.TabIndex = 0;
            this.output.TabStop = false;
            this.output.WordWrap = false;
            // 
            // ok
            // 
            this.ok.Enabled = false;
            this.ok.Location = new System.Drawing.Point(696, 18);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 24);
            this.ok.TabIndex = 1;
            this.ok.Text = "生成脚本";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // user
            // 
            this.user.Location = new System.Drawing.Point(53, 45);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(100, 21);
            this.user.TabIndex = 3;
            this.user.Text = "sa";
            this.user.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.user.TextChanged += new System.EventHandler(this.user_TextChanged);
            // 
            // pwd
            // 
            this.pwd.Location = new System.Drawing.Point(53, 72);
            this.pwd.Name = "pwd";
            this.pwd.PasswordChar = '*';
            this.pwd.Size = new System.Drawing.Size(100, 21);
            this.pwd.TabIndex = 4;
            this.pwd.Text = "CYWJr710";
            this.pwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pwd.TextChanged += new System.EventHandler(this.pwd_TextChanged);
            // 
            // instance
            // 
            this.instance.Location = new System.Drawing.Point(53, 18);
            this.instance.Name = "instance";
            this.instance.Size = new System.Drawing.Size(135, 21);
            this.instance.TabIndex = 5;
            this.instance.Text = "221.215.125.10,7001";
            this.instance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.instance.TextChanged += new System.EventHandler(this.instance_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "服务器";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "用户";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLink);
            this.groupBox1.Controls.Add(this.issql);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.isnt);
            this.groupBox1.Controls.Add(this.pwd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.instance);
            this.groupBox1.Controls.Add(this.user);
            this.groupBox1.Location = new System.Drawing.Point(405, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 105);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // btnLink
            // 
            this.btnLink.Location = new System.Drawing.Point(194, 18);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(44, 23);
            this.btnLink.TabIndex = 12;
            this.btnLink.Text = "链接";
            this.btnLink.UseVisualStyleBackColor = true;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // issql
            // 
            this.issql.AutoSize = true;
            this.issql.Checked = true;
            this.issql.Location = new System.Drawing.Point(167, 74);
            this.issql.Name = "issql";
            this.issql.Size = new System.Drawing.Size(65, 16);
            this.issql.TabIndex = 11;
            this.issql.TabStop = true;
            this.issql.Text = "SQL认证";
            this.issql.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "密码";
            // 
            // isnt
            // 
            this.isnt.AutoSize = true;
            this.isnt.Location = new System.Drawing.Point(167, 52);
            this.isnt.Name = "isnt";
            this.isnt.Size = new System.Drawing.Size(59, 16);
            this.isnt.TabIndex = 10;
            this.isnt.Text = "NT认证";
            this.isnt.UseVisualStyleBackColor = true;
            this.isnt.CheckedChanged += new System.EventHandler(this.nt_CheckedChanged);
            // 
            // dblist
            // 
            this.dblist.AllowDrop = true;
            this.dblist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dblist.FormattingEnabled = true;
            this.dblist.Location = new System.Drawing.Point(408, 122);
            this.dblist.MaxDropDownItems = 20;
            this.dblist.Name = "dblist";
            this.dblist.Size = new System.Drawing.Size(173, 20);
            this.dblist.TabIndex = 16;
            this.dblist.SelectedIndexChanged += new System.EventHandler(this.dblist_SelectedIndexChanged);
            // 
            // savefiledialog
            // 
            this.savefiledialog.FileOk += new System.ComponentModel.CancelEventHandler(this.savefiledialog_FileOk);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.ApplicationData;
            // 
            // txtSaveDir
            // 
            this.txtSaveDir.Location = new System.Drawing.Point(697, 120);
            this.txtSaveDir.Name = "txtSaveDir";
            this.txtSaveDir.Size = new System.Drawing.Size(189, 21);
            this.txtSaveDir.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(894, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCopyDB
            // 
            this.btnCopyDB.Enabled = false;
            this.btnCopyDB.Location = new System.Drawing.Point(958, 120);
            this.btnCopyDB.Name = "btnCopyDB";
            this.btnCopyDB.Size = new System.Drawing.Size(64, 23);
            this.btnCopyDB.TabIndex = 25;
            this.btnCopyDB.Text = "创建";
            this.btnCopyDB.UseVisualStyleBackColor = true;
            this.btnCopyDB.Click += new System.EventHandler(this.btnCopyDB_Click);
            // 
            // isIndex
            // 
            this.isIndex.AutoSize = true;
            this.isIndex.Checked = true;
            this.isIndex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isIndex.Location = new System.Drawing.Point(777, 62);
            this.isIndex.Name = "isIndex";
            this.isIndex.Size = new System.Drawing.Size(78, 16);
            this.isIndex.TabIndex = 1;
            this.isIndex.Text = "生成Index";
            this.isIndex.UseVisualStyleBackColor = true;
            // 
            // isDrop
            // 
            this.isDrop.AutoSize = true;
            this.isDrop.Location = new System.Drawing.Point(699, 62);
            this.isDrop.Name = "isDrop";
            this.isDrop.Size = new System.Drawing.Size(72, 16);
            this.isDrop.TabIndex = 0;
            this.isDrop.Text = "生成Drop";
            this.isDrop.UseVisualStyleBackColor = true;
            // 
            // txtDbName
            // 
            this.txtDbName.Location = new System.Drawing.Point(991, 48);
            this.txtDbName.Name = "txtDbName";
            this.txtDbName.Size = new System.Drawing.Size(159, 21);
            this.txtDbName.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(697, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "脚本保存路径";
            // 
            // tvServers
            // 
            this.tvServers.Location = new System.Drawing.Point(4, 14);
            this.tvServers.Name = "tvServers";
            this.tvServers.Size = new System.Drawing.Size(176, 122);
            this.tvServers.TabIndex = 29;
            this.tvServers.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvServers_NodeMouseDoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(956, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "名称";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(956, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 12);
            this.label6.TabIndex = 30;
            this.label6.Text = "根据下面脚本，创建类结构的数据库";
            // 
            // txtDatafileSize
            // 
            this.txtDatafileSize.Location = new System.Drawing.Point(1015, 86);
            this.txtDatafileSize.Name = "txtDatafileSize";
            this.txtDatafileSize.Size = new System.Drawing.Size(37, 21);
            this.txtDatafileSize.TabIndex = 31;
            this.txtDatafileSize.Text = "500";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(956, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 32;
            this.label7.Text = "文件大小";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1058, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 34;
            this.label8.Text = "日志大小";
            // 
            // txtLogfileSize
            // 
            this.txtLogfileSize.Location = new System.Drawing.Point(1113, 86);
            this.txtLogfileSize.Name = "txtLogfileSize";
            this.txtLogfileSize.Size = new System.Drawing.Size(37, 21);
            this.txtLogfileSize.TabIndex = 33;
            this.txtLogfileSize.Text = "100";
            // 
            // btnServerState
            // 
            this.btnServerState.Location = new System.Drawing.Point(589, 120);
            this.btnServerState.Name = "btnServerState";
            this.btnServerState.Size = new System.Drawing.Size(65, 23);
            this.btnServerState.TabIndex = 35;
            this.btnServerState.Text = "硬盘状态";
            this.btnServerState.UseVisualStyleBackColor = true;
            this.btnServerState.Click += new System.EventHandler(this.btnServerState_Click);
            // 
            // tvSubServers
            // 
            this.tvSubServers.Location = new System.Drawing.Point(202, 14);
            this.tvSubServers.Name = "tvSubServers";
            this.tvSubServers.Size = new System.Drawing.Size(176, 122);
            this.tvSubServers.TabIndex = 36;
            this.tvSubServers.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvSubServers_NodeMouseDoubleClick);
            // 
            // createscript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 393);
            this.Controls.Add(this.tvSubServers);
            this.Controls.Add(this.btnServerState);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtLogfileSize);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDatafileSize);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDbName);
            this.Controls.Add(this.isIndex);
            this.Controls.Add(this.btnCopyDB);
            this.Controls.Add(this.tvServers);
            this.Controls.Add(this.isDrop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSaveDir);
            this.Controls.Add(this.dblist);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.output);
            this.Name = "createscript";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "hellp";
            this.Text = "脚本生成器2.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.createscript_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.TextBox pwd;
        private System.Windows.Forms.TextBox instance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton isnt;
        private System.Windows.Forms.RadioButton issql;
        private System.Windows.Forms.ComboBox dblist;
        private System.Windows.Forms.SaveFileDialog savefiledialog;
        private System.Windows.Forms.Button btnLink;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtSaveDir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCopyDB;
        private System.Windows.Forms.CheckBox isDrop;
        private System.Windows.Forms.CheckBox isIndex;
        private System.Windows.Forms.TextBox txtDbName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView tvServers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDatafileSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLogfileSize;
        private System.Windows.Forms.Button btnServerState;
        private System.Windows.Forms.TreeView tvSubServers;
    }
}

