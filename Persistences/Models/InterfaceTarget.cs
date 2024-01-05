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

    public string Div { get; set; } = null!;

    public string Area1 { get; set; } = null!;

    public string Area2 { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public bool CompletedIf { get; set; }

    public DateOnly RegistDate { get; set; }

    public DateOnly? Ifdate { get; set; }
}
