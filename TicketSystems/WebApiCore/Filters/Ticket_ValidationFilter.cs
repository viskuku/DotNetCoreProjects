//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using TicketSystem.Models;

//namespace TicketSystem.Filters
//{
//    public class Ticket_ValidationFilter : ActionFilterAttribute
//    {
//        public override void OnActionExecuting(ActionExecutingContext context)
//        {
//            base.OnActionExecuting(context);

//            var ticket = context.ActionArguments["ticket"] as Ticket;

//            if (ticket != null && !string.IsNullOrEmpty(ticket.Owner))
//            {
//                bool isValid = false;
//                if (ticket.EnteredDate.HasValue == false)
//                {
//                    context.ModelState.AddModelError("EnteredDate", "EnteredDate is required.");
//                    isValid = true;
//                }

//                if (ticket.EnteredDate.HasValue && ticket.DueDate.HasValue && ticket.EnteredDate > ticket.DueDate)
//                {
//                    context.ModelState.AddModelError("DueDate", "Duedate has to be later than EnteredDate.");
//                    isValid = true;
//                }

//                if (isValid)
//                {
//                    context.Result = new BadRequestObjectResult(context.ModelState);
//                }
//            }
//        }
//    }
//}
