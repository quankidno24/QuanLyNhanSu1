using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai1_QLNS
{
    public partial class FormHuongDan : Form
    {
        public FormHuongDan()
        {
            InitializeComponent();
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string str = treeView1.SelectedNode.Text;
            if (str == "Huong dan 1")
            {
                webBrowser1.Navigate(@"D:\Visual Studio 2015\Projects\smart_store\index.html");
            }
        }
    }
}
