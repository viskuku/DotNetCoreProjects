﻿//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace TicketSystem.Filters
//{
//    public class Version1DiscontinueResourceFilter : Attribute, IResourceFilter
//    {
//        public void OnResourceExecuted(ResourceExecutedContext context)
//        {
//        }

//        public void OnResourceExecuting(ResourceExecutingContext context)
//        {
//            if (context != null && !context.HttpContext.Request.Path.Value.ToLower().Contains("v2"))
//            {
//                context.Result = new BadRequestObjectResult(
//                new
//                {
//                    Versioning = new[] { "This version of API has expired, Please use the latest version." }
//                });
//            }
//        }
//    }
//}
