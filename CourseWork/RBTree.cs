using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
namespace CourseWork
{
    

    public class ProcessedReq : IComparable<ProcessedReq>, IEquatable<ProcessedReq>
    {
        public Date Key;
        public string num;
        public string worker;
        public string customer;
        public string problem;
        public ProcessedReq(Date key, string n, string w, string c, string p)
        {
            Key = key;
            num = n;
            worker = w;
            customer = c;
            problem = p;
        }
        public override string ToString()
        {
            return Key.day.ToString() + "." + Key.month.ToString() + "." + Key.year.ToString() + " " + problem + " " + customer + " " + worker + " " + num;
        }
        public int CompareTo(ProcessedReq other)
        {
            return Key.CompareTo(other.Key);
        }
        public bool Equals(ProcessedReq obj)
        {
            return (this.Key.day == obj.Key.day && this.Key.month == obj.Key.month && this.Key.year == obj.Key.year && this.worker == obj.worker && this.customer == obj.customer && this.problem == obj.problem);
        }


    }
        public class RedBlackTree<TKey, TValue> where TKey : IComparable<TKey> where TValue : IEquatable<TValue>
        {
            #region Private Variables
            private Node<TKey, TValue> _root;
            private Node<TKey, TValue> _nil;
            #endregion

            #region Constructor
            //Конструктор объекта класса RedBlackTree
            //Формальные параметры: пусто
            //Входные данные: пусто
            //Выходные данные: объект класса RedBlackTree
            public RedBlackTree()
            {
                _nil = new Node<TKey, TValue>();
                _root = _nil;
            }
            #endregion
                public int count = 0;
            #region Public Functions
            public List<TValue> GetValuesRange(TKey min, TKey max)
            {
            count = 0;
            //если min > max кидаем ошибку
            if (min.CompareTo(max) > 0)
                {
                count++;
                throw new ArgumentOutOfRangeException();
                }
            //если min или max == null кидаем ошибку
            if (min == null || max == null)
                {
                count++;
                throw new ArgumentNullException();
                }

                var values = new List<TValue>();
                var node = _root;

                //ищем элемент из диапозона
                while (node != _nil && (node.Key.CompareTo(min) < 0 || node.Key.CompareTo(max) > 0))
                {
                if (node.Key.CompareTo(min) < 0)
                {
                    count++;
                    node = node.RightChild;
                }
                else
                {
                    count++;
                    node = node.LeftChild;
                }
                }

                //собираем все значения из него
                if (node != _nil && node.Key.CompareTo(min) >= 0 && node.Key.CompareTo(max) <= 0)
                {
                    count++;
                    GetValuesRangeInternal(node, min, max, values);
                }
                //возвращаем значения из диапозона
                return values;
            }

            //Метод поиска по значению
            //Формальные параметры: объект типа T
            //Входные данные: значение для поиска
            //Выходные данные: найден или нет + обьект или пустой указатель
            public bool TryFind(TKey key, out List<TValue> found)
            {
                var node = Find(key);
                if (node != null)
                {
                    found = node.Values;
                    return true;
                }
                found = default;
                return false;
            }

            //Метод удаления по значению
            //Формальные параметры: объект типа T
            //Входные данные: значение для удаления
            //Выходные данные: пусто
            public void Remove(TKey key, TValue value)
            {
                var node = Find(key);
                node.Values.Remove(value);
                if (node.Values.IsEmpty())
                {
                    Delete(node);
                }
            }

            //Метод очистки дерева
            //Формальные параметры: пусто
            //Входные данные: объект класса RedBlackTree
            //Выходные данные: пусто
            public void Clear() => Clear(_root);

            //Метод добавления значения
            //Формальные параметры: объект типа T
            //Входные данные: значение для добавления
            //Выходные данные: пусто
            public void Add(TKey key, TValue value)
            {
                var currentNode = _root;
                if (currentNode == _nil)
                {
                    _root = new Node<TKey, TValue>(key, value, _nil);
                    _root.IsBlack = true;
                    return;
                }

                var parentNode = currentNode;
                while (currentNode != _nil)
                {
                    parentNode = currentNode;
                    if (currentNode.Key.CompareTo(key) > 0)
                        currentNode = currentNode.LeftChild;
                    else if (currentNode.Key.CompareTo(key) < 0)
                        currentNode = currentNode.RightChild;
                    else
                    {
                        currentNode.Values.Add(value);
                        return;
                    }
                }

                bool isLeftChild = parentNode.Key.CompareTo(key) >= 0;

                var node = new Node<TKey, TValue>(key, value, parentNode, isLeftChild, _nil);
                InsertCase1(node);
            }
            #endregion

