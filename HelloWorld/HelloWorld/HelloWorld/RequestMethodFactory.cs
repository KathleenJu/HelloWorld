using System;

namespace HelloWorld
{
    public abstract class RequestMethod
    {
        public abstract string GetResponse();
    }

    public class RequestMethodFactory
    {
        public RequestMethod makeRequestMethod(string rq)
        {
            throw new NotImplementedException();
        }
    }
}