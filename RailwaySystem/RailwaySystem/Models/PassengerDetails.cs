using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwaySystem.Models
{
    [Table("PassengerDetails")]
    public class PassengerDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PNR { get; set; }
        
        [Required]
        public int UserID { get; set; }

        [Required]
        public string Name { get; set; }
        public bool Gender { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }

        [Required]
        public string Source { get; set; }

        [Required]
        public string Destination { get; set; }
        public DateTime Departure{ get; set; }
        public int TrainNo { get; set; }
        public int Compartment { get; set; }
        public string SeatCode { get; set; }
        public decimal Price { get; set; }
        public DateTime BookingDate { get; set; }
        
    }
}
