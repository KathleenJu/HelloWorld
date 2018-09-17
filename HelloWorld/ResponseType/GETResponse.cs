using System;
using Microsoft.AspNetCore.Http;

namespace HelloWorld
{
    public class GETResponse : ResponseType
    {
        public GETResponse(HttpContext context) : base(context)
        {
        }

        public override string GetResponse()
        {

            return "Hello " + mainUser + ", ";
        }
    }
}