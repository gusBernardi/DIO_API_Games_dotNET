using System;

namespace game_api.Entities
{
    public class Game
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string developer { get; set; }
        public int year { get; set; }
    }
}