using System;
using System.Collections.Generic;
using System.Text;

namespace HashMapLib
{
    public class Entry<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }
    }

    public interface IMyMap<K, V>
    {
        int Count { get; }
        bool IsEmpty { get; }
        V this[K key] { get; set; }
        void Put(K Key, V Value);
        void Clear();
        bool ContainsKey(K key);
        bool ContainsValue(V value);
        void Remove(K key);
    }


    public class HashMap<K, V> : IMyMap<K, V>
    {
        private const int DefaultHoldTableSize = 20;
        private List<Entry<K, V>>[] HashTable;
        public HashMap()
        {
            HashTable = new List<Entry<K, V>>[DefaultHoldTableSize];
            for (int i = 0; i < HashTable.Length; i++)
            {
                HashTable[i] = new List<Entry<K, V>>();
            }
        }
        public HashMap(int RowCount)
        {
            HashTable = new List<Entry<K, V>>[RowCount];
            for (int i = 0; i < HashTable.Length; i++)
            {
                HashTable[i] = new List<Entry<K, V>>();
            }
        }
        public HashMap((K, V)[] tuple)
        {
            HashTable = new List<Entry<K, V>>[DefaultHoldTableSize];
            for (int i = 0; i < HashTable.Length; i++)
            {
                HashTable[i] = new List<Entry<K, V>>();
            }
            foreach ((K, V) tpl in tuple)
            {
                Put(tpl.Item1, tpl.Item2);
            }
        }
        public int Count
        {
            get
            {
                int count = 0;
                for (int i = 0; i < HashTable.Length; i++)
                {
                    count += HashTable[i].Count;
                }
                return count;
            }
        }
        public bool IsEmpty
        {
            get
            {
                return Count == 0;
            }
        }
        public V this[K key]
        {
            get
            {
                int index = GetMyHashCode(key);
                foreach (Entry<K, V> entry in HashTable[index])
                {
                    if (entry.Key.Equals(key))
                        return entry.Value;
                }
                return default;
            }
            set
            {
                Put(key, value);
            }
        }
        public void Put(K Key, V Value)
        {
            if (HashTable.Length == 0)
            {
                throw new IndexOutOfRangeException("Невозможно вставить элемент в null-таблицу");
            }
            Entry<K, V> Element = new Entry<K, V>();
            Element.Key = Key;
            Element.Value = Value;
            int num = GetMyHashCode(Element.Key);

            if (ContainsKey(Element.Key))
            {
                Remove(Element.Key);
            }
            HashTable[num].Add(Element);
        }

        public void Clear()
        {
            for (int i = 0; i < HashTable.Length; i++)
            {
                HashTable[i].Clear();
            }
        }
        public bool ContainsKey(K key)
        {
            int index = GetMyHashCode(key);
            foreach (Entry<K, V> entry in HashTable[index])
            {
                if (entry.Key.Equals(key))
                    return true;
            }
            return false;
        }
        public bool ContainsValue(V value)
        {
            for (int i = 0; i < HashTable.Length; i++)
            {
                foreach (Entry<K, V> entry in HashTable[i])
                {
                    if (entry.Value.Equals(value))
                        return true;
                }
            }
            return false;
        }
        public void Remove(K key)
        {
            int index = GetMyHashCode(key);
            foreach (Entry<K, V> entry in HashTable[index])
            {
                if (entry.Key.Equals(key))
                {
                    HashTable[index].Remove(entry);
                    return;
                }
            }
        }
        public int GetMyHashCode(K Key)
        {
            if (HashTable.Length == 0)
            {
                throw new DivideByZeroException("Невозможно вычислить хэш-код таблицы, в которой 0 строк");
            }
            string HashCode = Key.ToString();
            int Code = Math.Abs(HashCode.GetHashCode() % HashTable.Length);
            return Code;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < HashTable.Length; i++)
            {
                foreach (Entry<K, V> entry in HashTable[i])
                {
                    sb.AppendLine($"Ключ: {entry.Key}\t Значение:{entry.Value}");
                }
            }
            if (IsEmpty)
                sb.AppendLine("Таблица пуста");
            return sb.ToString();
        }
    }
}
