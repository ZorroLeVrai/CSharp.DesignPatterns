using System;

namespace DesignPattern.Others.NonNull
{
    public class NonNullStructClient
    {
        public void UseNonNull()
        {
            IStudent student = new OptionStudent(new Student());
            student.DisplayName();
            Console.WriteLine($"Id: {student.Id}; Score: {student.GetScore()}");

            Console.WriteLine();

            //possible
            student = new OptionStudent();
            student.DisplayName();
            Console.WriteLine($"Id: {student.Id}; Score: {student.GetScore()}");
        }

        private interface IStudent
        {
            int Id { get; }

            double GetScore();

            void DisplayName();
        }

        private class Student : IStudent
        {
            private static readonly IStudent _none = new NoneStudent();

            public static IStudent None
                => _none;

            public int Id
                => 1;

            public double GetScore()
                => 10;

            public void DisplayName()
                => Console.WriteLine("Student Name");

            private class NoneStudent : IStudent
            {
                public int Id
                    => 0;

                public double GetScore()
                    => 0;

                public void DisplayName()
                { }
            }
        }

        private struct OptionStudent : IStudent
        {
            private readonly IStudent _student;

            public OptionStudent(Student student)
            {
                _student = student ?? Student.None;
            }

            private IStudent StudentInstance
            {
                get => _student ?? Student.None;
            }

            public int Id
                => StudentInstance.Id;

            public void DisplayName()
                => StudentInstance.DisplayName();

            public double GetScore()
                => StudentInstance.GetScore();
        }
    }
}
