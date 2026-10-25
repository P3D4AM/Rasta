using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CityMetadata))]
public class City
{
	public int CityID { get; set; }

	public int ProvinceId { get; set; }

	public string CityCode { get; set; }

	public string City1 { get; set; }

	public string Description { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? FirstUserId { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public string LinkAccCityIdStr { get; set; }

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public string LinkAccData { get; set; }

	public virtual ICollection<City_Lang> City_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Province Province { get; set; }

	public virtual ICollection<CrmCompanyForbiddenCity> CrmCompanyForbiddenCity { get; set; }

	public virtual ICollection<CrmCompanyJustAccessCity> CrmCompanyJustAccessCity { get; set; }

	public virtual ICollection<CrmCompanyPersons> CrmCompanyPersons { get; set; }

	public virtual ICollection<CrmCompanyPersonsTemplate> CrmCompanyPersonsTemplate { get; set; }

	public virtual ICollection<CrmCompanyAddresses> CrmCompanyAddresses { get; set; }

	public virtual ICollection<CrmLeave> CrmLeave { get; set; }

	public virtual ICollection<TspSetting> TspSetting { get; set; }

	public virtual ICollection<CrmsysSetting> CrmsysSetting { get; set; }

	public virtual ICollection<CrmCompany> CrmCompany { get; set; }

	public virtual ICollection<CrmCompany> CrmCompany1 { get; set; }

	public virtual ICollection<CrmCompanyQuickRegisterDefSetting> CrmCompanyQuickRegisterDefSetting { get; set; }

	public virtual ICollection<CrmCompanyQuickRegisterDefSetting> CrmCompanyQuickRegisterDefSetting1 { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public City()
	{
		City_Lang = (ICollection<City_Lang>)new HashSet<City_Lang>();
		CrmCompanyForbiddenCity = (ICollection<CrmCompanyForbiddenCity>)new HashSet<CrmCompanyForbiddenCity>();
		CrmCompanyJustAccessCity = (ICollection<CrmCompanyJustAccessCity>)new HashSet<CrmCompanyJustAccessCity>();
		CrmCompanyPersons = (ICollection<CrmCompanyPersons>)new HashSet<CrmCompanyPersons>();
		CrmCompanyPersonsTemplate = (ICollection<CrmCompanyPersonsTemplate>)new HashSet<CrmCompanyPersonsTemplate>();
		CrmCompanyAddresses = (ICollection<CrmCompanyAddresses>)new HashSet<CrmCompanyAddresses>();
		CrmLeave = (ICollection<CrmLeave>)new HashSet<CrmLeave>();
		TspSetting = (ICollection<TspSetting>)new HashSet<TspSetting>();
		CrmsysSetting = (ICollection<CrmsysSetting>)new HashSet<CrmsysSetting>();
		CrmCompany = (ICollection<CrmCompany>)new HashSet<CrmCompany>();
		CrmCompany1 = (ICollection<CrmCompany>)new HashSet<CrmCompany>();
		CrmCompanyQuickRegisterDefSetting = (ICollection<CrmCompanyQuickRegisterDefSetting>)new HashSet<CrmCompanyQuickRegisterDefSetting>();
		CrmCompanyQuickRegisterDefSetting1 = (ICollection<CrmCompanyQuickRegisterDefSetting>)new HashSet<CrmCompanyQuickRegisterDefSetting>();
	}
}
