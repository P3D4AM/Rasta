using System;

namespace CRM.Models;

public class CrmTempEmailsMetadata
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
}
