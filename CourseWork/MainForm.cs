using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 addForm = new Form1();
            DialogResult dialogResult = addForm.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                addForm.Show();
            }
        }
    }
}
