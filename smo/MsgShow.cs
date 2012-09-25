using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace smoscripter
{
    public partial class MsgShow : Form
    {
        public MsgShow()
        {
            InitializeComponent();
        }
        public DataSet DataSource;
        private void MsgShow_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = DataSource.Tables[0];            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex==1) 
            {
                double dsize;
                if (double.TryParse(e.Value.ToString(), out dsize))
                {
                    if (dsize < 100) 
                    {
                        e.CellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }
    }
}
