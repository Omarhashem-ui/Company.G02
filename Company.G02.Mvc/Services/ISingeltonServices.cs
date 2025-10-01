namespace Company.G02.Mvc.Services
{
    public interface ISingeltonServices
    {
        public Guid Guid { get; set; }

        string GetGuid();
    }
}
