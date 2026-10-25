using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSOrderOprMetadata))]
public class WSOrderOpr
{
	public int OrderOprID { get; set; }

	public string Name { get; set; }

	public Guid? GUId { get; set; }

	public int? OprType { get; set; }

	public int? OrderView { get; set; }

	public int? DocOprId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string LinkAccOrderOprIdStr { get; set; }

	public long? DailyCounter { get; set; }

	public int? TspInty { get; set; }

	public int? TspInp { get; set; }

	public int? TspIns { get; set; }

	public bool? VerifyAfterIssue { get; set; }

	public int? TspIntyI { get; set; }

	public int? TspInpI { get; set; }

	public int? TspInsI { get; set; }

	public bool? Taxable { get; set; }

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public string LinkAccData { get; set; }

	public bool? IssueOrdWithoutPordDisc { get; set; }

	public bool? TspSendOrdWithoutDisc { get; set; }

	public int? UserId { get; set; }

	public int? FPId { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSDocOpr WSDocOpr { get; set; }

	public virtual ICollection<WSOrderOpr_Lang> WSOrderOpr_Lang { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting { get; set; }

	public virtual ICollection<WSProducts> WSProducts { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSOrderDefaultSetting> WSOrderDefaultSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSOrderOpr()
	{
		WSOrderOpr_Lang = (ICollection<WSOrderOpr_Lang>)new HashSet<WSOrderOpr_Lang>();
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
		CrmFoSetting = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmMobSetting = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		WSProducts = (ICollection<WSProducts>)new HashSet<WSProducts>();
		WSOrderDefaultSetting = (ICollection<WSOrderDefaultSetting>)new HashSet<WSOrderDefaultSetting>();
	}
}
