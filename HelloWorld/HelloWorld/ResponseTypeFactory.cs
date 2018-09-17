using System;

namespace HelloWorld
{
    public class ResponseTypeFactory
    {
        public ResponseType makeResponseType(string requestMethod)
        {
            switch (requestMethod)
            {
                case "GET":
                    return new GETResponse();
            }

            return null;
        }
    }
}