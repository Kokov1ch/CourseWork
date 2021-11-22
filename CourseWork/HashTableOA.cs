using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class Date : IComparable<Date>, IEquatable<Date>
    {
        public int day;
        public int month;
        public int year;
        public Date(int inday, int inmonth, int inyear)
        {
            day = inday;
            month = inmonth;
            year = inyear;
        }


        public int CompareTo(Date other)
        {
            if (year > other.year)
            {
                return 1;
            }
            else if (year < other.year)
            {
                return -1;
            }
            else
            {
                if (month > other.month)
                {
                    return 1;
                }
                else if (month < other.month)
                {
                    return -1;
                }
                else
                {
                    if (day > other.day)
                    {
                        return 1;
                    }
                    else if (day < other.day)
                    {
                        return -1;
                    }
                    else return 0;
                }
            }
        }
        public bool Equals(Date obj)
        {
            return (this.day == obj.day && this.month == obj.month && this.year == obj.year);
        }

    }
    public class request : IComparable<request>, IEquatable<request>
    {
        public Date Key;
        public string number;
        public string problem;
        public request(Date inKey,string innumber, string inproblem)
        {
            Key = inKey;
            number = innumber;
            problem = inproblem;
        }
        public override string ToString()
        {
            return ($"{number} {problem} {Key.day.ToString() + "." + Key.month.ToString() + "." + Key.year.ToString()}");
        }
        public bool Equals(request obj)
        {
            return (this.Key.day == obj.Key.day && this.Key.month == obj.Key.month && this.Key.year == obj.Key.year && this.number == obj.number && this.problem == obj.problem);
        }
        public int CompareTo(request other)
        {
            return Key.CompareTo(other.Key);
        }
    }
    public class HashTableOA
    {
        private int load;
        public request[] data;
        public bool[] deleted;
        private const int Minsize = 20;
        private const float Upper = 0.75f;
        private const float Lower = 0.25f;
        public HashTableOA()
        {
            data = new request[Minsize];
            deleted = new bool[Minsize];
            load = 0;
        }
        public void Clear()
        {
            load = 0;
            data = new request[Minsize];
            deleted = new bool[Minsize];
        }
        public int Hash(request key, int i)
        {
            int count = 0;
            var dd = key.Key.day;
            var mm = key.Key.month;
            var y = key.Key.year;
            var n = key.number;
            var p = key.problem;
            while (dd != 0)
            {
                count += dd % 10;
                dd /= 10;
            }
            while (mm != 0)
            {
                count += mm % 10;
                mm /= 10;
            }
            while (y != 0)
            {
                count += y % 10;
                y /= 10;
            }
            for (var j = 0; j < n.Length; j++)
            {
                count += int.Parse(n[j].ToString());
            }
            while (p.Length != 0)
            {
                count += (int)(p[p.Length-1]);
                p = p.Substring(0, p.Length - 1);
            }
            count = (count + i) % data.Length;
            return count;
        }
        public void Add(request K)
        {
            var ch = false;
            var i = 0;
            if (Find(K) == -1)
            {
                while (ch != true)
                {
                    var index = Hash(K, i);
                    if (data[index] == null || deleted[index]==true)
                    {
                        data[index] = K;
                        load++;
                        deleted[index] = false;
                        ch = true;
                        if (load > data.Length * Upper)
                            Resize();
                    }
                    i++;
                }
            }
        }
        public void Resize()
        {
            if (load > data.Length * Upper)
            {
                request[] temp = new request[data.Length];
                bool[] marks = new bool[data.Length];
                for (var i = 0; i < marks.Length; i++)
                {
                    marks[i] = deleted[i];
                }
                for (var i = 0; i < temp.Length; i++)
                {
                    temp[i] = data[i];
                }
                load = 0;
                data = new request[temp.Length * 2];
                deleted = new bool[temp.Length * 2];
                for (var i = 0; i < temp.Length; i++)
                {
                    if (temp[i] != null && marks[i]!=true)
                        Add(temp[i]);
                }
            }
            else
            {
                if (load < data.Length * Lower)
                {
                    request[] temp = new request[data.Length];
                    bool[] marks = new bool[data.Length];
                    for (var i = 0; i < marks.Length; i++)
                    {
                        marks[i] = deleted[i];
                    }
                    for (var i = 0; i < temp.Length; i++)
                    {
                        temp[i] = data[i];
                    }
                    load = 0;
                    data = new request[temp.Length / 2];
                    deleted = new bool[temp.Length / 2];
                    for (var i = 0; i < temp.Length; i++)
                    {
                        if (temp[i] != null && marks[i] != true)
                            Add(temp[i]);
                    }
                }
            }

        }
        public void Delete(request K)
        {
            var index = Find(K);
            if (index != -1)
            {
                deleted[index] = true;
                load--;
                if (load < data.Length * Lower)
                    Resize();
            }
        }
        public int count = 0;
        public int Find(request K)
        {
            count =0;
            var i = 0;
            var index = Hash(K, i);
            count++;
            while ((data[index] != null && !data[index].Equals(K)))
            {
                count++;
                i++;
                index = Hash(K, i);
            }
            return data[index] != null && !deleted[index] ? index : -1;
        }
        public void Print()
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != null)
                {
                    Console.WriteLine($"Hash code [{i}]: {data[i].ToString()}");
                }
            }
        }
    }
}
