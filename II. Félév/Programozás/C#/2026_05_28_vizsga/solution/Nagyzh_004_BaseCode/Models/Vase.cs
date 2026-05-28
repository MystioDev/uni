using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagyzh_004_BaseCode.Models
{
    internal class Vase : Artifact
    {
        public required string PlaceOfOrigin { get; set; }

        public Vase() { }

        public Vase(string id, int value, string placeOfOrigin)
        {
            Id = id;
            Value = value;
            PlaceOfOrigin = placeOfOrigin;
        }

        public override string ToString()
        {
            return $"Vase {Id} : {Value} Ft, is on display: {IsExhibited}, place of origin: {PlaceOfOrigin}";
        }
    }
}
