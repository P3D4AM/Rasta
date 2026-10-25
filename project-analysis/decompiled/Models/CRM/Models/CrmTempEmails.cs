using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmTempEmailsMetadata))]
public class CrmTempEmails
{
	public long ID { get; set; }

	public bool Selector { get; set; }

	public string Email { get; set; }

	public string Mobile { get; set; }

	public string CompanyName { get; set; }

	public string PersonName { get; set; }

	public string Phone { get; set; }

	public int CompanyId { get; set; }

	public int CompanyPersonId { get; set; }

	public int EmailLength { get; set; }

	public string EmailPartI { get; set; }

	public string EmailPartII { get; set; }

	public string EmailPartIII { get; set; }

	public int UserId { get; set; }

	public string cmpTitle { get; set; }

	public string cmpName { get; set; }

	public string PrsTitle { get; set; }

	public string PrsFName { get; set; }

	public string PrsLName { get; set; }

	public string PrsJob { get; set; }

	public string Subject { get; set; }

	public string Body { get; set; }

	public string BodyLangType { get; set; }

	public int? prsRegisterUserId { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? EmailSystemPartId { get; set; }

	public long? EmailObjectId { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual CrmCompanyPersons CrmCompanyPersons { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual CrmSystemParts CrmSystemParts { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }
}