            #region Delete Private Functions
            //Метод перестановки двух узлов
            //Формальные параметры: объект типа Node<T>, объект типа Node<T> 
            //Входные данные: два узла дерева
            //Выходные данные: пусто
            private void Transplant(Node<TKey, TValue> u, Node<TKey, TValue> v)
            {
                if (u.Parent == _nil)
                    _root = v;
                else if (u == u.Parent.LeftChild)
                    u.Parent.LeftChild = v;
                else
                    u.Parent.RightChild = v;
                v.Parent = u.Parent;
            }

            //Метод удаления узла из дерева
            //Формальные параметры: объект типа Node<T>
            //Входные данные: узел для удаления
            //Выходные данные: пусто
            private void Delete(Node<TKey, TValue> z)
            {
                var y = z;
                bool yWasBlack = y.IsBlack;
                Node<TKey, TValue> x;
                if (z.LeftChild == _nil)
                {
                    x = z.RightChild;
                    Transplant(z, z.RightChild);
                }
                else if (z.RightChild == _nil)
                {
                    x = z.LeftChild;
                    Transplant(z, z.LeftChild);
                }
                else
                {
                    y = FindMaximum(z.RightChild);
                    yWasBlack = y.IsBlack;
                    x = y.RightChild;
                    if (y.Parent == z)
                    {
                        x.Parent = y;
                    }
                    else
                    {
                        Transplant(y, y.RightChild);
                        y.RightChild = z.RightChild;
                        y.RightChild.Parent = y;
                    }
                    Transplant(z, y);
                    y.LeftChild = z.LeftChild;
                    y.LeftChild.Parent = y;
                    y.IsBlack = z.IsBlack;
                }
                if (yWasBlack)
                    DeleteFixup(x);
            }

            //Метод ребалансировки дерева при удалении
            //Формальные параметры: объект типа Node<T>
            //Входные данные: узел для которого будет проведена ребалансировка
            //Выходные данные: пусто
            private void DeleteFixup(Node<TKey, TValue> x)
            {
                Node<TKey, TValue> w;
                while (x != _root && x.IsBlack)
                {
                    if (x == x.Parent.LeftChild)
                    {
                        w = x.Parent.RightChild;
                        if (w.IsBlack == false)
                        {
                            w.IsBlack = true;
                            x.Parent.IsBlack = false;
                            RotateLeft(x.Parent);
                            w = x.Parent.RightChild;
                        }
                        if (w.LeftChild.IsBlack && w.RightChild.IsBlack)
                        {
                            w.IsBlack = false;
                            x = x.Parent;
                        }
                        else
                        {
                            if (w.RightChild.IsBlack)
                            {
                                w.LeftChild.IsBlack = true;
                                w.IsBlack = false;
                                RotateRight(w);
                                w = x.Parent.RightChild;
                            }

                            w.IsBlack = x.Parent.IsBlack;
                            x.Parent.IsBlack = true;
                            w.RightChild.IsBlack = true;
                            RotateLeft(x.Parent);
                            x = _root;
                        }
                    }
                    else
                    {
                        w = x.Parent.LeftChild;
                        if (w.IsBlack == false)
                        {
                            w.IsBlack = true;
                            x.Parent.IsBlack = false;
                            RotateRight(x.Parent);
                            w = x.Parent.LeftChild;
                        }
                        if (w.RightChild.IsBlack && w.LeftChild.IsBlack)
                        {
                            w.IsBlack = false;
                            x = x.Parent;
                        }
                        else
                        {
                            if (w.LeftChild.IsBlack)
                            {
                                w.RightChild.IsBlack = true;
                                w.IsBlack = false;
                                RotateLeft(w);
                                w = x.Parent.LeftChild;
                            }

                            w.IsBlack = x.Parent.IsBlack;
                            x.Parent.IsBlack = true;
                            w.LeftChild.IsBlack = true;
                            RotateRight(x.Parent);
                            x = _root;
                        }
                    }
                }
                x.IsBlack = true;
            }

            //Метод нахождения узла с минимальным значением в поддереве
            //Формальные параметры: объект типа Node<T>
            //Входные данные: корень поддерева
            //Выходные данные: узел с минимальным значением
            private Node<TKey, TValue> FindMaximum(Node<TKey, TValue> root)
            {
                Node<TKey, TValue> currentNode = root;
                while (currentNode.RightChild != _nil)
                    currentNode = currentNode.RightChild;
                return currentNode;
            }

            #endregion

            #region Insert Private Functions

