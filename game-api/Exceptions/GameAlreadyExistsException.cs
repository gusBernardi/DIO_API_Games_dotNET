using System;

namespace game_api.Exceptions
{
    public class GameAlreadyExistsException : Exception
    {
        public GameAlreadyExistsException() : base("This game already exists.") { }
    }
}