using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSDocOprMetadata))]
public class WSDocOpr
{
	public int DocOprID { get; set; }

	public string Name { get; set; }

	public Guid? GUId { get; set; }

	public int? OprType { get; set; }

	public int? OrderView { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? UserId { get; set; }

	public int? FPId { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSDocOpr_Lang> WSDocOpr_Lang { get; set; }

	public virtual ICollection<WSOrderOpr> WSOrderOpr { get; set; }

	public virtual ICollection<WSDoc> WSDoc { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSDocOpr()
	{
		WSDocOpr_Lang = (ICollection<WSDocOpr_Lang>)new HashSet<WSDocOpr_Lang>();
		WSOrderOpr = (ICollection<WSOrderOpr>)new HashSet<WSOrderOpr>();
		WSDoc = (ICollection<WSDoc>)new HashSet<WSDoc>();
	}
}