            //Метод ребалансировки при добавлении значения (1 случай)
            //Формальные параметры: объект типа Node<T>
            //Входные данные: узел, который был добавлен
            //Выходные данные: пусто
            private void InsertCase1(Node<TKey, TValue> node)
            {
                if (node.Parent == _nil)
                    node.IsBlack = true;
                else if (node.GrandParent == _nil)
                    node.Parent.IsBlack = true;
                else
                    InsertCase2(node);
            }

            //Метод ребалансировки при добавлении значения (2 случай)
            //Формальные параметры: объект типа Node<T>
            //Входные данные: узел, который был добавлен
            //Выходные данные: пусто
            private void InsertCase2(Node<TKey, TValue> node)
            {
                if (node.Parent.IsBlack)
                    return;
                else
                    InsertCase3(node);
            }

            //Метод ребалансировки при добавлении значения (3 случай)
            //Формальные параметры: объект типа Node<T>
            //Входные данные: узел, который был добавлен
            //Выходные данные: пусто
            private void InsertCase3(Node<TKey, TValue> node)
            {
                if (node.Uncle != _nil && node.Uncle.IsBlack == false)
                {
                    node.Parent.IsBlack = true;
                    node.Uncle.IsBlack = true;
                    node.GrandParent.IsBlack = false;

                    InsertCase1(node.GrandParent);
                }
                else
                    InsertCase4(node);
            }

            //Метод ребалансировки при добавлении значения (4 случай)
            //Формальные параметры: объект типа Node<T>
            //Входные данные: узел, который был добавлен
            //Выходные данные: пусто
            private void InsertCase4(Node<TKey, TValue> node)
            {
                if (node == node.Parent.RightChild && node.Parent == node.GrandParent.LeftChild)
                {
                    RotateLeft(node.Parent);

                    node = node.LeftChild;
                }
                else if (node == node.Parent.LeftChild && node.Parent == node.GrandParent.RightChild)
                {
                    RotateRight(node.Parent);

                    node = node.RightChild;
                }

                InsertCase5(node);
            }

            //Метод ребалансировки при добавлении значения (5 случай)
            //Формальные параметры: объект типа Node<T>
            //Входные данные: узел, который был добавлен
            //Выходные данные: пусто
            private void InsertCase5(Node<TKey, TValue> node)
            {
                node.Parent.IsBlack = true;
                node.GrandParent.IsBlack = false;

                if (node == node.Parent.LeftChild && node.Parent == node.GrandParent.LeftChild)
                {
                    RotateRight(node.GrandParent);
                }
                else
                {
                    RotateLeft(node.GrandParent);
                }
            }

            #endregion

            #region Rotate Functions
            //Метод правого поворота дерева вокруг узла
            //Формальные параметры: объект типа RedBlackTree, объект типа Node<T>
            //Входные данные: узел вокруг, которого будет поворот
            //Выходные данные: пусто
            private void RotateRight(Node<TKey, TValue> node)
            {
                var pivot = node.LeftChild;

                pivot.Parent = node.Parent;
                if (node.Parent != _nil)
                    if (node.Parent.LeftChild == node)
                        node.Parent.LeftChild = pivot;
                    else
                        node.Parent.RightChild = pivot;

                node.LeftChild = pivot.RightChild;
                if (pivot.RightChild != _nil)
                    pivot.RightChild.Parent = node;

                node.Parent = pivot;
                pivot.RightChild = node;

                if (pivot.Parent == _nil)
                    _root = pivot;
            }

            //Метод левого поворота дерева вокруг узла
            //Формальные параметры: объект типа RedBlackTree, объект типа Node<T>
            //Входные данные: узел вокруг, которого будет поворот
            //Выходные данные: пусто
            private void RotateLeft(Node<TKey, TValue> node)
            {
                var pivot = node.RightChild;

                pivot.Parent = node.Parent;
                if (node.Parent != _nil)
                    if (node.Parent.LeftChild == node)
                        node.Parent.LeftChild = pivot;
                    else
                        node.Parent.RightChild = pivot;

                node.RightChild = pivot.LeftChild;
                if (pivot.LeftChild != _nil)
                    pivot.LeftChild.Parent = node;

                node.Parent = pivot;
                pivot.LeftChild = node;

                if (pivot.Parent == _nil)
                    _root = pivot;
            }
            #endregion

