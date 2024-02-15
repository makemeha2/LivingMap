﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Persistences.Models;

public partial class Location
{
    public string Div { get; set; }

    public string AddressText { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public bool SuccessYn { get; set; }

    public bool UseYn { get; set; }

    public DateTime CreateDate { get; set; }

    public bool? ManualYn { get; set; }

    public string Remark { get; set; }

    public string MetaAddress { get; set; }

    public string Level0 { get; set; }

    public string Level1 { get; set; }

    public string Level2 { get; set; }

    public string Level3 { get; set; }

    public string Level4L { get; set; }

    public string Level4Lc { get; set; }

    public string Level4A { get; set; }

    public string Level5 { get; set; }

    public string Detail { get; set; }

    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();
}