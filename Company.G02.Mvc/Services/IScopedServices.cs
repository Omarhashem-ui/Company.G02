namespace Company.G02.Mvc.Services
{
    public interface IScopedServices
    {
        public Guid Guid { get; set; }

        string GetGuid();
    }
}
