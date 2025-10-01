using Company.G02.Mvc.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Company.G02.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IScopedServices scopedServices01;
        private readonly IScopedServices scopedServices02;
        private readonly ISingeltonServices singeltonServices01;
        private readonly ISingeltonServices singeltonServices02;
        private readonly ITransientServices transientServices01;
        private readonly ITransientServices transientServices02;

        public HomeController(
            ILogger<HomeController> logger,
            IScopedServices scopedServices01,
            IScopedServices scopedServices02,
            ISingeltonServices singeltonServices01,
            ISingeltonServices singeltonServices02,
            ITransientServices transientServices01,
            ITransientServices transientServices02
            )
        {
            _logger = logger;
            this.scopedServices01 = scopedServices01;
            this.scopedServices02 = scopedServices02;
            this.singeltonServices01 = singeltonServices01;
            this.singeltonServices02 = singeltonServices02;
            this.transientServices01 = transientServices01;
            this.transientServices02 = transientServices02;
        }
        public string TestLifeTime()
        {
           StringBuilder builder = new StringBuilder();
            builder.AppendLine($"scopedServices01 : {scopedServices01.GetGuid()}");
            builder.AppendLine($"scopedServices02 : {scopedServices02.GetGuid()}");
            builder.AppendLine($"singeltonServices01 : {singeltonServices01.GetGuid()}");
            builder.AppendLine($"singeltonServices02 : {singeltonServices02.GetGuid()}");
            builder.AppendLine($"transientServices01 : {transientServices01.GetGuid()}");
            builder.AppendLine($"transientServices02 : {transientServices02.GetGuid()}");
            return builder.ToString();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
