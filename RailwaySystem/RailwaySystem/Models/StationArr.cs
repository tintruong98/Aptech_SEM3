using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.Models
{
    [Table("StationArr")]
    public class StationArr
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string StationCode { get; set; }
        public string StationName { get; set; }

    }
}
