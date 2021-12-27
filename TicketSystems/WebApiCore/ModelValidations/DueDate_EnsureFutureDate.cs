//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;
//using TicketSystem.Models;

//namespace TicketSystem.ModelValidations
//{
//    public class DueDate_EnsureFutureDate : ValidationAttribute
//    {
//        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//        {
//            if (validationContext != null)
//            {
//                var tickets = validationContext.ObjectInstance as Ticket;

//                var checkFutureDate = tickets != null && tickets.TicketId == null && tickets.DueDate.HasValue && (tickets.DueDate.Value.Date < DateTime.Today.Date.Date);

//                if (checkFutureDate)
//                {
//                    return new ValidationResult("Due date is not future date");
//                }
//            }
//            return ValidationResult.Success;
//        }
//    }
//}
