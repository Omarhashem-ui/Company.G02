namespace Company.G02.Mvc.Services
{
    public interface ITransientServices
    {
        public Guid Guid { get; set; }

        string GetGuid();
    }
}
