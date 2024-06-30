namespace DI
{
    public interface IEmployee
    {
        string GetMessage();
    }

    public class EmploeeRepository : IEmployee
    {
        public string GetMessage()
        {
            return "Hello form Employess";
        }
    }
    public class TempEmploeeRepository : IEmployee
    {
        public string GetMessage()
        {
            return "Hello form temp Employess";
        }
    }
}
