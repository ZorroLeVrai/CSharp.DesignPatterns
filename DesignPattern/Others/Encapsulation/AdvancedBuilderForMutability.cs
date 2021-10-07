using System;

namespace DesignPattern.Others.Encapsulation
{
    public interface IReadOnlyEmployee
    {
        public string FirstName { get; }
        public string LastName { get; }
        public double Score { get; }
    }

    public class EmployeeBuilder
    {
        public IReadOnlyEmployee BuildV1(string firstName, string lastName, double score)
        {
            var employee = Employee.CreateReadWriteInstance();
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Score = score;

            //<paramref name="SayHello"/> function is not accessible
            //employee.SayHello();
            return employee;
        }

        public IReadOnlyEmployee BuildV2(string firstName, string lastName, double score)
        {
            return Employee.CreateReadOnlyInstance(firstName, lastName, score);
        }

        private interface IReadWriteEmployee : IReadOnlyEmployee
        {
            new public string FirstName { get; set; }
            new public string LastName { get; set; }
            new public double Score { get; set; }
        }

        private class Employee : IReadWriteEmployee, IReadOnlyEmployee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public double Score { get; set; }

            public static int Count = 0;
            
            public void SayHello()
            {
                Console.WriteLine("Hello World!");
            }

            private Employee()
            { }

            public static IReadWriteEmployee CreateReadWriteInstance()
                => new Employee();

            public static IReadOnlyEmployee CreateReadOnlyInstance(string firstName, string lastName, double score)
            {
                return new Employee()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Score = score
                };
            }
        }
    }

    public class EmployeeBuilderClient
    {
        public void UseEmployeeBuilder()
        {
            var builder = new EmployeeBuilder();
            var employee = builder.BuildV2("Sam", "Pompier", 20);

            //Cannot set attributes
            //employee.FirstName = "Zozo";
        }
    }
}
