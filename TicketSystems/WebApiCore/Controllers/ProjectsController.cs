using Core.Models;
using DataStore.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly BugContext bugContext;

        public ProjectsController(BugContext bugContext)
        {
            this.bugContext = bugContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(bugContext.Projects.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = bugContext.Projects.Find(id);

            if (project == null)
                return NotFound();
            return Ok(project);
        }

        [HttpGet]
        [Route("/api/projects/{pid}/tickets")]
        public IActionResult GetProjectTicket(int pid)
        {
            var tickets = bugContext.Tickets.Where(t => t.TicketId == pid).ToList();

            if (tickets == null || tickets.Count <= 0) return NotFound();

            return Ok(tickets);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Project project)
        {
            bugContext.Projects.Add(project);
            bugContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = project.ProjectId }, project);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Project project)
        {
            if (id != project.ProjectId) return BadRequest();

            bugContext.Entry(project).State = EntityState.Modified;

            try
            {
                bugContext.SaveChanges();
            }
            catch (Exception)
            {
                if (bugContext.Projects.Find(id) == null) return NotFound();
                throw;
            }
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var project = bugContext.Projects.Find(id);
            if (project == null) return NotFound();

            bugContext.Projects.Remove(project);
            bugContext.SaveChanges();

            return Ok(project);
        }

    }
}
