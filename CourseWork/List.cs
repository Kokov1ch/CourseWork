using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CourseWork
{
    public class List<T> : IEnumerable<T> where T : IEquatable<T>
    {
        private Node<T> _root;

        public void Add(T data)
        {
            if (_root == null)
            {
                _root = new Node<T>(data);
                _root.Next = _root;
            }
            else
            {
                var current = _root;

                if (current.Value.Equals(data))
                    throw new ArgumentException();

                while (current.Next != _root)
                {
                    if (current.Value.Equals(data))
                        throw new ArgumentException();
                    current = current.Next;
                }

                var newNode = new Node<T>(data);
                newNode.Next = _root;
                current.Next = newNode;
            }
        }

        public bool Remove(T data)
        {
            if (_root != null)
            {
                if (_root.Value.Equals(data))
                {
                    if (_root.Next == _root)
                    {
                        _root = null;
                        return true;
                    }
                    else
                    {
                        var current = _root;
                        while (current.Next != _root)
                            current = current.Next;
                        current.Next = _root.Next;
                        _root = current.Next;
                        return true;
                    }
                }
                else
                {
                    var current = _root;
                    do
                    {
                        if (current.Next.Value.Equals(data))
                        {
                            current.Next = current.Next.Next;
                            return true;
                        }
                        current = current.Next;
                    } while (current.Next != _root);
                }
            }

            return false;
        }

        public bool TryFind(T data, out T item)
        {
            if (_root != null)
            {
                var current = _root;
                do
                {
                    if (current.Value.Equals(data))
                    {
                        item = current.Value;
                        return true;
                    }
                    current = current.Next;
                } while (current != _root);
            }

            item = default;
            return false;
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            if (_root == null)
            {
                str.Append("NULL");
            }
            else
            {
                var current = _root;
                do
                {
                    str.Append($"[{current.Value}] ");
                    current = current.Next;
                } while (current != _root);
            }
            return str.ToString();
        }

        public bool IsEmpty() => _root == null;

        public T this[int index]
        {
            get
            {
                var node = _root;
                for (int i = 0; i < index; i++)
                {
                    node = node.Next;
                }
                return node.Value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_root != null)
            {

                var node = _root;
                do
                {
                    yield return node.Value;
                    node = node.Next;
                } while (node != _root);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var node = _root;
            do
            {
                yield return node.Value;
                node = node.Next;
            } while (node != _root);
        }

        private class Node<U>
        {
            public U Value;
            public Node<U> Next;

            public Node(U value)
            {
                Value = value;
            }
        }
    }
}
