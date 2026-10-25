using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanyAddressTypeMetadata))]
public class CrmCompanyAddressType
{
	public int CompanyAddressTypeId { get; set; }

	public string CompanyAddressTypeName { get; set; }

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

	public virtual ICollection<CrmCompanyAddresses> CrmCompanyAddresses { get; set; }

	public virtual ICollection<CrmCompanyAddressType_Lang> CrmCompanyAddressType_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmCompanyAddressType()
	{
		CrmCompanyAddresses = (ICollection<CrmCompanyAddresses>)new HashSet<CrmCompanyAddresses>();
		CrmCompanyAddressType_Lang = (ICollection<CrmCompanyAddressType_Lang>)new HashSet<CrmCompanyAddressType_Lang>();
	}
}
