using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Level2
{
    public class HashTableStructure<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private const int Capacity = 16;
        private double Loadfactor = 0.75;
        private int Size = 0;
        private List<KeyValuePair<K, T>>[] table = new List<KeyValuePair<K, T>>[Capacity];

        public int Count
        {
            get { return Size; }
            set { Size = value; }
        }

        public HashTableStructure()
        {
            this.table = new List<KeyValuePair<K, T>>[Capacity];
        }
        public void Add(K key, T value)
        {
            List<KeyValuePair<K, T>> list = this.FindList(key, true);
            for(int i =  0; i < list.Count; i++)
            {
                if (list[i].Key.Equals(key))
                {
                    list[i] = new KeyValuePair<K, T>(key, value);
                }
            }
            list.Add(new KeyValuePair<K, T>(key, value));
            this.Count++;
            this.Resize();
        }
        public T Find(K key)
        {
            List<KeyValuePair<K, T>> list = this.FindList(key, false);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Key.Equals(key))
                {
                    return list[i].Value;
                }
            }

            throw new KeyNotFoundException("Key is not found in the table");
        }

        public T Remove(K key)
        {
            List<KeyValuePair<K, T>> list = this.FindList(key, false);
            
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Key.Equals(key))
                {
                    T removedValue = list[i].Value;
                    list.RemoveAt(i);
                    this.Count--;
                    return removedValue;
                }
            }

            throw new KeyNotFoundException("Missing key");
        }

        public List<K> Keys()
        {
            List<K> keys = new List<K>();
            for (int i = 0; i < this.table.Length; i++)
            {
                if (this.table[i] != null)
                {
                    for (int j = 0; j < this.table[i].Count; j++)
                    {
                        if (this.table[i][j].Key != null)
                        {
                            keys.Add(this.table[i][j].Key);
                        }
                    }
                }
            }
            return keys;
        }

        public void Clear()
        {
            if(this.table != null)
            {
                this.table = new List<KeyValuePair<K, T>>[Capacity];
            }

            this.Count = 0;
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            foreach (var list in this.table)
            {
                if (list != null)
                {
                    foreach (var keyValuePair in list)
                    {
                        yield return keyValuePair;
                    }
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public T this[K key]
        {
            get
            {
                return this.Find(key);
            }
            set
            {
                this.Add(key, value);
            }
        }

        

        private List<KeyValuePair<K, T>> FindList(K key, bool createIfMissing)
        {
            var hashCode = (uint)key.GetHashCode() & int.MaxValue;
            var index = hashCode % this.table.Length;

            if (this.table[index] == null)
            {
                this.table[index] = new List<KeyValuePair<K, T>>();
            }

            return this.table[index];

        }
        private void Resize()
        {
            var maxLenght = this.table.Length * Loadfactor;
            if(this.Count >= maxLenght)
            {
                int newCapacity = this.table.Length * 2;
                List<KeyValuePair<K, T>>[] oldTable = this.table;
                this.table = new List<KeyValuePair<K, T>>[newCapacity];
                foreach (var oldList in oldTable)
                {
                    if(oldList != null)
                    {
                        foreach(var keyValuePair in oldList)
                        {
                            var list = this.FindList(keyValuePair.Key, true);
                            list.Add(keyValuePair);
                        }
                    }
                }
            }
        }
    }
}
