using System.Collections.Generic;

namespace DesignPattern.Behavioural
{
    //Iterator lets you traverse elements of a collection without exposing its underlying representation (list, stack, tree, etc.).

    public interface Iterator
    {
        string GetFirst();

        string GetNext();

        bool HasMore();
    }

    public interface IterableCollection
    {
        Iterator CreateIterator();

        string this[int index] { get; }

        int Count { get; }
    }

    public class ConcreteIterator : Iterator
    {
        private readonly IterableCollection _collection;
        public int _count;

        public ConcreteIterator(IterableCollection collection)
        {
            _collection = collection;
            _count = 0;
        }

        public string GetFirst()
        {
            _count = 0;
            return _collection[_count];
        }

        public string GetNext()
        {
            return _collection[_count++];
        }

        public bool HasMore()
        {
            return _count < _collection.Count;
        }
    }

    public class ConcreteCollection : IterableCollection
    {
        private List<string> _data = new List<string>();

        public string this[int index] {
            get => _data[index];
        }

        public int Count
        {
            get => _data.Count;
        }

        public Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public void AddData(string data)
        {
            _data.Add(data);
        }
    }

    public class ClientIterator
    {
        private readonly IterableCollection _collection;

        public ClientIterator()
        {
            var collection = new ConcreteCollection();
            collection.AddData("Adam");
            collection.AddData("Lise");
            _collection = collection;
        }

        public void Display()
        {
            var iterator = _collection.CreateIterator();
            while (iterator.HasMore())
            {
                System.Console.WriteLine(iterator.GetNext());
            }
        }
    }
}