using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ISet
{
    public class MyCollectionSet<T> : ISet<T>
    {
        private List<T> _Items = new List<T>();

        public int Count => _Items.Count;

        public bool IsReadOnly => false;

        public bool Add(T item)
        {
            if (!_Items.Contains(item))
            {
                _Items.Add(item);
                return true;
            }
            return false;
        }

        public void Clear()
        {
            _Items.Clear();
        }

        public bool Contains(T item)
        {
            if (_Items.Contains(item))
                return true;
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("array is null");
            if (array.Length - arrayIndex < _Items.Count)
                throw new ArgumentOutOfRangeException("Array is not enough to hold elements");

            for (int i = 0; i < _Items.Count; i++)
            {
                array[arrayIndex + i] = _Items[i];
            }
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            HashSet<T> otherSet = new HashSet<T>(other);
            for (int i = _Items.Count - 1; i >= 0; i--)
            {

                if (otherSet.Contains(_Items[i]))
                {
                    _Items.Remove(_Items[i]);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _Items.Count; i++)
            {
                yield return _Items[i];
            }
            ;

        }

        public void IntersectWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            HashSet<T> otherSet = new HashSet<T>(other);
            for (int i = _Items.Count - 1; i >= 0; i--)
            {
                if (!(otherSet.Contains(_Items[i])))
                {
                    _Items.Remove(_Items[i]);
                }
            }
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            HashSet<T> otherSet = new HashSet<T>(other);

            if (otherSet.Count >= _Items.Count)
                return false;

            foreach (T item in _Items)
            {
                if (!otherSet.Contains(item))
                {
                    return false;
                }
            }
            return (otherSet.Count > _Items.Count);
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            HashSet<T> otherSet = new HashSet<T>(other);

            if (otherSet.Count >= _Items.Count)
                return false;

            foreach (T item in otherSet)
            {
                if (!_Items.Contains(item))
                {
                    return false;
                }
            }
            return (otherSet.Count < _Items.Count);
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            HashSet<T> otherSet = new HashSet<T>(other);

            foreach (T item in _Items)
            {
                if (!otherSet.Contains(item))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            foreach (T item in other)
            {
                if (!_Items.Contains(item))
                {
                    return false;
                }
            }

            return true;
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            HashSet<T> otherSet = new HashSet<T>(other);

            foreach (T item in _Items)
            {
                if (otherSet.Contains(item))
                    return true;
            }
            return false;
        }

        public bool Remove(T item)
        {
            return _Items.Remove(item);
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            HashSet<T> otherSet = other as HashSet<T>;

            return _Items.ToHashSet().SetEquals(otherSet);
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {

            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            HashSet<T> otherSet = other as HashSet<T>;
            foreach (T item in otherSet)
            {
                if (!_Items.Contains(item))
                {
                    _Items.Add(item); // add unique element
                }
                else
                {
                    _Items.Remove(item); // remove common element
                }
            }
        }

        public void UnionWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            HashSet<T> otherSet = new HashSet<T>(other);

            foreach (T item in otherSet)
            {
                if (!_Items.Contains(item))
                {
                    _Items.Add(item);
                }
            }

        }

        void ICollection<T>.Add(T item)
        {
            _Items.Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of MyCollectionSet
            MyCollectionSet<int> mySet = new MyCollectionSet<int>();

            // Add elements to mySet
            mySet.Add(1);
            mySet.Add(2);
            mySet.Add(3);


            // Display the elements in mySet
            Console.WriteLine("Elements in mySet:");
            foreach (int item in mySet)
            {
                Console.WriteLine(item);
            }

            MyCollectionSet<int> otherSet = new MyCollectionSet<int>();
            otherSet.Add(2);
            otherSet.Add(3);
            otherSet.Add(4);
            otherSet.Add(1);

            Console.WriteLine("Is mySet a subset of otherSet? " + mySet.IsSubsetOf(otherSet));
            Console.WriteLine("Is mySet a superset of otherSet? " + mySet.IsSupersetOf(otherSet));

            mySet.IntersectWith(otherSet);
            Console.WriteLine("Elements in mySet after IntersectWith:");
            foreach (int item in mySet)
            {
                Console.WriteLine(item);
            }

            mySet.UnionWith(otherSet);
            Console.WriteLine("Elements in mySet after UnionWith:");
            foreach (int item in mySet)
            {
                Console.WriteLine(item);
            }
            mySet.ExceptWith(otherSet);
            Console.WriteLine("Elements in mySet after ExceptWith:");
            foreach (int item in mySet)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}