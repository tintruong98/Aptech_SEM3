using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwaySystem.Models
{
    [Table("Resetpass")]
    public class Resetpass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string m_Email { get; set; }
        public string m_Token { get; set; }
        public DateTime m_Time { get; set; }
        public int m_Numcheck { get; set; }
    }
}
