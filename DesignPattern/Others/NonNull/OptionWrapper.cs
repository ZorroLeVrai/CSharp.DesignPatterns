using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace DesignPattern.Others.NonNull
{
    [DebuggerDisplay("{_data[0]}")]
    public class OptionWrapper<T> : IEnumerable<T>
    {
        private static readonly OptionWrapper<T> _none = new OptionWrapper<T>(Array.Empty<T>());
        private readonly T[] _data;

        private OptionWrapper(T[] data)
          => _data = data;

        public static OptionWrapper<T> Create(T element)
          => null != element ? new OptionWrapper<T>(new T[] { element }) : _none;

        public static OptionWrapper<T> None
        {
            get => _none;
        }

        public bool IsNone
        {
            get => 0 == _data.Length;
        }

        public T GetValue(T defaultValue)
          => IsNone ? defaultValue : _data[0];

        public OptionWrapper<U> Apply<U>(Func<T, U> apply)
        {
            if (IsNone)
                return OptionWrapper<U>.None;

            return OptionWrapper<U>.Create(apply(_data[0]));
        }

        public OptionWrapper<U> ApplyOption<U>(Func<T, OptionWrapper<U>> apply)
        {
            if (IsNone)
                return OptionWrapper<U>.None;

            return apply(_data[0]);
        }

        public void Action(Action<T> action)
        {
            if (IsNone)
                return;

            action(_data[0]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_data).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class OptionWrapperClient
    {
        public void UseOptionWrapper()
        {
            var student = OptionWrapper<Student>.Create(null);
            OptionWrapper<int> id = student.Apply(st => st.Id);
            OptionWrapper<double> mark = student.Apply(st => st.GetScore());
            student.Action(st => st.DisplayName());
        }

        private class Student
        {
            public int Id
                => 1;

            public double GetScore()
                => 10;

            public void DisplayName()
                => Console.WriteLine("Student Name");
        }
    }
}
