using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(SexMetadata))]
public class Sex
{
	public int SexID { get; set; }

	public string SexType { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual ICollection<CrmCompanyPersons> CrmCompanyPersons { get; set; }

	public virtual ICollection<CrmCompanyPersonsTemplate> CrmCompanyPersonsTemplate { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<Sex_Lang> Sex_Lang { get; set; }

	public virtual ICollection<CrmCompanyQuickRegisterDefSetting> CrmCompanyQuickRegisterDefSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public Sex()
	{
		CrmCompanyPersons = (ICollection<CrmCompanyPersons>)new HashSet<CrmCompanyPersons>();
		CrmCompanyPersonsTemplate = (ICollection<CrmCompanyPersonsTemplate>)new HashSet<CrmCompanyPersonsTemplate>();
		Sex_Lang = (ICollection<Sex_Lang>)new HashSet<Sex_Lang>();
		CrmCompanyQuickRegisterDefSetting = (ICollection<CrmCompanyQuickRegisterDefSetting>)new HashSet<CrmCompanyQuickRegisterDefSetting>();
	}
}
