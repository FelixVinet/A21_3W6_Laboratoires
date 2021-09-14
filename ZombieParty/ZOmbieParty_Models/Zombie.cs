﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZombieParty_Models
{
  public class Zombie
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    [Range(1, 10, ErrorMessage = "RangeValidation")]
    public int Point { get; set; }
    public string ShortDesc { get; set; }

    //Supprimée: remplacée par liaison à la table ZombieType
    //NOTE: vous devez supprimer la liste du ViewBag dans le ZombieController pour compiler
    //public string Type { get; set; }

    [Display(Name = "Zombie Type")]
    // FACULTATIF on peut formellement identifier le champ lien
    [ForeignKey("ZombieType")]
    // Un Zombie DOIT avoir un ZombieType, donc int Ne peut PAS être null
    public int ZombieTypeId { get; set; }

    //OBLIGATOIRE Pour la relation 1 à plusieurs avec ZombieType
    public virtual ZombieType ZombieType { get; set; }

    // FACULTATIF on peut formellement identifier le champ lien
    [ForeignKey("ForceLevel")]
    // Un Zombie PEUT ou non avoir un ForceLevel, donc int peut être null
    public int? ForceLevelId { get; set; }

    //Propriété de navigation
    //OBLIGATOIRE Pour la relation 1 à plusieurs avec ForceLevel
    public virtual ForceLevel ForceLevel { get; set; }

    // Propriété de navigation vers zombieHuntingLog
    //OBLIGATOIRE Pour la relation 1 à plusieurs avec zombieHuntingLog
    public ICollection<ZombieHuntingLog> zombieHuntingLogs { get; set; }
  }
}