namespace DesignPattern.Others.Encapsulation;

public interface IReadOnlyStudent
{
    public string FirstName { get; }
    public string LastName { get; }
    public double Score { get; }
}

public interface IReadWriteStudent
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Score { get; set; }
}

public class StudentEverythingPossible : IReadWriteStudent, IReadOnlyStudent
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Score { get; set; }
    public IReadOnlyStudent ReadInstance
        => this;

    private StudentEverythingPossible()
    { }

    public static IReadWriteStudent CreateReadWriteInstance()
        => new StudentEverythingPossible();

    public static IReadOnlyStudent CreateReadOnlyInstance()
        => new StudentEverythingPossible();

    public static StudentEverythingPossible CreateInstance()
        => new StudentEverythingPossible();
}

public class InterfaceRestrictorClient
{
    public void Exec()
    {
        var studentBuilder = StudentEverythingPossible.CreateInstance();
        studentBuilder.FirstName = "Toto";
        studentBuilder.LastName = "King";
        studentBuilder.Score = 0;
        var studentA = studentBuilder.ReadInstance;

        //FirstName not settable anymore
        //student.FirstName = "Tata";

        var studentReadWrite = StudentEverythingPossible.CreateReadWriteInstance();
        studentReadWrite.FirstName = "Toto";
        studentReadWrite.LastName = "King";
        studentReadWrite.Score = 0;

        //ReadInstance not reachable anymore
        //var studentB = studentReadWrite.ReadInstance;

        var rOnlyStudent = StudentEverythingPossible.CreateReadOnlyInstance();
        //FirstName not settable anymore
        //rOnlyStudent.FirstName = "Tata";
    }
}
