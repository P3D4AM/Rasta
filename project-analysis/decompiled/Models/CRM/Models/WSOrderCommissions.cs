using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSOrderCommissionsMetadata))]
public class WSOrderCommissions
{
	public int OrderCommissionId { get; set; }

	public DateTime CommDateTime { get; set; }

	public string CommDatePersian { get; set; }

	public int CommOrderId { get; set; }

	public int CommCmpId { get; set; }

	public int? CommUserId { get; set; }

	public decimal? CommBaseAmountDec { get; set; }

	public string CommBaseAmountDecDesc { get; set; }

	public decimal CommBaseAmount { get; set; }

	public double? CommRate { get; set; }

	public string CommRateDesc { get; set; }

	public decimal CommAmount { get; set; }

	public DateTime? CommEffectiveDateTime { get; set; }

	public string CommEffectiveDatePersian { get; set; }

	public int? CommPayTypeId { get; set; }

	public int? CommStatusId { get; set; }

	public string CommDesc { get; set; }

	public bool? CommIsVerified { get; set; }

	public int? CommVerifierUserId { get; set; }

	public DateTime? CommVerifiedDateTime { get; set; }

	public string CommVerifiedDatePersian { get; set; }

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

	public bool? CommIsPaid { get; set; }

	public int? CommIsPaidUserId { get; set; }

	public DateTime? CommIsPaidDateTime { get; set; }

	public string CommIsPaidDatePersian { get; set; }

	public int? CommIsPaidPayRollUserCycleId { get; set; }

	public int? CommAmountCurrUnId { get; set; }

	public double? CommAmountCurrencyRate { get; set; }

	public int? PreOrderCommissionId { get; set; }

	public decimal? CommBaseAmountDecPercent { get; set; }

	public int? CommIsPaidPayRollUserCycleItemValueId { get; set; }

	public int? CommTypeId { get; set; }

	public int? CommKindId { get; set; }

	public int? CommTypeCmpId { get; set; }

	public int? CommTypePrsId { get; set; }

	public int? CommCId { get; set; }

	public string CommLinkAccData { get; set; }

	public bool? CommIsPreVerified { get; set; }

	public int? CommPreVerifierUserId { get; set; }

	public DateTime? CommPreVerifiedDate { get; set; }

	public string CommPreVerifiedDatePersian { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual CrmCompany CrmCompany1 { get; set; }

	public virtual CrmCompanyPersons CrmCompanyPersons { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual PayRollUserCycle PayRollUserCycle { get; set; }

	public virtual PayRollUserCycleItemValues PayRollUserCycleItemValues { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits { get; set; }

	public virtual WSOrderCommissionPayTypes WSOrderCommissionPayTypes { get; set; }

	public virtual ICollection<WSOrderCommissions_Lang> WSOrderCommissions_Lang { get; set; }

	public virtual WSPreOrderCommissions WSPreOrderCommissions { get; set; }

	public virtual WSOrder WSOrder { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public virtual Users Users4 { get; set; }

	public virtual Users Users5 { get; set; }

	public WSOrderCommissions()
	{
		WSOrderCommissions_Lang = (ICollection<WSOrderCommissions_Lang>)new HashSet<WSOrderCommissions_Lang>();
	}
}
