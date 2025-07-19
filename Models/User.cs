using System.ComponentModel.DataAnnotations;



namespace HASS_v1.Models

{

    public class User

    {

        public int UserId { get; set; }



        public string Role { get; set; } // "Admin" or "Patient"

        [Required]

        public string Username { get; set; }



        [Required]

        public string Password { get; set; } // In a production scenario, you should hash passwords.

    }

}

