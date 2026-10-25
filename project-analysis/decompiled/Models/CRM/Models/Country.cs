using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CountryMetadata))]
public class Country
{
	public int CountryID { get; set; }

	public string CountryCode { get; set; }

	public string Country1 { get; set; }

	public string CountryDescription { get; set; }

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

	public string LinkAccCountryIdStr { get; set; }

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public string LinkAccData { get; set; }

	public virtual ICollection<Country_Lang> Country_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmCompanyPersons> CrmCompanyPersons { get; set; }

	public virtual ICollection<CrmCompanyPersonsTemplate> CrmCompanyPersonsTemplate { get; set; }

	public virtual ICollection<Province> Province { get; set; }

	public virtual ICollection<CrmLeave> CrmLeave { get; set; }

	public virtual ICollection<CrmCompany> CrmCompany { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public Country()
	{
		Country_Lang = (ICollection<Country_Lang>)new HashSet<Country_Lang>();
		CrmCompanyPersons = (ICollection<CrmCompanyPersons>)new HashSet<CrmCompanyPersons>();
		CrmCompanyPersonsTemplate = (ICollection<CrmCompanyPersonsTemplate>)new HashSet<CrmCompanyPersonsTemplate>();
		Province = (ICollection<Province>)new HashSet<Province>();
		CrmLeave = (ICollection<CrmLeave>)new HashSet<CrmLeave>();
		CrmCompany = (ICollection<CrmCompany>)new HashSet<CrmCompany>();
	}
}
