using BackEnd___Lets.Data;
using BackEnd___Lets.Interceptor;
using BackEnd___Lets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd___Lets.Controllers
{
    [Authorize(Roles = "Gabriel,Lets")]
    [Route("[controller]")]
    public class CardsController : ControllerBase
    {
        private readonly CardContext _context;

        public CardsController(CardContext context)
        {
            _context = context;
        }


        [HttpGet("anonimo")]
        [AllowAnonymous]
        public IActionResult GetAnonimo()
        {
            return Ok(_context.cards.ToList());
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.cards.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var card = _context.cards.Where(card => card.id == id);

            if (card == null)
            {
                return NotFound();
            }

            return Ok(card);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ServiceInterceptor))]
        public IActionResult Put(int id, [FromBody]Card card)
        {
            if (id != card.id)
                return BadRequest("Id's nao coincidem");

            _context.Update(card);
            _context.SaveChanges();

            return Ok(card);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Card card)
        {
            _context.cards.Add(card);
            _context.SaveChanges();

            return Created($"api/cards/{card.id}", card);
        }


        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ServiceInterceptor))]
        public IActionResult Delete(int id)
        {
            var card = _context.cards.Find(id);
            if (card == null)
            {
                return NotFound();
            }

            _context.cards.Remove(card);
            _context.SaveChanges();

            return Ok(_context.cards.ToList());
        }
    }
}

