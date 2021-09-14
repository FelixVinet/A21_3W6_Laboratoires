﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieParty_DataAccess.Data;
using ZombieParty_DataAccess.Repository.IRepository;
using ZombieParty_Models;

namespace ZombieParty_DataAccess.Repository
{
  class CategoryRepository : Repository<Category>, ICategoryRepository
  {
    private readonly ZombiePartyDbContext _db;

    public CategoryRepository(ZombiePartyDbContext db) : base(db)
    {
      _db = db;
    }

    public void Update(Category category)
    {
      _db.Update(category);

    }
  }
}