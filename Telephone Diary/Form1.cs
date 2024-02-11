using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Diary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                phoneBookBindingSource.Filter = $"FullName like '*{txtSearch.Text}' or Mobile='{txtSearch.Text}'";
;        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists($"{Application.StartupPath}/data.dat"))
                database.ReadXml($"{Application.StartupPath}/data.dat");
        }

        private void phoneBookBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            phoneBookBindingSource.EndEdit();
            database.WriteXml($"{Application.StartupPath}/data.dat");
            MessageBox.Show("The data has been successfully saved","Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
