using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistences.Models
{
    public class Coordinate
    {
        public string AddressText { get; set; }

        public double Latitude { get; set; } = double.MinValue;

        public double Longitude { get; set; } = double.MinValue;

        public bool IFSuccess { get; set; }

        public bool IFSuccess { get; set; }

        public string? MetaAddress { get; set; }

        public string? Level0 { get; set; }

        public string? Level1 { get; set; }

        public string? Level2 { get; set; }

        public string? Level3 { get; set; }

        public string? Level4L { get; set; }

        public string? Level4LC { get; set; }

        public string? Level4A { get; set; }

        public string? Level4AC { get; set; }

        public string? Level5 { get; set; }

        public string? Detail { get; set; }
    }
}
