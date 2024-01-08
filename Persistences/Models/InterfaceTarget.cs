using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistences.Models;

[Table(nameof(InterfaceTarget))]
public partial class InterfaceTarget
{
    [Key]
    public int Idx { get; set; }

    [StringLength(10)]
    public string Div { get; set; } = null!;

    [StringLength(10)]
    public string Area1 { get; set; } = null!;

    [StringLength(50)]
    public string Area2 { get; set; } = null!;

    [StringLength(200)]
    public string FileName { get; set; } = null!;

    [StringLength(300)]
    public string FilePath { get; set; } = null!;

    public bool CompletedIf { get; set; }

    public DateOnly RegistDate { get; set; }

    public DateOnly? Ifdate { get; set; }

    public InterfaceTargetConfig InterfaceTargetConfig { get; set; } = null!;
}
