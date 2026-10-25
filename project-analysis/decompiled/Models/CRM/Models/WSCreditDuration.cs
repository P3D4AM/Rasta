using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSCreditDurationMetadata))]
public class WSCreditDuration
{
	public int CreditDurationID { get; set; }

	public string CreditDuration { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

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

	public int? CreditDurationHours { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSCreditDuration_Lang> WSCreditDuration_Lang { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting { get; set; }

	public virtual ICollection<WSPreOrderDefaultSetting> WSPreOrderDefaultSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSCreditDuration()
	{
		WSCreditDuration_Lang = (ICollection<WSCreditDuration_Lang>)new HashSet<WSCreditDuration_Lang>();
		WSPreOrder = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		CrmMobSetting = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmFoSetting = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		WSPreOrderDefaultSetting = (ICollection<WSPreOrderDefaultSetting>)new HashSet<WSPreOrderDefaultSetting>();
	}
}
