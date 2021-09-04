using System;
using System.ComponentModel.DataAnnotations;

namespace game_api.InputModel
{
    public class GameInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "The 'Name' field must contain at least 2 characters and maximum 100.")]
        public string name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "The 'Developer' field must contain at least 2 characters and maximum 100.")]
        public string developer { get; set; }

        [Required]
        [Range(1900, 2100, ErrorMessage = "The 'Year' field must be in range [1900 - 2100].")]
        public int year { get; set; }
    }
}