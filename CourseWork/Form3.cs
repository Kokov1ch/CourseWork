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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void GetKey(ref int dd, ref int mm, ref int yy, ref string num,ref string problem)
        {
            try
            {
                var numb = textBox1.Text;
                var date = textBox2.Text;
                var problema = textBox3.Text;
                string[] s = date.Split('.');
                dd = int.Parse(s[0]);
                mm = int.Parse(s[1]);
                yy = int.Parse(s[2]);
                num = numb;
                problem = problema;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка ввода!");
            }
        }
        public bool checkcorrect()
        {
            try
            {
                var num = textBox1.Text;
                var date = textBox2.Text;
                var problem = textBox3.Text;
                if (num[0] != '8' || num.Length > 11) return false;
                if (!date.Contains(".")) return false;
                if (date.Contains("31.2") || date.Contains("30.2")) return false;
                string[] s = date.Split('.');
                if (s.Length != 3) return false;
                if (int.Parse(s[0]) < 1 || int.Parse(s[0]) > 31 || int.Parse(s[1]) < 0 || int.Parse(s[1]) > 12 || int.Parse(s[2]) < 2007 || int.Parse(s[2]) > 2030)
                {
                    return  false;
                }
                if (problem.Length > 30)
                {
                    return false;
                }
                for (var i = 0; i < problem.Length; i++)
                {
                    if ((problem[i] < 'А'))
                    {
                        if ((problem[i] == '!') || (problem[i] == ',') || (problem[i] == '.') || (problem[i] == ' '))
                        {
                            return  true;
                        }
                        else return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка ввода!");
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkcorrect())
            {
                DialogResult = DialogResult.OK;
                Hide();
            }
            else
            {
                MessageBox.Show("Ошибка ввода!");
            }
        }

    }
}
