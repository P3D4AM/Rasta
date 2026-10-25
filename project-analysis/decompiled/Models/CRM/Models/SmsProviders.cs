using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(SmsProvidersMetadata))]
public class SmsProviders
{
	public int Id { get; set; }

	public int ProviderIdentity { get; set; }

	public string ProviderName { get; set; }

	public string ProviderDomain { get; set; }

	public string ProviderUrl { get; set; }

	public string UserName { get; set; }

	public string Password { get; set; }

	public string Number { get; set; }

	public decimal? EnCost { get; set; }

	public decimal? FaCost { get; set; }

	public bool? SendIsActive { get; set; }

	public bool? ReceiveIsActive { get; set; }

	public decimal? LastCreditAmount { get; set; }

	public bool? IsActive { get; set; }

	public bool? IsDefault { get; set; }

	public int? OrderView { get; set; }

	public string Description { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string TokenUserName { get; set; }

	public string SmsCustomer { get; set; }

	public virtual ICollection<CrmSurveySendSetting> CrmSurveySendSetting { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<SmsSetting> SmsSetting { get; set; }

	public virtual ICollection<SmsSendHeader> SmsSendHeader { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting1 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting11 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting3 { get; set; }

	public virtual ICollection<CrmConversationStatus> CrmConversationStatus { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public SmsProviders()
	{
		CrmSurveySendSetting = (ICollection<CrmSurveySendSetting>)new HashSet<CrmSurveySendSetting>();
		SmsSetting = (ICollection<SmsSetting>)new HashSet<SmsSetting>();
		SmsSendHeader = (ICollection<SmsSendHeader>)new HashSet<SmsSendHeader>();
		CrmFoSetting = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting1 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting11 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting3 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmConversationStatus = (ICollection<CrmConversationStatus>)new HashSet<CrmConversationStatus>();
	}
}
