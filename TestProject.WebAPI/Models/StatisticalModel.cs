using System.Collections.Generic;
using System.Linq;

namespace TestProject.WebAPI.Models
{
    public class StatisticalModel
    {
        public float AverageRate { get; set; }
        public float MaxRate { get; set; }
        public float MinRate { get; set; }
        public StatisticalModel(List<float> rates)
        {
            MinRate = rates.Min();
            MaxRate = rates.Max();
            AverageRate = rates.Average();

        }
    }
}
