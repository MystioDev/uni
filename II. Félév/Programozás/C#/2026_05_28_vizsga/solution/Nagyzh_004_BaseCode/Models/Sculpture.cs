using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagyzh_004_BaseCode.Models
{
    internal class Sculpture : Artifact
    {
        public required int Weight { get; set; }

        public Sculpture() { }

        public Sculpture(string id, int value, int weight)
        {
            Id = id;
            Value = value;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"Sculpture {Id} : {Value} Ft, is on display: {IsExhibited}, weight: {Weight} kg";
        }
    }
}
