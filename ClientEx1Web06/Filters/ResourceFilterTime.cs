using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace ApiClientes.Filters
{
    public class ResourceFilterTime : IResourceFilter
    {

        Stopwatch timer = new();

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            timer.Stop();
            Console.WriteLine($"{timer.ElapsedMilliseconds}ms");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            timer.Start();
        }
    }
}
