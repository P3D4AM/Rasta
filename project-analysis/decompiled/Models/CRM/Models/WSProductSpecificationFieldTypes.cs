using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductSpecificationFieldTypesMetadata))]
public class WSProductSpecificationFieldTypes
{
	public int SpecificationFieldTypeID { get; set; }

	public string TypeName { get; set; }

	public string TypeInWeb { get; set; }

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

	public virtual Languages Languages { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSProductSpecificationFieldTypes_Lang> WSProductSpecificationFieldTypes_Lang { get; set; }

	public virtual ICollection<WSProductSpecificationFields> WSProductSpecificationFields { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSProductSpecificationFieldTypes()
	{
		WSProductSpecificationFieldTypes_Lang = (ICollection<WSProductSpecificationFieldTypes_Lang>)new HashSet<WSProductSpecificationFieldTypes_Lang>();
		WSProductSpecificationFields = (ICollection<WSProductSpecificationFields>)new HashSet<WSProductSpecificationFields>();
	}
}
