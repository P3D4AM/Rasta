using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductSpecificationMetadata))]
public class WSProductSpecification
{
	public int ProductSpecificationID { get; set; }

	public int PrdId { get; set; }

	public string Specification { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string SpecificationI { get; set; }

	public string SpecificationII { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? SpecificationCId { get; set; }

	public string SpecificationValue { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSProductSpecification_Lang> WSProductSpecification_Lang { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual WSProducts WSProducts { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSProductSpecification()
	{
		WSProductSpecification_Lang = (ICollection<WSProductSpecification_Lang>)new HashSet<WSProductSpecification_Lang>();
	}
}
