using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace HelloWorld
{
    public abstract class ResponseType
    {
        private readonly HttpContext _context;
        protected string mainUser = "Kathleen";
        private List<string> users;
        
        protected ResponseType(HttpContext context)
        {
            _context = context;
            users = new List<string>();
        }
               
        public abstract string GetResponse();
    }
}