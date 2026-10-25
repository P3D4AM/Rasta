using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanyMoneyBagMetadata))]
public class CrmCompanyMoneyBag
{
	public int CompanyMoneyBagId { get; set; }

	public int CmpMnBgCompanyId { get; set; }

	public int? CmpMnBgSystemPartId { get; set; }

	public int? CmpMnBgSystemPartObjectId { get; set; }

	public long CmpMnBgNumber { get; set; }

	public DateTime CmpMnBgDate { get; set; }

	public string CmpMnBgDatePersian { get; set; }

	public decimal CmpMnBgAmount { get; set; }

	public string CmpMnBgDesc { get; set; }

	public string CmpMnBgBankTransactionCode { get; set; }

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

	public string CmpMnBgLinkAccMoneyBagIdStr { get; set; }

	public string CmpMnBgLinkAccMoneyBagType { get; set; }

	public DateTime? CmpMnBgLinkAccFirstTransferDate { get; set; }

	public DateTime? CmpMnBgLinkAccLastTransferDate { get; set; }

	public string CmpMnBgLinkAccData { get; set; }

	public DateTime? CmpMnBgExpireDate { get; set; }

	public string CmpMnBgExpireDatePersian { get; set; }

	public int? CmpMnBgCId { get; set; }

	public virtual CrmSystemParts CrmSystemParts { get; set; }

	public virtual ICollection<CrmCompanyMoneyBag_Lang> CrmCompanyMoneyBag_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSOrderPayments> WSOrderPayments { get; set; }

	public virtual ICollection<WSPreOrderPayments> WSPreOrderPayments { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmCompanyMoneyBag()
	{
		CrmCompanyMoneyBag_Lang = (ICollection<CrmCompanyMoneyBag_Lang>)new HashSet<CrmCompanyMoneyBag_Lang>();
		WSOrderPayments = (ICollection<WSOrderPayments>)new HashSet<WSOrderPayments>();
		WSPreOrderPayments = (ICollection<WSPreOrderPayments>)new HashSet<WSPreOrderPayments>();
	}
}
