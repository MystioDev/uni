using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagyzh_004_BaseCode.Models
{
    internal class Painting : Artifact
    {
        public required int Width { get; set; }
        public required int Height { get; set; }

        public Painting() { }

        public Painting(string id, int value, int width, int height)
        {
            Id = id;
            Value = value;
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"Painting {Id} : {Value} Ft, is on display: {IsExhibited}, size: {Width}x{Height} cm";
        }
    }
}
