using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext db;

        public ActivitiesController(DataContext _db)
        {
            db = _db;
        }

        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await db.Activities.ToListAsync();
        }
      
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await db.Activities.FindAsync(id);
        }
    }
}
