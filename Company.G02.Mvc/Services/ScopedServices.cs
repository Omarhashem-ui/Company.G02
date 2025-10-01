namespace Company.G02.Mvc.Services
{
    public class ScopedServices : IScopedServices
    {
        public ScopedServices()
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

