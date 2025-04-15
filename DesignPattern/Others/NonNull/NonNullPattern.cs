using System;

#nullable enable

namespace DesignPattern.Others.NonNull;

/// <summary>
/// Prefered way to handle null values - This uses the Nullable references types
/// On the Project level: <Nullable>enable</Nullable>
/// On the code level: #nullable enable
/// </summary>
public class NonNullPatternClient
{
    public void UseNonNull()
    {
        IStudent student = new Student();
        student.DisplayName();
        Console.WriteLine($"Id: {student.Id}; Score: {student.GetScore()}");

        Console.WriteLine();

        //student = null; - Show a warning when compiled
        student = Student.None;
        student.DisplayName();
        Console.WriteLine($"Id: {student.Id}; Score: {student.GetScore()}");
    }
}

public interface IStudent
{
    int Id { get; }

    double GetScore();

    void DisplayName();
}

public class Student : IStudent
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
