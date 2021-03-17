using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PIMWebClient.Models
{
    [Table("DataTrajectoryCalculation")]
    public class DataTrajectoryCalculationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double FPLatitude { get; set; }
        public double InitialLongitude { get; set; }
        public double InitialHeight { get; set; }
        public double FLLatitude { get; set; }
        public double FinalLongitude { get; set; }
        public double FinalHeight { get; set; }
        public double TimeInterval { get; set; }
        public double MeteorDensity { get; set; }
        public double MeteorMass { get; set; }
        public int ObservatoryId { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual ObservatoryModel Observatory { get; set; }
    }
}
