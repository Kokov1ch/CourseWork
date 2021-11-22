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
    public partial class Form7 : Form
    {
        public Form7(ref RedBlackTree<Date, ProcessedReq> tree)
        {
            copy = tree;
            InitializeComponent();
        }
        RedBlackTree<Date, ProcessedReq> copy;
        private bool checkcorrect()
        {
            bool ch = true;
            try
            {
                var date = textBox1.Text;
                var problem = textBox2.Text;
                var num = textBox5.Text;
                var cust = textBox3.Text;
                var work = textBox4.Text;
                if (num[0] != '8' || num.Length > 11) return ch == false;
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
                for (var i = 0; i < work.Length; i++)
                {
                    if ((work[i] < 'А'))
                    {
                        if ((work[i] == '.') || (work[i] == ' '))
                        {
                            ch = true;
                        }
                        else return ch == false;
                    }
                }
                if (!date.Contains(".")) return ch = false;
                if (date.Contains("31.2") || date.Contains("30.2")) return false;
                string[] s = date.Split('.');
                if (s.Length != 3) return ch = false;
                if (int.Parse(s[0]) < 1 || int.Parse(s[0]) > 31 || int.Parse(s[1]) < 0 || int.Parse(s[1]) > 12 || int.Parse(s[2]) < 2007 || int.Parse(s[2]) > 2030)
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
        public ProcessedReq NewProcRequest()
        {
            try
            {
                var date = textBox1.Text;
                string[] s = date.Split('.');
                Date Key = new Date(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]));
                if (copy.TryFind(Key, out var outp))
                {
                    foreach (var it in outp)
                    {
                        if (it.num == textBox5.Text && it.problem == textBox2.Text && it.worker == textBox4.Text && it.customer == textBox3.Text)
                        {
                            return it;
                        }
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkcorrect())
            {
                DialogResult = DialogResult.OK;
                Hide();
            }
            else MessageBox.Show("Ошибка ввода!");
        }
    }
}
