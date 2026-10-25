using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanyPersonsTemplateMetadata))]
public class CrmCompanyPersonsTemplate
{
	public int CompanyPersonTemplateID { get; set; }

	public string prsLName { get; set; }

	public string prsFName { get; set; }

	public int? prsTitleId { get; set; }

	public int? prsJobId { get; set; }

	public int? prsTypeId { get; set; }

	public int? prsGroupId { get; set; }

	public int? prsSexId { get; set; }

	public int? prsEducationId { get; set; }

	public string prsPreTel { get; set; }

	public string prsTel { get; set; }

	public string prsTelUpTo { get; set; }

	public string prsTelDesc { get; set; }

	public string prsTelII { get; set; }

	public string prsFax { get; set; }

	public string prsFaxDesc { get; set; }

	public string prsMobile { get; set; }

	public string prsWebSite { get; set; }

	public string prsEmail { get; set; }

	public string prsEmailII { get; set; }

	public int? prsCountryId { get; set; }

	public int? prsProvinceId { get; set; }

	public int? prsCityId { get; set; }

	public string prsAddress { get; set; }

	public string prsAddressDesc { get; set; }

	public string prsZipCode { get; set; }

	public string prsPostBox { get; set; }

	public string prsNationalCode { get; set; }

	public string prsIdentityNumber { get; set; }

	public string prsFatherName { get; set; }

	public string prsBirthDate { get; set; }

	public string prsBirthPlace { get; set; }

	public bool? prsIsMarried { get; set; }

	public string prsMarriageDate { get; set; }

	public string prsEducationField { get; set; }

	public string prsSkill { get; set; }

	public string prsStudyField { get; set; }

	public string prsInteresting { get; set; }

	public string prsSpecialPoint { get; set; }

	public string prsDescription { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int AddType { get; set; }

	public string ImportDate { get; set; }

	public int? prsFirstRegisterUserId { get; set; }

	public int? prsDepartmentId { get; set; }

	public bool? prsStopSendSms { get; set; }

	public int? prsOrderView { get; set; }

	public bool? prsWorkingOut { get; set; }

	public bool? Selector { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public DateTime? FirstRegisterDateTime { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? prsMarriageDateTime { get; set; }

	public DateTime? prsBirthDateTime { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual City City { get; set; }

	public virtual Country Country { get; set; }

	public virtual ICollection<CrmCompanyPersons> CrmCompanyPersons { get; set; }

	public virtual CrmPersonDepartments CrmPersonDepartments { get; set; }

	public virtual CrmPersonGroups CrmPersonGroups { get; set; }

	public virtual CrmPersonJobs CrmPersonJobs { get; set; }

	public virtual CrmPersonTitle CrmPersonTitle { get; set; }

	public virtual CrmPersonType CrmPersonType { get; set; }

	public virtual Education Education { get; set; }

	public virtual ICollection<CrmCompanyPersonsTemplate_Lang> CrmCompanyPersonsTemplate_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Province Province { get; set; }

	public virtual Sex Sex { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public CrmCompanyPersonsTemplate()
	{
		CrmCompanyPersons = (ICollection<CrmCompanyPersons>)new HashSet<CrmCompanyPersons>();
		CrmCompanyPersonsTemplate_Lang = (ICollection<CrmCompanyPersonsTemplate_Lang>)new HashSet<CrmCompanyPersonsTemplate_Lang>();
	}
}
