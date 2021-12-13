using System;
using System.ComponentModel.DataAnnotations;
using AspStudio_Boilerplate.Models;

namespace AspStudio_Boilerplate.Areas.Audit.Models;

public class AuditLogEntry
{
    [Key]
    public int Id { get; set; }
    public AuditLogType Type { get; set; } = AuditLogType.Info;
    public ApplicationUser Auditor { get; set; }
    public int AuditorId { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }
}