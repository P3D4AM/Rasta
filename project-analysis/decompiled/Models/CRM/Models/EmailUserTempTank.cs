using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(EmailUserTempTankMetadata))]
public class EmailUserTempTank
{
	public long EmailUserTempTankId { get; set; }

	public int UserId { get; set; }

	public string EmailAddress { get; set; }

	public int? EmailCmpId { get; set; }

	public int? EmailCmpPrsId { get; set; }

	public string EmailCmpPrsName { get; set; }

	public int? EmailCmpPrjId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string FilePath { get; set; }

	public string FilePathII { get; set; }

	public string FilePathIII { get; set; }

	public string FilePathIV { get; set; }

	public string FilePathV { get; set; }

	public string EmailCmpName { get; set; }

	public string EmailPrsJob { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? EmailSystemPartId { get; set; }

	public long? EmailObjectId { get; set; }

	public virtual CrmCompanyPersons CrmCompanyPersons { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual CrmSystemParts CrmSystemParts { get; set; }

	public virtual CrmProjects CrmProjects { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }
}
