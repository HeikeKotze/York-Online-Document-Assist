using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YODA.Repos.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [Column("EmployeeID")]
        public int EmployeeID { get; set; }
        [Column("EmployeeNumber")]
        public string? EmployeeNumber { get; set; }
        [Column("CompanyNumberID")]
        public int CompanyNumberID { get; set; }
        [Column("RoleID")]
        public int RoleID { get; set; }

        [Column("TitleID")]
        public int? TitleID { get; set; }
        [Column("Surname")]
        public string? Surname { get; set; }
        [Column("FirstName")]
        public string? FirstName { get; set; }
        [Column("MiddleNames")]
        public string? MiddleNames { get; set; }
        [Column("FullName")]
        public string? FullName { get; set; }
        [Column("PreferedName")]
        public string? PreferedName { get; set; }
        [Column("IDNumber")]
        public string? IDNumber { get; set; }
        [Column("PassportNumber")]
        public string? PassportNumber { get; set; }
        [Column("GenderID")]
        public int? GenderID { get; set; }
        [Column("RaceID")]
        public int? RaceID { get; set; }
        [Column("HomePhoneNo")]
        public string? HomePhoneNo { get; set; }
        [Column("WorkPhoneNo")]
        public string? WorkPhoneNo { get; set; }
        [Column("CellNo")]
        public string? CellNo { get; set; }
        [Column("PostalAddress")]
        public string? PostalAddress { get; set; }
        [Column("PostalCode")]
        public int? PostalCode { get; set; }
        [Column("ResidentialAddress")]
        public string? ResidentialAddress { get; set; }
        [Column("ResidentialCode")]
        public int? ResidentialCode { get; set; }
        [Column("NationalityID")]
        public int? NationalityID { get; set; }
        [Column("Accomodation")]
        public string? Accomodation { get; set; }
        [Column("DrivingLicenceCodes")]
        public string? DrivingLicenceCodes { get; set; }
        [Column("DateEngaged")]
        public DateTime? DateEngaged { get; set; } = DateTime.Now;
        [Column("DateJoinedGroup")]
        public DateTime? DateJoinedGroup { get; set; } = DateTime.Now;
        [Column("DateOfBirth")]
        public DateTime? DateOfBirth { get; set; } = DateTime.Now;
        [Column("TaxStatus")]
        public string? TaxStatus { get; set; }
        [Column("BreadWinner")]
        public string? BreadWinner { get; set; }
        [Column("Dependants")]
        public string? Dependants { get; set; }
        [Column("PensionScheme")]
        public string? PensionScheme { get; set; }
        [Column("MedicalAidDependants")]
        public string? MedicalAidDependants { get; set; }
        [Column("PayPeriodID")]
        public int? PayPeriodID { get; set; }
        [Column("CostCode")]
        public string? CostCode { get; set; }
        [Column("DepartmentID")]
        public int DepartmentID { get; set; }
        [Column("PayMethodID")]
        public int? PayMethodID { get; set; }
        [Column("Bank")]
        public string? Bank { get; set; }
        [Column("Branch")]
        public string? Branch { get; set; }
        [Column("AccountNumber")]
        public string? AccountNumber { get; set; }
        [Column("TaxReferenceNumber")]
        public string? TaxReferenceNumber { get; set; }
        [Column("RevenueOfficer")]
        public string? RevenueOfficer { get; set; }
        [Column("JobGradeID")]
        public int? JobGradeID { get; set; }
        [Column("DateToJobGrade")]
        public DateTime? DateToJobGrade { get; set; } = DateTime.Now;
        [Column("JobTitle")]
        public string? JobTitle { get; set; }
        [Column("JobCategory")]
        public string? JobCategory { get; set; }
        [Column("ShiftEmployee")]
        public string? ShiftEmployee { get; set; }
        [Column("HourlyPayRate")]
        public string? HourlyPayRate { get; set; }
        [Column("MonthlyPayRate")]
        public string? MonthlyPayRate { get; set; }
        [Column("BonusAmount")]
        public string? BonusAmount { get; set; }
        [Column("NormalWeeklyHours")]
        public int? NormalWeeklyHours { get; set; }
        [Column("DaysPerWeek")]
        public int? DaysPerWeek { get; set; }
        [Column("AnnualEntitlement")]
        public string? AnnualEntitlement { get; set; }
        [Column("MonthlyAccrual")]
        public string? MonthlyAccrual { get; set; }
        [Column("Accumalative")]
        public string? Accumalative { get; set; }
        [Column("NonAccumalative")]
        public string? NonAccumalative { get; set; }
        [Column("SickLeaveCycle")]
        public int? SickLeaveCycle { get; set; }
        [Column("MonthlySickLeaveAccrual")]
        public int? MonthlySickLeaveAccrual { get; set; }
        [Column("DateOfMarriage")]
        public DateTime? DateOfMarriage { get; set; } = DateTime.Now;
        [Column("MaidenName")]
        public string? MaidenName { get; set; }
        [Column("SpouseName")]
        public string? SpouseName { get; set; }
        [Column("NameOfEmergencyContact")]
        public string? NameOfEmergencyContact { get; set; }
        [Column("HomeNumberEmergencyContact")]
        public string? HomeNumberEmergencyContact { get; set; }
        [Column("WorkNumberEmergencyContact")]
        public string? WorkNumberEmergencyContact { get; set; }
        [Column("AddressEmergencyContact")]
        public string? AddressEmergencyContact { get; set; }
        [Column("AddressCodeEmergencyContact")]
        public int? AddressCodeEmergencyContact { get; set; }
        [Column("SurnameNextOfKin")]
        public string? SurnameNextOfKin { get; set; }
        [Column("FirstNameNextOfKin")]
        public string? FirstNameNextOfKin { get; set; }
        [Column("HomeNumberNextOfKin")]
        public string? HomeNumberNextOfKin { get; set; }
        [Column("WorkNumberNextOfKin")]
        public string? WorkNumberNextOfKin { get; set; }
        [Column("AddressNextOfKin")]
        public string? AddressNextOfKin { get; set; }
        [Column("AddressCodeNextOfKin")]
        public int? AddressCodeNextOfKin { get; set; }
        [Column("UnionID")]
        public int? UnionID { get; set; }
        [Column("MembershipNumberUnion")]
        public string? MembershipNumberUnion { get; set; }
        [Column("DateJoinedUnion")]
        public DateTime? DateJoinedUnion { get; set; } = DateTime.Now;
        [Column("MonthlySubscriptionUnion")]
        public string? MonthlySubscriptionUnion { get; set; }
        [Column("SportHobbiesInterests")]
        public string? SportHobbiesInterests { get; set; }
        [Column("Allergies")]
        public string? Allergies { get; set; }
        [Column("Disabilities")]
        public string? Disabilities { get; set; }
        [Column("BloodGroup")]
        public string? BloodGroup { get; set; }
        [Column("DoctorName")]
        public string? DoctorName { get; set; }
        [Column("DoctorTelephoneNumber")]
        public string? DoctorTelephoneNumber { get; set; }
        [Column("StateOfHealth")]
        public string? StateOfHealth { get; set; }
        [Column("PreEmploymentExamination")]
        public DateTime? PreEmploymentExamination { get; set; }
        [Column("PensionPercentageOfCTC")]
        public string? PensionPercentageOfCTC { get; set; }
        [Column("PensionPercentageOfROL")]
        public string? PensionPercentageOfROL { get; set; }
        [Column("Children")]
        public int? Children { get;set; }
        [Column("PlaceOfBirth")]
        public string? PlaceOfBirth { get; set; }
        [Column("HomeLanguageID")]
        public int? HomeLanguageID { get; set; }
        [Column("MaritalStatusID")]
        public int? MaritalStatusID { get; set; }
        [Column("MedicalAid")]
        public string? MedicalAid { get; set; }
        [Column("MedicalAidNumber")]
        public string? MedicalAidNumber { get; set; }
        [Column("IDCopyName")]
        public string? IDCopyName { get; set; }
        [Column("IDCopyPath")]
        public string? IDCopyPath { get;set; }
        [Column("EmailAddress")]
        public string? EmailAddress { get; set; }
        [Column("DriversCopyName")]
        public string? DriversCopyName { get; set; }
        [Column("DriversCopyPath")]
        public string? DriversCopyPath { get; set; }
        [Column("BankStatementsName")]
        public string? BankStatementsName { get; set; }
        [Column("BankStatementsPath")]
        public string? BankStatementsPath { get; set; }
        [Column("ContractName")]
        public string? ContractName { get; set; }
        [Column("ContractPath")]
        public string? ContractPath { get; set; }
        [Column("RecStatus")]
        public short? RecStatus { get; set; }
        [Column("POPISignature")]
        public short? POPISignature { get; set; }
        [Column("POPISignDate")]
        public DateTime? POPISignDate { get; set; }
        [Column("AnnualDeclarationSignature")]
        public short? AnnualDeclarationSignature { get; set; }
        [Column("AnnualDeclarationSignDate")]
        public DateTime? AnnualDeclarationSignDate { get; set; }
        [Column("OtherDocsSignature")]
        public short? OtherDocsSignature { get; set; }
        [Column("OtherDocsSignDate")]
        public DateTime? OtherDocsSignDate { get; set; }
        
        [NotMapped]
        public string? LanguageName { get; set; }
        [NotMapped]
        public string? TitleName { get; set; }
        [NotMapped]
        public string? GenderName { get; set; }
        [NotMapped]
        public string? RaceName { get; set; }
        [NotMapped]
        public string? NationalityName { get; set; }
        [NotMapped]
        public string? PayPeriodName { get; set; }
        [NotMapped]
        public string? DepartmentName { get; set; }
        [NotMapped]
        public string? PayMethodName { get; set; }
        [NotMapped]
        public string? JobGradeName { get; set; }
        [NotMapped]
        public string? UnionName { get; set; }
        [NotMapped]
        public string? MaritalStatusName { get; set; }
        [NotMapped]
        public string? CompanyNumberName { get; set; }
        [NotMapped]
        public string? RoleName { get; set;}
        [NotMapped]
        public DateTime? SignDate { get; set; }
        [NotMapped]
        public string? SignDateString { get; set; }

    }
}
