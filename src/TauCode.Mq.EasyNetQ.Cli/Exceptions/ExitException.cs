using System;

namespace TauCode.Mq.EasyNetQ.Cli.Exceptions
{
    [Serializable]
    public class ExitException : Exception
    {
        public ExitException()
        {
        }

        public ExitException(string message) : base(message)
        {
        }

        public ExitException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
