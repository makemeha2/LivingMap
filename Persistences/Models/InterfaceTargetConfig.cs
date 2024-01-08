using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistences.Models
{
    [Table(nameof(InterfaceTargetConfig))]
    public class InterfaceTargetConfig
    {
        [Key]
        public int TargetIdx { get; set; }

        public ExtractType ExtractType { get; set; } = ExtractType.Auto;

        public string ExtractFuncName { get; set; } = string.Empty;

        public int? Area1Index { get; set; }

        public int? Area2Index { get; set; }

        public int? Area3Index { get; set; }

        public int? AddressIndex { get; set; }

        public int? LatitudeIndex { get; set; }

        public int? LongitudeIndex { get; set; }

        public InterfaceTarget InterfaceTarget { get; set; } = null!;
    }
}
