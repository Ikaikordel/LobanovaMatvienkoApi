using System.ComponentModel.DataAnnotations;

namespace LobanovaMatvienkoApi.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string FullName { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
