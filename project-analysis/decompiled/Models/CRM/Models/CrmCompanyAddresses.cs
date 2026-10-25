using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanyAddressesMetadata))]
public class CrmCompanyAddresses
{
	public int CompanyAddressId { get; set; }

	public int cmpaddCompanyId { get; set; }

	public int? cmpaddCityId { get; set; }

	public string CompanyAddress { get; set; }

	public string cmpaddDesc { get; set; }

	public string cmpaddZipCode { get; set; }

	public string cmpaddPostBox { get; set; }

	public string cmpaddCoordinateLatitude { get; set; }

	public string cmpaddCoordinateLongitude { get; set; }

	public DateTime? cmpaddCoordinateLastDate { get; set; }

	public string cmpaddCoordinateLastDatePersian { get; set; }

	public int? cmpaddCoordinateZoomLevel { get; set; }

	public int? cmpaddCoordinateLastUserId { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public int? cmpaddTypeId { get; set; }

	public virtual City City { get; set; }

	public virtual ICollection<CrmCompanyAddresses_Lang> CrmCompanyAddresses_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual CrmCompanyAddressType CrmCompanyAddressType { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmCompanyAddresses()
	{
		CrmCompanyAddresses_Lang = (ICollection<CrmCompanyAddresses_Lang>)new HashSet<CrmCompanyAddresses_Lang>();
	}
}
