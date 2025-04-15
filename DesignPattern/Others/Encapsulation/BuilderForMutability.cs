namespace DesignPattern.Others.Encapsulation;

/// <summary>
/// This pattern is useful prior to C#9
/// With C#9, use the `init` keyword on property instead
/// </summary>
public class StudentBuilder
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Score { get; set; }

    public Student Build()
    {
        return new Student(this);
    }
}

public class Student
{
    public string FirstName { get;  }
    public string LastName { get;  }
    public double Score { get; }

    public Student(StudentBuilder builder)
    {
        FirstName = builder.FirstName;
        LastName = builder.LastName;
        Score = builder.Score;
    }
}

public class BuilderCreatorClient
{
    public void UseBuilder()
    {
        var studentBuilder = new StudentBuilder
        {
            FirstName = "Toto",
            LastName = "King",
            Score = 0
        };
        var student = studentBuilder.Build();

        //FirstName not settable anymore
        //student.FirstName = "Tata";
    }
}
