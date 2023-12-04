using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwaySystem.Models
{
    [Table("SeatDiagram")]
    public class SeatDiagram
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TrainNo { get; set; }
        public int Compartment { get; set; }
        public string SeatCode { get; set; }
        public int SeatOrder { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }

    }
}
