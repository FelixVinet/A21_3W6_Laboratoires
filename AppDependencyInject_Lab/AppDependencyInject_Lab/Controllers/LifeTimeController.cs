using AppDependencyInject_Lab.Service.LifeTimeExample;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AppDependencyInject_Lab.Controllers
{
  public class LifeTimeController : Controller
  {
        #region Créer une propriété pour chaque service lifeTime ici
        private readonly TransientService _transientService;
        private readonly ScopedService _scopedService;
        private readonly SingletonService _singletonService;


        #endregion

        #region Modifier le constructor controller ici
        public LifeTimeController(TransientService transientService,
        ScopedService scopedService, SingletonService singletonService)
        {
            _transientService = transientService;
            _scopedService = scopedService;
            _singletonService = singletonService;
        }

        #endregion


        public IActionResult Index()
    {
            #region Afficher les ID des trois lifeTime ici
            var messages = new List<String>
            {
                HttpContext.Items["CustomMiddlewareTransient"].ToString(),
                $"Transient Controller - {_transientService.GetGuid()}",
                HttpContext.Items["CustomMiddlewareScoped"].ToString(),
                $"Scoped Controller - {_scopedService.GetGuid()}",
                HttpContext.Items["CustomMiddlewareSingleton"].ToString(),
                $"Singleton Controller - {_singletonService.GetGuid()}",
            };

            #endregion

            return View(messages);
    }
  }
}
