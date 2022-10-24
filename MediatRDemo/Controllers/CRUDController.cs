using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR.AppDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatR.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CRUDController : ControllerBase
    {
        private readonly MyDbContext _dbContext;

        public CRUDController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<string> Create()
        {
            Models.User user = new User("sxr", "12345");
            await _dbContext.Users.AddAsync(user);
            var result = await _dbContext.SaveChangesAsync();
            if (result>0)
            {
                return "add successfully";
            }
            else
            {
                return "failed to add";
            }
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var result = await _dbContext.Users.FirstAsync();
            return result.Remark;
        }

        [HttpPut]
        public async Task Update(string newName)
        {
            var result = await _dbContext.Users.FirstAsync();
            result.ChangeUserName(newName);
            await _dbContext.SaveChangesAsync();
        }
    }
}
