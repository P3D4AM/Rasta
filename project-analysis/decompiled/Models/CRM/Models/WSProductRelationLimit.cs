using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductRelationLimitMetadata))]
public class WSProductRelationLimit
{
	public int ProductRelationLimitId { get; set; }

	public int ProductRelationTypeId { get; set; }

	public int ObjectId { get; set; }

	public int PrdId { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual WSProductRelationType WSProductRelationType { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }
}
