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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkcorrect() == true)
            {
                DialogResult = DialogResult.OK;
            }
            else MessageBox.Show("Ошибка ввода!");
        }
        private bool checkcorrect()
        {
            bool ch=true;
            try
            {
                var num = textBox1.Text;
                if (num[0] != '8' || num.Length >11 ) return ch == false;
                var problem =textBox2.Text;
                var date = textBox3.Text;

                if (problem.Length > 30)
                {
                    ch = false;
                }
                for (var i = 0; i < problem.Length; i++)
                {
                    if ((problem[i] < 'А'))
                    {
                        if ((problem[i] == '!') || (problem[i] == ',') || (problem[i] == '.') || (problem[i] == ' '))
                        {
                            ch = true;
                        }
                        else return ch == false;
                    }
                }
                if (!date.Contains(".")) return ch = false;
                if (date.Contains("31.2")|| date.Contains("30.2")) return ch = false;
                string[] s = date.Split('.');
                if (s.Length!=3) return ch = false;
                if (int.Parse(s[0])<1 || int.Parse(s[0]) > 31 || int.Parse(s[1])<0 || int.Parse(s[1])>12 || int.Parse(s[2])<2007 || int.Parse(s[2])>2030)
                {
                    return ch = false;
                }
                return ch;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка ввода!");
                return false;
            }
        }
        public request NewRequest()
        {
            if (checkcorrect())
            {
                var date = textBox3.Text;
                string[] s = date.Split('.');
                request a = new request(new Date(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2])), textBox1.Text, textBox2.Text);
                return a;
            }
            else return null;
        }
    }
}
