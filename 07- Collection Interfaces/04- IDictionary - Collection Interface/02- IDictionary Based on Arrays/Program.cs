using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomCollectionExample
{
    public class SimpleDictBasedOnArr <TKey, TValue> : IDictionary<TKey, TValue>
    {
        private KeyValuePair<TKey, TValue>[] _Arr;
        private int _Count;

        public SimpleDictBasedOnArr()
        {
            _Arr = new KeyValuePair<TKey, TValue>[2];
            _Count = 0;
        }

        public TValue this[TKey key]
        {
            get
            {
                for (int i = 0; i < _Count; i++)
                {
                    if (Equals(_Arr[i].Key, key))
                    {
                        return _Arr[i].Value;
                    }
                }
                throw new KeyNotFoundException($"The given key '{key}' was not present in the dictionary.");
            }
            set
            {
                for (int i = 0; i < _Count; i++)
                {
                    if (Equals(_Arr[i].Key, key))
                    {
                        _Arr[i] = new KeyValuePair<TKey, TValue>(key, value);
                        return;
                    }
                }
                Add(key, value);
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                TKey[] keys = new TKey[_Count];
                for (int i = 0; i < _Count; i++)
                {
                    keys[i] = _Arr[i].Key;
                }
                return keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                TValue[] values = new TValue[_Count];
                for (int i = 0; i < _Count; i++)
                {
                    values[i] = _Arr[i].Value;
                }
                return values;
            }
        }

        public int Count => _Count;

        public bool IsReadOnly => false;

        public void Add(TKey key, TValue value)
        {
            if (ContainsKey(key))
            {
                throw new ArgumentException($"The given key '{key}' Already Exist in the dictionary.");
            }

            if (_Count  == _Arr.Length)
            {
                Array.Resize(ref _Arr, _Arr.Length * 2);
            }

            _Arr[_Count++] = new KeyValuePair<TKey, TValue>(key, value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            _Arr = new KeyValuePair<TKey, TValue>[1];
            _Count = 0;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            for (int i = 0; i < _Count; i++)
            {
                if (Equals(_Arr[i], item))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsKey(TKey key)
        {
            for (int i = 0; i < _Count; i++)
            {
                if (Equals(_Arr[i].Key, key))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] DesArray, int arrayIndex)
        {
            if (DesArray == null)
            {
                throw new ArgumentNullException(nameof(DesArray));
            }

            if (arrayIndex < 0 || arrayIndex > DesArray.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }

            if (DesArray.Length - arrayIndex < _Count)
            {
                throw new ArgumentException("The destination DesArray has insufficient space to copy the elements.");
            }

            Array.Copy(_Arr, 0, DesArray, arrayIndex, _Count);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < _Count; i++)
            {
                yield return _Arr[i];
            }
        }

        public bool Remove(TKey key)
        {
            for (int i = 0; i < _Count; i++)
            {
                if (Equals(_Arr[i].Key, key))
                {
                    _Count--;
                    _Arr[i] = _Arr[_Count];
                    _Arr[_Count] = default;
                    return true;
                }
            }
            return false;
        }
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            for (int i = 0; i < _Count; i++)
            {
                if (Equals(_Arr[i], item))
                {
                    _Count--;
                    _Arr[i] = _Arr[_Count];
                    _Arr[_Count] = default;
                    return true;
                }
            }
            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            for (int i = 0; i < _Count; i++)
            {
                if (Equals(_Arr[i].Key, key))
                {
                    value = _Arr[i].Value;
                    return true;
                }
            }
            value = default;
            return false;
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
            SimpleDictBasedOnArr<int, string> MyArrDictionary = new SimpleDictBasedOnArr<int, string>();

            // Adding elements to the dictionary
            MyArrDictionary.Add(1, "One");
            MyArrDictionary.Add(2, "Two");
            MyArrDictionary.Add(3, "Three");

            // Accessing an element by key
            Console.WriteLine($"Element with key 2: {MyArrDictionary[2]}");

            // Updating an element by key
            MyArrDictionary[2] = "Two Updated";
            Console.WriteLine($"Updated element with key 2: {MyArrDictionary[2]}");

            // Iterating over the dictionary
            Console.WriteLine("\nIterating over the dictionary:");
            foreach (var kvp in MyArrDictionary)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            // Demonstrate the ContainsKey and Remove functionality
            if (MyArrDictionary.ContainsKey(3))
            {
                Console.WriteLine("\nContains key 3, removing...");
                MyArrDictionary.Remove(3);
            }

            // Display the dictionary after removal
            Console.WriteLine("\nDictionary after removing key 3:");
            foreach (var kvp in MyArrDictionary)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }


            Console.ReadKey();

        }
    }
}