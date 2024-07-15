using System;

namespace projet_jeux.Exceptions
{
    public class GameEndedException : Exception
    {
        public GameEndedException() : base("Game already ended !") { }
        public GameEndedException(string message)
            : base(message)
        {
        }
    }
}