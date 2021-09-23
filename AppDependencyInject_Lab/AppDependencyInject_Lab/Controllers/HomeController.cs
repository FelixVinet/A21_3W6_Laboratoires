using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AppDependencyInject_Lab.Models;
using AppDependencyInject_Lab.Models.ViewModels;
using AppDependencyInject_Lab.Service;

namespace AppDependencyInject_Lab.Controllers
{
  public class HomeController : Controller
  {
    public HomeVM homeVM { get; set; }
        // Ajouter la propriété du ZombieForecaster ici version 1

        private readonly IZombieForecaster _zombieForecaster;

        // Ajouter les propriétés multi-services (Stripe, twilio et waze) Version séparés ici
        // le type: classes Utility



        public HomeController(IZombieForecaster zombieForecaster)
        {
            homeVM = new HomeVM();
            _zombieForecaster = zombieForecaster;

        }


    public IActionResult Index()
    {
            // Version 1 injection dans le contructeur Action Index, récupérer le résultat
            NbrZombiesResult currentNbrZombie = _zombieForecaster.GetVillagePrediction();
            switch (currentNbrZombie.NbrZombiesCondition)
            {
                case NbrZombiesCondition.EnHausse:
                    homeVM.ZombieForecast = "Cours Forest! Cours!";
                    break;
                case NbrZombiesCondition.EnBaisse:
                    homeVM.ZombieForecast = "Relaxe et respire les fleurs. Namsté.";
                    break;
                case NbrZombiesCondition.Imprevisible:
                    homeVM.ZombieForecast = "En ces temps incertains, prends des forces en mangeant du chocolat.";
                    break;
                default:
                    homeVM.ZombieForecast = "L'abonnement ou la vie!";
                    break;
            }


            return View(homeVM);
    }

    #region Action AllConfigSetting version du constructeur muli-services
   

    #endregion

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
