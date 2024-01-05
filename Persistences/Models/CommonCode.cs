using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Persistences.Models;


[Table("CommonCode")]
[PrimaryKey(nameof(CodeGroup), nameof(Code))]
public partial class CommonCode
{
    public string CodeGroup { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string? CodeName { get; set; }

    public bool? UseYn { get; set; }
}
