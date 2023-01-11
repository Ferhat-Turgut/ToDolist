using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Models
{
    public class Plan
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string PlanTittle { get; set; }
        public string PlanContents { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("PlanForein")]
        public int UserId { get; set; }
        public User? User { get; set; }

    }
}
