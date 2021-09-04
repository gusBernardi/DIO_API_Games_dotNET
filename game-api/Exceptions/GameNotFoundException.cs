using System;

namespace game_api.Exceptions
{
    public class GameNotFoundException : Exception
    {
        public GameNotFoundException() : base("Game Not Found.") {}
    }
}