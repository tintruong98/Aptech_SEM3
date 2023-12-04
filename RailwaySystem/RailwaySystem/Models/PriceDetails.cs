using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwaySystem.Models
{
    [Table("PriceDetails")]
    public class PriceDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SeatCode { get; set; }

        [Required]
        public string ClassName { get; set; }
        public decimal Price { get; set; }
    }
}
