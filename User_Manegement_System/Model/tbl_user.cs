using System.ComponentModel.DataAnnotations;

namespace User_Manegement_System.Model
{
    public class tbl_user
    {

        public int Id { get; set; }
        [MaxLength(256)]
        public string Username { get; set; } = string.Empty;
        [MaxLength(256)]
        public string Password { get; set; } = string.Empty;  // در عمل، این باید هش شود
        [MaxLength(25)]
        public string Role { get; set; } = "User";

    }
}
