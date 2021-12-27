using Core.Models;
using DataStore.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using TicketSystem.Filters;
//using TicketSystem.Models;

namespace TicketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly BugContext context;

        public TicketsController(BugContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // Authentication and Authorization

            //Generic Validation

            //Retrieve the Input Data

            //Data Validation

            //Application Logic / Data

            //Format Output data

            //Exception handling

            var tickets = context.Tickets.ToList();

            return Ok(tickets);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ticket = context.Find<Ticket>(id);
            if (ticket == null) return NotFound();

            return Ok(ticket);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Ticket ticket)
        {
            context.Add<Ticket>(ticket);
            context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = ticket.TicketId }, ticket);
        }

        //[HttpPost]
        //[Route("/api/v2/tickets")]
        ////[Ticket_ValidationFilter]
        //public IActionResult PostV2([FromBody] Ticket ticket)
        //{
        //    return Ok(ticket);
        //}

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Ticket ticket)
        {
            if (id != ticket.TicketId) return BadRequest();

            context.Entry(ticket).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                context.SaveChanges();
            }
            catch (Exception)
            {
                if (context.Find<Ticket>(id) == null) return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ticket = context.Tickets.Find(id);

            if (ticket == null) return NotFound();

            context.Tickets.Remove(ticket);
            context.SaveChanges();

            return Ok(ticket);
        }

    }
}
