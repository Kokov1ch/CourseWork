using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CourseWork
{
    public partial class Form1 : Form
    {
        RedBlackTree<Date, ProcessedReq> tree = new RedBlackTree<Date, ProcessedReq>();
        List<ProcessedReq> list = new List<ProcessedReq>();
        List<request> reqlist = new List<request>();
        HashTableOA tab = new HashTableOA();
        public Form1()
        {
            InitializeComponent();
            Form MainForm = new MainForm();
            MainForm.Hide();
            tab.Clear();
            string path = @"C:\Users\avk41\source\repos\CourseWork\Requests.txt";
            var flag = true;
            try
            {
                StreamReader input = new StreamReader(path);
            try
            {
                var ch = true;
                dataGridView1.Rows.Clear();
                while (!input.EndOfStream)
                {
                    if (flag != false)
                    {
                        string s = input.ReadLine();
                        string[] subs = s.Split(' ');
                        if (!subs[subs.Length - 1].Contains('.'))
                        {
                            ch = false;
                        }
                        string[] dates = subs[subs.Length - 1].Split('.');
                        if (subs[0].ToCharArray()[0] != '8' || subs[0].ToCharArray().Length != 11)
                        {
                            ch = false;
                        }
                        var problem = subs[1].ToCharArray();
                        if (problem.Length > 30)
                        {
                            ch = false;
                        }
                        for (var i = 0; i < problem.Length; i++)
                        {
                            if ((problem[i] < 'А'))
                            {
                                if ((problem[i] != '!') && (problem[i] != ',') && (problem[i] != '.') && (problem[i] == ' ') && (problem[i] != '_'))
                                {
                                    ch = false;
                                }
                            }
                        }
                        if (dates.Length != 3)
                            ch = false;
                        if (int.Parse(dates[0]) < 1 || int.Parse(dates[0]) > 31 || int.Parse(dates[1]) < 0 || int.Parse(dates[1]) > 12 || int.Parse(dates[2]) < 2007 || int.Parse(dates[2]) > 2030)
                        {
                            ch = false;
                        }
                        if (ch != false)
                        {
                            request r = new request(new Date(int.Parse(dates[0]), int.Parse(dates[1]), int.Parse(dates[2])), subs[0], subs[1].Replace('_', ' '));
                            tab.Add(r);
                            reqlist.Add(r);
                        }
                        else
                        {
                            flag = false;
                            break;
                        }
                    }
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Ошибка входных данных!");
                    Application.Exit();
                }
            finally
            {
                input.Close();
            }
            foreach (var it in reqlist)
            {
                dataGridView1.Rows.Add(tab.Hash(it, 0), tab.Find(it), it.number, it.problem, it.Key.day.ToString() + "." + it.Key.month.ToString() + "." + it.Key.year.ToString());
            }
            //////////////////////
            tree.Clear();
            string path1 = @"C:\Users\avk41\source\repos\CourseWork\ProcRequests.txt";
                StreamReader input1 = new StreamReader(path1);
            try
            {
                var ch1 = true;
                dataGridView2.Rows.Clear();
                while (!input1.EndOfStream)
                {
                    string s1 = input1.ReadLine();
                    string[] subs1 = s1.Split(' ');
                    string[] dates1 = subs1[0].Split('.');
                    if (!subs1[0].Contains('.'))
                    {
                        ch1 = false;
                    }
                    if (subs1[subs1.Length - 1].ToCharArray()[0] != '8' || subs1[subs1.Length - 1].ToCharArray().Length != 11)
                    {
                        ch1 = false;
                    }
                    var problem1 = subs1[1].ToCharArray();
                    var worker = subs1[3].ToCharArray();
                    var customer = subs1[2].ToCharArray();
                    if (problem1.Length > 30)
                    {
                        ch1 = false;
                    }
                    for (var i = 0; i < problem1.Length; i++)
                    {
                        if ((problem1[i] < 'А'))
                        {
                            if ((problem1[i] != '!') && (problem1[i] != ',') && (problem1[i] != '.') && (problem1[i] == ' ') && (problem1[i] != '_'))
                            {
                                ch1 = false;
                            }
                        }
                    }
                    if (dates1.Length != 3)
                        ch1 = false;
                    if (int.Parse(dates1[0]) < 1 || int.Parse(dates1[0]) > 31 || int.Parse(dates1[1]) < 0 || int.Parse(dates1[1]) > 12 || int.Parse(dates1[2]) < 2007 || int.Parse(dates1[2]) > 2030)
                    {
                        ch1 = false;
                    }
                    for (var i = 0; i < worker.Length; i++)
                    {
                        if ((worker[i] < 'А'))
                        {
                            if ((worker[i] != '!') && (worker[i] != ',') && (worker[i] != '.') && (worker[i] == ' ') && (worker[i] != '_'))
                            {
                                ch1 = false;
                            }
                        }
                    }
                    for (var i = 0; i < customer.Length; i++)
                    {
                        if ((customer[i] < 'А'))
                        {
                            if ((customer[i] != '!') && (customer[i] != ',') && (customer[i] != '.') && (customer[i] == ' ') && (customer[i] != '_'))
                            {
                                ch1 = false;
                            }
                        }
                    }
                    if (ch1 != false)
                    {
                        ProcessedReq r = new ProcessedReq(new Date(int.Parse(dates1[0]), int.Parse(dates1[1]), int.Parse(dates1[2])), subs1[subs1.Length - 1], subs1[3].Replace('_', ' '), subs1[2].Replace('_', ' '), subs1[1].Replace('_', ' '));
                        list.Add(r);
                        tree.Add(r.Key, r);
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag != false)
                    MessageBox.Show("Файлы успешно считаны!");

                else
                {
                    MessageBox.Show("Ошибка входных данных!");
                        Application.Exit();
                    }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка входных данных!");
                    Application.Exit();
                }
            finally
            {
                input1.Close();
            }

            foreach (var it in list)
            {
                dataGridView2.Rows.Add(it.Key.day.ToString() + "." + it.Key.month.ToString() + "." + it.Key.year.ToString(), it.problem, it.customer, it.worker, it.num);
            }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка входных данных!");
                Application.Exit();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 addForm = new Form2();
            DialogResult dialogResult = addForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                request N = addForm.NewRequest();
                if (tab.Find(N) == -1)
                {
                    tab.Add(N);
                    reqlist.Add(N);
                    RefreshDataGrid();
                    MessageBox.Show("Заявка успешно добавлена");
                }
                else MessageBox.Show("Такая заявка уже существует!");
            }
        }
        private void RefreshDataGrid()
        {
            dataGridView1.Rows.Clear();
          foreach (var it in reqlist)
            {
                dataGridView1.Rows.Add(tab.Hash(it, 0), tab.Find(it), it.number, it.problem, it.Key.day.ToString() + "." + it.Key.month.ToString() + "." + it.Key.year.ToString());
            }
        }
        private void RefreshDataGrid1()
        {
            dataGridView2.Rows.Clear();
            foreach (var it in list)
            {
                dataGridView2.Rows.Add(it.Key.day.ToString() + "." + it.Key.month.ToString() + "." + it.Key.year.ToString(), it.problem, it.customer, it.worker, it.num);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form3 addForm = new Form3();
            DialogResult dialogResult = addForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                int dd = 0;
                int mm = 0;
                int yy = 0;
                string num = "";
                string problem = "";
                addForm.GetKey(ref dd, ref mm, ref yy, ref num, ref problem);
                try
                {
                    request Key = new request(new Date(dd, mm, yy), num, problem);
                    Date KeyTree = new Date(dd, mm, yy);
                    bool found = false;
                    if (tab.Find(Key) != -1)
                    {
                        if (tree.TryFind(KeyTree, out var outp))
                        {
                            foreach (var it in outp)
                            {
                                if (it.num == Key.number && it.problem == Key.problem)
                                {
                                    DialogResult result=MessageBox.Show("Обнаружены связанные элементы. Удалить из обоих справочников?","Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                    if (result == DialogResult.Yes)
                                    {
                                        tab.Delete(Key);
                                        tree.Remove(KeyTree, it);
                                        list.Remove(it);
                                        reqlist.Remove(Key);
                                        RefreshDataGrid();
                                        RefreshDataGrid1();
                                        MessageBox.Show("Заявка успешно удалена из обоих справочников!");
                                        found = true;
                                        break;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Удаление отменено пользователем!");
                                        found = true;
                                    }
                                }
                            }
                        }
                        if (found != true)
                        {
                            tab.Delete(Key);
                            reqlist.Remove(Key);
                            RefreshDataGrid();
                            MessageBox.Show("Заявка успешно удалена!");
                        }
                    }
                    else MessageBox.Show("Такой заявки не существует!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка ввода!");
                }
            }
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            Form4 addForm = new Form4();
            DialogResult dialogResult = addForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                int dd = 0;
                int mm = 0;
                int yy = 0;
                string num = "";
                string problem = "";
                addForm.GetKey1(ref dd, ref mm, ref yy, ref num, ref problem);
                request Key = new request(new Date(dd, mm, yy), num, problem);
                try
                {
                    var index = tab.Find(Key);
                    if (index != -1)
                    {
                        MessageBox.Show($"Сравнений: {tab.count}");
                        dataGridView1.Rows.Clear();
                        dataGridView1.Rows.Add(tab.Hash(Key, 0), index, tab.data[index].number, tab.data[index].problem, tab.data[index].Key.day.ToString() + "." + tab.data[index].Key.month.ToString() + "." + tab.data[index].Key.year.ToString());

                    }
                    else MessageBox.Show("Такой заявки не существует!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Такой заявки не существует!");
                }

            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Form6 addForm = new Form6();
            DialogResult dialogResult = addForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                ProcessedReq N = addForm.NewProcRequest();
                bool foundin = false;
                request K = new request(new Date(N.Key.day, N.Key.month, N.Key.year), N.num, N.problem);
                if (tab.Find(K)!=-1)
                {
                    if (tree.TryFind(N.Key, out var check))
                    {
                        if (check != null)
                        {
                            foreach (var iter in check)
                            {
                                if (foundin != true)
                                {
                                    if (iter.num == N.num && iter.problem == N.problem)
                                    {
                                        foundin = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                        if (foundin != true)
                        {
                        tree.Add(N.Key, N);
                        list.Add(N);
                        RefreshDataGrid1();
                        MessageBox.Show("Обработанная заявка успешно добавлена!");
                    }
                       else
                        {
                            MessageBox.Show("Заявка уже обработана!");
                        }

                }
                else MessageBox.Show("Невозможно обработать несуществующую заявку!");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form7 addForm = new Form7(ref tree);
            DialogResult dialogResult = addForm.ShowDialog();
            ProcessedReq a = addForm.NewProcRequest();
            if (dialogResult == DialogResult.OK)
            {
                if (a != null)
                {
                    tree.Remove(a.Key, a);
                    list.Remove(a);
                    RefreshDataGrid1();
                    MessageBox.Show("Обработанная заявка успешно удалена");
                }
                else MessageBox.Show("Такой обработанной заявки не существует!");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form8 addForm = new Form8();
            var count = 0;
            DialogResult dialogResult = addForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                var list = tree.GetValuesRange(addForm.Min(), addForm.Max());
                try
                {
                        dataGridView2.Rows.Clear();
                        foreach (var it in list)
                        {
                            dataGridView2.Rows.Add(it.Key.day.ToString() + "." + it.Key.month.ToString() + "." + it.Key.year.ToString(), it.problem, it.worker, it.customer, it.num);
                            count++;
                        }

                        if (count == 0)
                        {
                        RefreshDataGrid1();
                        MessageBox.Show("Не существует обработанных заявок в указанном диапазоне!");
                        }
                        else MessageBox.Show($"Сравнений: {tree.count}");
                }
                catch (Exception)
                {
                    MessageBox.Show("Не существует обработанных заявок в указанном диапазоне!");
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            RefreshDataGrid1();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string path1 = @"C:\Users\avk41\source\repos\CourseWork\ProcRequests.txt";
            string path2 = @"C:\Users\avk41\source\repos\CourseWork\Requests.txt";
            foreach (var it in list)
            {
                it.customer = it.customer.Replace(" ", "_");
                it.worker = it.worker.Replace(" ", "_");
                it.problem = it.problem.Replace(" ", "_");
            }
            for (var i = 0; i < tab.data.Length; i++)
            {
                if (tab.data[i] != null)
                {
                    tab.data[i].problem = tab.data[i].problem.Replace(" ", "_");
                }
            }
            using (StreamWriter sw1 = new StreamWriter(path1))
            {
                foreach (var it in list)
                {
                    sw1.WriteLine(it);
                }
            }
            using (StreamWriter sw2 = new StreamWriter(path2))
            {
                for (var i = 0; i < tab.data.Length; i++)
                {
                    if (tab.data[i] != null)
                    {
                        sw2.WriteLine(tab.data[i]);
                    }
                }
            }
            DialogResult = DialogResult.OK;
            Hide();
            MainForm addForm = new MainForm();
            DialogResult dialogResult =addForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.Show();

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string path1 = @"C:\Users\avk41\source\repos\CourseWork\ProcRequests.txt";
            string path2 = @"C:\Users\avk41\source\repos\CourseWork\Requests.txt";
            foreach (var it in list)
            {
                it.customer= it.customer.Replace(" ", "_");
                it.worker = it.worker.Replace(" ", "_");
                it.problem = it.problem.Replace(" ", "_");
            }
            for (var i = 0; i < tab.data.Length; i++)
            {
                if (tab.data[i] != null)
                {
                    tab.data[i].problem= tab.data[i].problem.Replace(" ", "_");
                }
            }
            using (StreamWriter sw1 = new StreamWriter(path1))
            {
                foreach (var it in list)
                {
                    sw1.WriteLine(it);
                }
            }
            using (StreamWriter sw2 = new StreamWriter(path2))
            {
                for (var i = 0; i < tab.data.Length; i++)
                {
                    if (tab.data[i] != null)
                    {
                        sw2.WriteLine(tab.data[i]);
                    }
                }
            }
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string path1 = @"C:\Users\avk41\source\repos\CourseWork\ProcRequests.txt";
            string path2 = @"C:\Users\avk41\source\repos\CourseWork\Requests.txt";
            foreach (var it in list)
            {
                it.customer = it.customer.Replace(" ", "_");
                it.worker = it.worker.Replace(" ", "_");
                it.problem = it.problem.Replace(" ", "_");
            }
            for (var i = 0; i < tab.data.Length; i++)
            {
                if (tab.data[i] != null)
                {
                    tab.data[i].problem = tab.data[i].problem.Replace(" ", "_");
                }
            }
            using (StreamWriter sw1 = new StreamWriter(path1))
            {
                foreach (var it in list)
                {
                    sw1.WriteLine(it);
                }
            }
            using (StreamWriter sw2 = new StreamWriter(path2))
            {
                for (var i = 0; i < tab.data.Length; i++)
                {
                    if (tab.data[i] != null)
                    {
                        sw2.WriteLine(tab.data[i]);
                    }
                }
            }
            Application.Exit();
        }
    }
}