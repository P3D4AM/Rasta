using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductSpecificationFieldGroupsMetadata))]
public class WSProductSpecificationFieldGroups
{
	public int SpecificationFieldGroupID { get; set; }

	public string FieldGroupTitle { get; set; }

	public bool? FieldGroupInActive { get; set; }

	public int? OrderView { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int? UserId { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public int? FPId { get; set; }

	public short? Month1 { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FieldGroupCId { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSProductSpecificationFieldGroups_Lang> WSProductSpecificationFieldGroups_Lang { get; set; }

	public virtual ICollection<WSProductSpecificationFields> WSProductSpecificationFields { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSProductSpecificationFieldGroups()
	{
		WSProductSpecificationFieldGroups_Lang = (ICollection<WSProductSpecificationFieldGroups_Lang>)new HashSet<WSProductSpecificationFieldGroups_Lang>();
		WSProductSpecificationFields = (ICollection<WSProductSpecificationFields>)new HashSet<WSProductSpecificationFields>();
	}
}
