using System.Collections.Generic;

namespace DesignPattern.Behavioural
{
    //Iterator lets you traverse elements of a collection without exposing its underlying representation (list, stack, tree, etc.).

    public interface IIterator
    {
        string GetFirst();

        string GetNext();

        bool HasMore();
    }

    public interface IIterableCollection
    {
        IIterator CreateIterator();

        string this[int index] { get; }

        int Count { get; }
    }

    public class ConcreteIterator : IIterator
    {
        private readonly IIterableCollection _collection;
        public int _count;

        public ConcreteIterator(IIterableCollection collection)
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
            ++_count;
            if (HasMore())
                return _collection[_count];

            return null;
        }

        public bool HasMore()
        {
            return _count < _collection.Count;
        }
    }

    public class ConcreteCollection : IIterableCollection
    {
        private readonly List<string> _data = new();

        public string this[int index] {
            get => _data[index];
        }

        public int Count
        {
            get => _data.Count;
        }

        public IIterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public void AddData(string data)
        {
            _data.Add(data);
        }
    }

    public class IteratorClient
    {
        private readonly IIterableCollection _collection;

        public IteratorClient()
        {
            var collection = new ConcreteCollection();
            collection.AddData("Adam");
            collection.AddData("Lise");
            _collection = collection;
        }

        public void Display()
        {
            var iterator = _collection.CreateIterator();
            for (var item = iterator.GetFirst(); iterator.HasMore(); item = iterator.GetNext())
            {
                System.Console.WriteLine(item);
            }
        }
    }
}