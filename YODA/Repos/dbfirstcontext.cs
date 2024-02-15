using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using YODA.Repos.Models;

namespace YODA.Repos;

public partial class dbfirstcontext : DbContext
{
    public dbfirstcontext()
    {
    }

    public dbfirstcontext(DbContextOptions<dbfirstcontext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccessType> AccessTypes { get; set; }

    public virtual DbSet<AssetCategory> AssetCategories { get; set; }

    public virtual DbSet<AttachmentType> AttachmentTypes { get; set; }

    public virtual DbSet<BalanceSheetCode> BalanceSheetCodes { get; set; }

    public virtual DbSet<BusinessUnit> BusinessUnits { get; set; }

    public virtual DbSet<CapexForm> CapexForms { get; set; }

    public virtual DbSet<CapexUser> CapexUsers { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<FkAttachmentsCapex> FkAttachmentsCapexes { get; set; }

    public virtual DbSet<FkKpicapex> FkKpicapexes { get; set; }

    public virtual DbSet<FkSignatoriesCapex> FkSignatoriesCapexes { get; set; }

    public virtual DbSet<Kpi> Kpis { get; set; }

    public virtual DbSet<LegalEntity> LegalEntities { get; set; }

    public virtual DbSet<LocationCostCode> LocationCostCodes { get; set; }

    public virtual DbSet<ProjectCategory> ProjectCategories { get; set; }

    public virtual DbSet<Risk> Risks { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Site> Sites { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<LanguageProficiency> LanguageProficiencies { get; set; }
    public virtual DbSet<Dependants> Dependants { get; set; }
    public virtual DbSet<Beneficiaries> Beneficiaries { get; set; }
    public virtual DbSet<PreviousEmployment> PreviousEmployments { get; set; }
    public virtual DbSet<EducationalHistory> EducationalHistories { get; set; }
    public virtual DbSet<EmployeeTitle> EmployeeTitles { get; set; }
    public virtual DbSet<EmployeeGender> EmployeeGenders { get; set; }
    public virtual DbSet<EmployeeLanguage> EmployeeLanguages { get; set; }
    public virtual DbSet<EmployeeRace> EmployeeRaces { get; set; }
    public virtual DbSet<EmployeeMaritalStatus> EmployeeMaritalStatuses { get; set; }
    public virtual DbSet<EmployeePayPeriod> EmployeePayPeriods { get; set; }
    public virtual DbSet<EmployeePayMethod> EmployeePayMethods { get; set; }
    public virtual DbSet<EmployeeUnion> EmployeeUnions { get; set; }
    public virtual DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }
    public virtual DbSet<EmployeeJobGrade> EmployeeJobGrades { get; set; }
    public virtual DbSet<DrivingCodes> DrivingCodes { get; set; }
    public virtual DbSet<LicenceCodes> LicenceCodes { get; set; }
    public virtual DbSet<EmployeeNationality> EmployeeNationalities { get; set; }
    public virtual DbSet<UserAccess> UserAccesses { get; set; }
    public virtual DbSet<Offence> Offences { get; set; }
    public virtual DbSet<BreachType> BreachTypes { get; set; }
    public virtual DbSet<OffenceBreach> OffenceBreaches { get; set; }
    public virtual DbSet<ServerPathConfig> ServerPathConfigs { get; set; }
    public virtual DbSet<EmailMessages> MailMessages { get; set; }

    public virtual DbSet<BusinessUnitDeptRoleLinking> BusinessUnitDeptRoleLinkings { get; set; }
    public virtual DbSet<EmployeeWorkRecord> EmployeeWorkRecords { get; set; }
    public virtual DbSet<AccessLinking> AccessLinks { get; set; }
    public virtual DbSet<CounsellingNotes> CounsellingNotes { get; set; }
    public virtual DbSet<LinkedDocuments> LinkedDocuments { get; set; }
    public virtual DbSet<FileTypes> FileTypes { get; set; }
    public virtual DbSet<Modules> Modules { get; set; } 

    public virtual DbSet<MessageToAdmin> MessagesToAdmin { get; set; }
    public virtual DbSet<RequestPassword> RequestPassword { get; set; }
    public virtual DbSet<AppealDiscipline> AppealDisciplines { get; set; }
    public virtual DbSet<GroundsOfAppeal> GroundsOfAppeals { get; set; }
    public virtual DbSet<AppealOutcomes> AppealOutcomes { get; set; }

    public virtual DbSet<DisciplineProcess> DisciplineProcesses { get; set; }
    public virtual DbSet<EmployeeInterest> EmployeeInterests { get; set; }
    public virtual DbSet<InterestStatus> InterestStatuses { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Data Source=YRKHUBSQLSRV.YORK.CO.ZA;User ID=CapexUser;Password=C@pex123User!;Connect Timeout=60;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\CapexLocal;Database=yrkCapexDB;Trusted_Connection=True;MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BusinessUnit>(entity =>
        {
            entity.HasOne(d => d.LegalEntity).WithMany(p => p.BusinessUnits).HasConstraintName("FK_BusinessUnit_LegalEntity");
        });

        modelBuilder.Entity<CapexForm>(entity =>
        {
            entity.HasOne(d => d.AssetCategory).WithMany(p => p.CapexForms).HasConstraintName("FK_CapexForm_AssetCategory");

            entity.HasOne(d => d.BalanceSheetCode).WithMany(p => p.CapexForms).HasConstraintName("FK_CapexForm_BalanceSheetCode");

            entity.HasOne(d => d.LocationCostCode).WithMany(p => p.CapexForms).HasConstraintName("FK_CapexForm_LocationCostCode");

            entity.HasOne(d => d.ProjectCategory).WithMany(p => p.CapexForms).HasConstraintName("FK_CapexForm_ProjectCategory");

            entity.HasOne(d => d.Site).WithMany(p => p.CapexForms).HasConstraintName("FK_CapexForm_Site");
        });

        modelBuilder.Entity<CapexUser>(entity =>
        {

            entity.HasOne(d => d.BusinessUnit).WithMany(p => p.CapexUsers).HasConstraintName("FK_CapexUser_BusinessUnit");

            entity.HasOne(d => d.Role).WithMany(p => p.CapexUsers).HasConstraintName("FK_CapexUser_Role");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasOne(d => d.FkCapex).WithMany(p => p.Comments).HasConstraintName("FK_Comments_CapexForm");
        });

        modelBuilder.Entity<FkAttachmentsCapex>(entity =>
        {
            entity.HasOne(d => d.FkAcAttachmentTypesNavigation).WithMany(p => p.FkAttachmentsCapexes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_fkAttachmentsCapex_AttachmentTypes");

            entity.HasOne(d => d.FkAcCapexFormNavigation).WithMany(p => p.FkAttachmentsCapexes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_fkAttachmentsCapex_CapexForm");
        });

        modelBuilder.Entity<FkKpicapex>(entity =>
        {
            entity.HasOne(d => d.FkKcCapexFormNavigation).WithMany(p => p.FkKpicapexes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_fkKPICapex_CapexForm");

            entity.HasOne(d => d.FkKcKpiNavigation).WithMany(p => p.FkKpicapexes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_fkKPICapex_KPI");
        });

        modelBuilder.Entity<FkSignatoriesCapex>(entity =>
        {
            entity.HasOne(d => d.FkScCapexFormNavigation).WithMany(p => p.FkSignatoriesCapexes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_fkSignatoriesCapex_CapexForm");

            entity.HasOne(d => d.FkScSignatory).WithMany(p => p.FkSignatoriesCapexes).HasConstraintName("FK_fkSignatoriesCapex_CapexUser");

            entity.HasOne(d => d.FkScSignatoryRole).WithMany(p => p.FkSignatoriesCapexes).HasConstraintName("FK_fkSignatoriesCapex_Role");
        });

        modelBuilder.Entity<Risk>(entity =>
        {
            entity.Property(e => e.ConsequenceClassification).IsFixedLength();
            entity.Property(e => e.LikelihoodClassification).IsFixedLength();

            entity.HasOne(d => d.FkCapex).WithMany(p => p.Risks).HasConstraintName("FK_Risks_CapexForm");
        });

        modelBuilder.Entity<Site>(entity =>
        {
            entity.HasOne(d => d.BusinessUnit).WithMany(p => p.Sites).HasConstraintName("FK_Site_BusinessUnit");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
