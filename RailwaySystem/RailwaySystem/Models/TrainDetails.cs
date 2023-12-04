using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwaySystem.Models
{
    [Table("TrainDetails")]
    public class TrainDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrainNo { get; set; }

        [Required]
        public string TrainName { get; set; }

        [Required]
        public string Source { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        //[DataType(DataType.Date)]
        public DateTime Departure { get; set; }

        [Range(1, 10, ErrorMessage = "NoOfCompartment from 1 to 10")]
        public int NoOfCompartment { get; set; }

        [Range(0, 64, ErrorMessage = "FirstClass from 0 to 64")]
        public int FirstClass { get; set; }

        [Range(0, 64, ErrorMessage = "SecondClass from 0 to 64")]
        public int SecondClass { get; set; }

        [Range(0, 64, ErrorMessage = "ThirdClass from 0 to 64")]
        public int ThirdClass { get; set; }

        [Range(0, 64, ErrorMessage = "SleepRoom from 0 to 64")]
        public int SleepRoom { get; set; }

        [Range(0, 64, ErrorMessage = "SleepRoom from 0 to 64")]
        public int General { get; set; }

        public bool Status { get; set; }
    }
}
