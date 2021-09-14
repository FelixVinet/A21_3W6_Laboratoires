﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZombieParty_Models;

namespace ZombieParty.Controllers
{
  public class ZombieTypeController : Controller
  {
    public IActionResult Index()
    {
      this.ViewBag.MaListe = new List<ZombieType>()
      {
        new ZombieType(){TypeName= "Virus", Id=1},
        new ZombieType(){TypeName= "Contact", Id=2}
      };

      return View();
    }

    //GET CREATE
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Models.ZombieType zombieType)
    {
      if (ModelState.IsValid)
      {
        // Ajouter à la BD
      }

      return this.View(zombieType);
    }


  }
}
