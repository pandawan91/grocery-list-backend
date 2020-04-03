using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using grocery_list_backend.DataAccess;
using grocery_list_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace grocery_list_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryListController : ControllerBase
    {
        private readonly MysqlDbContext _context;
        public GroceryListController(MysqlDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        // GET: api/GroceryList
        [HttpGet]
        public dynamic Get() => Ok(_context.GroceryListItems.ToList());

        // POST: api/GroceryList
        [HttpPost]
        public StatusCodeResult Post([FromBody] GroceryListItemModel value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var result = _context.GroceryListItems.Add(value);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            var toDelete = _context.GroceryListItems.FirstOrDefault(x => x.GroceryListItemModelId == id);

            if(toDelete != null)
            {
                _context.GroceryListItems.Remove(toDelete);
                _context.SaveChanges();

                return Ok();
            }

            return new StatusCodeResult(500);

        }
    }
}
