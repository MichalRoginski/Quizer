using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.NET.Utils
{
    public class CustomPageFilter : IPageFilter
    {
        public CustomPageFilter(IConfiguration _config)
        {

        }
        public void OnPageHandlerSelected(PageHandlerSelectedContext pageContext)
        {

        }
        public void OnPageHandlerExecuting(PageHandlerExecutingContext pageContext)
        {

        }
        public void OnPageHandlerExecuted(PageHandlerExecutedContext pageContext)
        {
            var result = pageContext.Result;
            if (result is PageResult)
            {
                var page = ((PageResult)result);
                page.ViewData["filterMessage"] = DateTime.Now;
            }
        }
    }
}
