using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Persistences.Models;

[Table(nameof(LocationInfo))]
[PrimaryKey(nameof(Div), nameof(Address))]
public class LocationInfo
{
    [StringLength(10)]
    public string Div { get; set; } = null!;

    [StringLength(10)]
    public string Area1 { get; set; } = null!;

    [StringLength(50)]
    public string Area2 { get; set; } = null!;

    [StringLength(50)]
    public string Area3 { get; set; } = null!;

    [StringLength(300)]
    public string Address { get; set; } = null!;

    public double Latitude { get; set; } = -999d;

    public double Longitude { get; set; } = -999d;

    public bool UseYN { get; set; } = true;

    public DateOnly RegistDate { get; set; }
}
