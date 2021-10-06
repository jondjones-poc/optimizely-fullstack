using OptimizelySDK;
using System;
using System.Web.Mvc;

namespace OptimizelyFullstackSampleSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var optimizelyInstance = OptimizelyFactory.NewDefaultInstance("KcJRoKbnxrcrRa5QGUSjy");

            var userId = Guid.NewGuid().ToString();
            var featureEnabled = optimizelyInstance.IsFeatureEnabled("discount", userId);

            if (featureEnabled)
            {
                var discountAmount = optimizelyInstance.GetFeatureVariableInteger("discount", "amount", userId);
                optimizelyInstance.Track("purchase", userId);
                throw new Exception($"feature flag enabled discount variable = {discountAmount}");
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}