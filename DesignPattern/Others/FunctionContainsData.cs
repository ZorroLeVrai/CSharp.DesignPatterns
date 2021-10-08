using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPattern.Others
{
    public class FunctionData
    {
        /// <summary>
        /// This function simulates a class
        /// </summary>
        /// <returns></returns>
        public (Func<IEnumerable<int>>, Action<List<int>>, Action<int>) GetDataHandler()
        {
            //private member containing data
            var items = new List<int>();

            //exporting functions
            return (GetData, SetItem, AddItem);

            //declaring functions
            IEnumerable<int> GetData()
                => items;

            void SetItem(IEnumerable<int> data)
                => items = data.ToList();

            void AddItem(int item)
                => items.Add(item);
        }
    }

    public class UseFunctionData
    {
        public void Exec()
        {
            var functionData = new FunctionData();
            var (getter, setter, adder) = functionData.GetDataHandler();

            var initList = new List<int> { 78 };
            setter(initList);

            foreach (var i in Enumerable.Range(1, 10))
            {
                adder(i);
            }

            Console.WriteLine("Display Getter");
            Display(getter());
            Console.WriteLine("Display Init List");
            Display(initList);

            void Display(IEnumerable<int> items)
                => Console.WriteLine("[{0}]", string.Join(',', items));
        }
    }
}
