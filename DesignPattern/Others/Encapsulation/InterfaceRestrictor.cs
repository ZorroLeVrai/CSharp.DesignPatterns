namespace DesignPattern.Others.Encapsulation
{
    public interface IStudent
    {
        public string FirstName { get; }
        public string LastName { get; }
        public double Score { get; }
    }

    public class StudentEverythingPossible : IStudent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Score { get; set; }

        public IStudent Instance
            => this;
    }

    public class InterfaceRestrictorClient
    {
        public void Exec()
        {
            var studentBuilder = new StudentEverythingPossible
            {
                FirstName = "Toto",
                LastName = "King",
                Score = 0
            };
            var student = studentBuilder.Instance;

            //FirstName not settable anymore
            //student.FirstName = "Tata";
        }
    }
}
