using System;
using System.Threading.Tasks;
using AspStudio_Boilerplate.Areas.Audit.Models;
using AspStudio_Boilerplate.Areas.Identity.Data;
using AspStudio_Boilerplate.Helpers;
using AspStudio_Boilerplate.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Task = Microsoft.Build.Utilities.Task;

namespace AspStudio_Boilerplate.Services;

public class AuditService
{
    private readonly ApplicationDbContext _context;
    private readonly AppSettings _appSettings;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuditService(IOptions<AppSettings> appSettings, ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _appSettings = appSettings.Value;
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    public async Task<bool> Info(int AuditorId, string Message)
    {
        var entry = new AuditLogEntry()
        {
            Message = Message,
            Type = AuditLogType.Info,
            AuditorId = AuditorId,
            CreatedAt = DateTime.Now
        };

        _context.Update(entry);
        await _context.SaveChangesAsync();
        return true;
    }
}