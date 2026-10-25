using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanyGroupsMultiMetadata))]
public class CrmCompanyGroupsMulti
{
	public int CompanyGroupsMultiID { get; set; }

	public string CompanyGroupsMultiName { get; set; }

	public string CompanyGroupsMultiDesc { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? OrderView { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string LinkAccGroupMultiIdStr { get; set; }

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public string LinkAccData { get; set; }

	public virtual ICollection<CrmCompanyGroupsMulti_Lang> CrmCompanyGroupsMulti_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmCompanyMultiGroups> CrmCompanyMultiGroups { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmCompanyGroupsMulti()
	{
		CrmCompanyGroupsMulti_Lang = (ICollection<CrmCompanyGroupsMulti_Lang>)new HashSet<CrmCompanyGroupsMulti_Lang>();
		CrmCompanyMultiGroups = (ICollection<CrmCompanyMultiGroups>)new HashSet<CrmCompanyMultiGroups>();
	}
}
