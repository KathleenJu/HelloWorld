using System;
using Microsoft.AspNetCore.Http;

namespace HelloWorld
{
    public class ResponseTypeFactory
    {
        private readonly HttpContext _context;
        private readonly string _requestMethod;
        
        public ResponseTypeFactory(HttpContext context)
        {
            _context = context;
            _requestMethod = context.Request.Method;
        }
        public ResponseType makeResponseType()
        {
            switch (_requestMethod)
            {
                case "GET":
                    return new GETResponse(_context);
                case "POST":
                    return new GETResponse(_context);
                case "PUT":
                    return new GETResponse(_context);
            }

            return null;
        }
    }
}