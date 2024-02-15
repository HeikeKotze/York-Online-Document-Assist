using Blazorise.RichTextEdit;
using Blazorise;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using YODA.Repos;
using YODA.Services;
using Blazorise.Icons.FontAwesome;
using Blazorise.Bootstrap;
using YODA.Repos.Models;
using Blazorise.LoadingIndicator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//builder.Services.AddDbContext<dbfirstcontext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("Data Source=YRKHUBSQLSRV.YORK.CO.ZA;User ID=CapexUser;Password=C@pex123User!;Connect Timeout=60;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False")));
builder.Services.AddDbContext<dbfirstcontext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Server=(localdb)\\CapexLocal;Database=yrkCapexDB;Trusted_Connection=True;MultipleActiveResultSets=true;")));

builder.Services.AddScoped<ICapexFormService, CapexFormService>();
builder.Services.AddScoped<IProjectManagerService, ProjectManagerService>();
builder.Services.AddScoped<ILegalEntityService, LegalEntityService>();
builder.Services.AddScoped<ISiteService, SiteService>();
builder.Services.AddScoped<IKPIService, KPIService>();
builder.Services.AddScoped<ILocationCostCodeService, LocationCostCodeService>();
builder.Services.AddScoped<IBalanceSheetCodeService, BalanceSheetCodeService>();
builder.Services.AddScoped<IAssetCategoryService, AssetCategoryService>();
builder.Services.AddScoped<IProjectCategoryService, ProjectCategoryService>();
builder.Services.AddScoped<IRiskService, RiskService>();
builder.Services.AddScoped<IAttachmentService, AttachmentService>();
builder.Services.AddScoped<ISignatoryService, SignatoryService>();
builder.Services.AddScoped<IFileUpload, FileUpload>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IBusinessUnitService, BusinessUnitService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IInstructionService, InstructionService>();
builder.Services.AddScoped<FileService, FileService>();
builder.Services.AddScoped<ICapexUserService, CapexUserService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAccessService, AccessService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IDisciplineService, DisciplineService>();
builder.Services.AddScoped<IServerPathConfigService, ServerPathConfigService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IWorkRecordService, WorkRecordService>();
builder.Services.AddScoped<SharedDataService>();
builder.Services.AddScoped<IAccessLinkingService, AccessLinkingService>();
builder.Services.AddScoped<IFileHandlingService, FileHandlingService>();
builder.Services.AddScoped<ILoadingIndicatorService, LoadingIndicatorService>();
builder.Services.AddScoped<IExcelExportService, ExcelExportService>();

builder.Services
    .AddBlazoriseRichTextEdit(options => { });

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();
builder.Services.AddLoadingIndicator();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
