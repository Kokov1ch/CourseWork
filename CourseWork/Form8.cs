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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        public bool checkCorrect()
        {
            var From = textBox2.Text;
            var To = textBox1.Text;
            try
            {
                if (!From.Contains(".")) return false;
                if (From.Contains("31.2") || From.Contains("30.2")) return false;
                string[] s = From.Split('.');
                if (s.Length != 3) return false;
                if (int.Parse(s[0]) < 1 || int.Parse(s[0]) > 31 || int.Parse(s[1]) < 0 || int.Parse(s[1]) > 12 || int.Parse(s[2]) < 2007 || int.Parse(s[2]) > 2030)
                {
                    return false;
                }
                if (!To.Contains(".")) return false;
                if (To.Contains("31.2") || To.Contains("30.2")) return false;
                string[] s1 = To.Split('.');
                if (s.Length != 3) return false;
                if (int.Parse(s1[0]) < 1 || int.Parse(s1[0]) > 31 || int.Parse(s1[1]) < 0 || int.Parse(s1[1]) > 12 || int.Parse(s1[2]) < 2007 || int.Parse(s1[2]) > 2030)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка ввода!");
                return false;
            }
        }
        public Date Max() {
            var To = textBox1.Text;
            string[] s = To.Split('.');
            return new Date(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]));
        }
        public Date Min() {
            var From = textBox2.Text;
            string[] s = From.Split('.');
            return new Date(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkCorrect())
            {
                DialogResult = DialogResult.OK;
                Hide();
            }
            else MessageBox.Show("Ошибка ввода!");
        }
    }
}
