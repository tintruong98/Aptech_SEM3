using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.Models
{
    [Table("TotalSeats")]
    public class TotalSeats
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SeatCode { get; set; }
        public string ClassName { get; set; }
        public int SeatsTotal { get; set; }
        public decimal PriceTotal { get; set; }
    }
}