            #region Private Functions
            private void GetValuesRangeInternal(Node<TKey, TValue> root, TKey min, TKey max, List<TValue> values)
            {
                if (root != _nil)
                {
                //Если текущий не является левой границей диапозона и имеет левого потомка идем в него
                if (root.LeftChild != _nil && root.Key.CompareTo(min) >= 0)
                {
                    count++;
                    GetValuesRangeInternal(root.LeftChild, min, max, values);
                }

                    //Если текущий входит в диапозон то добавляем его в список значений
                    if (root.Key.CompareTo(min) >= 0 && root.Key.CompareTo(max) <= 0)
                    {
                    count++;
                    foreach (var value in root.Values)
                        {
                            values.Add(value);
                        }
                    }

                //Если текущий не является правой границей диапозона и имеет правого потомка идем в него
                if (root.RightChild != _nil && root.Key.CompareTo(max) <= 0)
                {
                    count++;
                    GetValuesRangeInternal(root.RightChild, min, max, values);
                }
                }
            }

            //Метод нахождения узла по значению
            //Формальные параметры: объект типа RedBlackTree, объект типа T
            //Входные данные: значение для поиска
            //Выходные данные: узел с заданным значением
            private Node<TKey, TValue> Find(TKey key)
            {
                var node = _root;
                while (node != _nil)
                {
                    if (node.Key.CompareTo(key) > 0)
                        node = node.LeftChild;
                    else if (node.Key.CompareTo(key) < 0)
                        node = node.RightChild;
                    else
                        return node;
                }
                return null;
            }

            //Метод очистки поддерева
            //Формальные параметры: объект типа Node<T>
            //Входные данные: корень поддерева
            //Выходные данные: пусто
            private void Clear(Node<TKey, TValue> root)
            {
                if (root != _nil)
                {
                    if (root.LeftChild != _nil) Clear(root.LeftChild);
                    if (root.RightChild != _nil) Clear(root.RightChild);
                    root.Dispose();
                }
            }
            #endregion

            #region Internal Node Class
            private class Node<UKey, UValue> : IDisposable where UValue : IEquatable<UValue>
            {
                public readonly UKey Key;
                public List<UValue> Values;

                public Node<UKey, UValue> LeftChild;
                public Node<UKey, UValue> RightChild;
                public Node<UKey, UValue> Parent;

                public bool IsBlack;

                public Node<UKey, UValue> Sibling
                {
                    get
                    {
                        if (Parent.LeftChild == this)
                            return Parent.RightChild;
                        else
                            return Parent.LeftChild;
                    }
                }

                public Node<UKey, UValue> Uncle
                {
                    get
                    {
                        if (GrandParent.LeftChild == Parent)
                            return GrandParent.RightChild;
                        else
                            return GrandParent.LeftChild;
                    }
                }

                public Node<UKey, UValue> GrandParent
                {
                    get
                    {
                        return Parent.Parent;
                    }
                }

                //Конструктор объекта класса Node
                //Формальные параметры: пусто
                //Входные данные: пусто
                //Выходные данные: объект класса Node
                public Node()
                {
                    Values = new List<UValue>();
                    LeftChild = this;
                    RightChild = this;
                    Parent = this;
                    IsBlack = true;
                }

                //Конструктор объекта класса Node
                //Формальные параметры: объект класса U, объект класса Node<U>
                //Входные данные: значение узла, nil-узел
                //Выходные данные: объект класса Node
                public Node(UKey key, UValue value, Node<UKey, UValue> nil)
                {
                    Key = key;
                    Values = new List<UValue>();
                    Values.Add(value);
                    LeftChild = nil;
                    RightChild = nil;
                    Parent = nil;
                    IsBlack = false;
                }

                //Конструктор объекта класса Node
                //Формальные параметры: объект класса U, объект класса Node<U>, логическая переменная, объект класса Node<U>
                //Входные данные: значение узла, nil-узел
                //Выходные данные: объект класса Node
                public Node(UKey key, UValue value, Node<UKey, UValue> parent, bool isLeftChild, Node<UKey, UValue> nil)
                {
                    Key = key;
                    Values = new List<UValue>();
                    Values.Add(value);
                    LeftChild = nil;
                    RightChild = nil;
                    Parent = parent;

                    if (parent != null)
                        if (isLeftChild)
                            parent.LeftChild = this;
                        else
                            parent.RightChild = this;

                    IsBlack = false;
                }

                //Метод очистки полей узла
                //Формальные параметры: пусто
                //Входные данные: объект класса Node
                //Выходные данные: пусто
                public void Dispose()
                {
                    Values = null;
                    LeftChild = null;
                    RightChild = null;
                    Parent = null;
                }

                public void Add(UValue value) => Values.Add(value);
                public void Remove(UValue value) => Values.Remove(value);
            }

            #endregion
        }
    }
