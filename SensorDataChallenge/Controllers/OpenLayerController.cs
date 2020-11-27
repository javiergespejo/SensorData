using Microsoft.AspNetCore.Mvc;
using SensorDataChallenge.Enums;
using SensorDataChallenge.Filters;

namespace SensorDataChallenge.Controllers
{
    [Authorize(PermissionEnum.UpdateClient)]
    public class OpenLayerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
