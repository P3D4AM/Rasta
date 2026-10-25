using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(ProvinceMetadata))]
public class Province
{
	public int ProvinceID { get; set; }

	public int CountryId { get; set; }

	public string ProvinceCode { get; set; }

	public string Province1 { get; set; }

	public string Description { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string LinkAccProvinceIdStr { get; set; }

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public string LinkAccData { get; set; }

	public virtual ICollection<City> City { get; set; }

	public virtual Country Country { get; set; }

	public virtual ICollection<CrmCompanyForbiddenProvince> CrmCompanyForbiddenProvince { get; set; }

	public virtual ICollection<CrmCompanyJustAccessProvince> CrmCompanyJustAccessProvince { get; set; }

	public virtual ICollection<CrmCompanyPersons> CrmCompanyPersons { get; set; }

	public virtual ICollection<CrmCompanyPersonsTemplate> CrmCompanyPersonsTemplate { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<Province_Lang> Province_Lang { get; set; }

	public virtual ICollection<CrmLeave> CrmLeave { get; set; }

	public virtual ICollection<CrmCompany> CrmCompany { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public Province()
	{
		City = (ICollection<City>)new HashSet<City>();
		CrmCompanyForbiddenProvince = (ICollection<CrmCompanyForbiddenProvince>)new HashSet<CrmCompanyForbiddenProvince>();
		CrmCompanyJustAccessProvince = (ICollection<CrmCompanyJustAccessProvince>)new HashSet<CrmCompanyJustAccessProvince>();
		CrmCompanyPersons = (ICollection<CrmCompanyPersons>)new HashSet<CrmCompanyPersons>();
		CrmCompanyPersonsTemplate = (ICollection<CrmCompanyPersonsTemplate>)new HashSet<CrmCompanyPersonsTemplate>();
		Province_Lang = (ICollection<Province_Lang>)new HashSet<Province_Lang>();
		CrmLeave = (ICollection<CrmLeave>)new HashSet<CrmLeave>();
		CrmCompany = (ICollection<CrmCompany>)new HashSet<CrmCompany>();
	}
}
