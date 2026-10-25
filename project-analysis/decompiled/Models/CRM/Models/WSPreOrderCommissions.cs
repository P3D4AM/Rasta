using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSPreOrderCommissionsMetadata))]
public class WSPreOrderCommissions
{
	public int PreOrderCommissionId { get; set; }

	public DateTime CommDateTime { get; set; }

	public string CommDatePersian { get; set; }

	public int CommPreOrderId { get; set; }

	public int CommCmpId { get; set; }

	public int CommUserId { get; set; }

	public decimal? CommBaseAmountDec { get; set; }

	public string CommBaseAmountDecDesc { get; set; }

	public decimal CommBaseAmount { get; set; }

	public double? CommRate { get; set; }

	public string CommRateDesc { get; set; }

	public decimal CommAmount { get; set; }

	public int? CommAmountCurrUnId { get; set; }

	public double? CommAmountCurrencyRate { get; set; }

	public DateTime? CommEffectiveDateTime { get; set; }

	public string CommEffectiveDatePersian { get; set; }

	public int? CommPayTypeId { get; set; }

	public int? CommStatusId { get; set; }

	public string CommDesc { get; set; }

	public bool? CommIsVerified { get; set; }

	public int? CommVerifierUserId { get; set; }

	public DateTime? CommVerifiedDateTime { get; set; }

	public string CommVerifiedDatePersian { get; set; }

	public bool? CommIsPaid { get; set; }

	public int? CommIsPaidUserId { get; set; }

	public DateTime? CommIsPaidDateTime { get; set; }

	public string CommIsPaidDatePersian { get; set; }

	public int? CommIsPaidPayRollUserCycleId { get; set; }

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

	public int? CommCId { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual PayRollUserCycle PayRollUserCycle { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits { get; set; }

	public virtual WSOrderCommissionPayTypes WSOrderCommissionPayTypes { get; set; }

	public virtual ICollection<WSPreOrderCommissions_Lang> WSPreOrderCommissions_Lang { get; set; }

	public virtual WSPreOrder WSPreOrder { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual ICollection<WSOrderCommissions> WSOrderCommissions { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public virtual Users Users4 { get; set; }

	public WSPreOrderCommissions()
	{
		WSPreOrderCommissions_Lang = (ICollection<WSPreOrderCommissions_Lang>)new HashSet<WSPreOrderCommissions_Lang>();
		WSOrderCommissions = (ICollection<WSOrderCommissions>)new HashSet<WSOrderCommissions>();
	}
}
