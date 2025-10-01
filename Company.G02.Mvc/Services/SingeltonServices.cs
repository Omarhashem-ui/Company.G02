namespace Company.G02.Mvc.Services
{
    public class SingeltonServices : ISingeltonServices
    {
        public SingeltonServices()
        {
            Guid = Guid.NewGuid();
        }
        public Guid Guid { get; set; }
        public string GetGuid()
        {
            return Guid.ToString();
        }
    }
}
