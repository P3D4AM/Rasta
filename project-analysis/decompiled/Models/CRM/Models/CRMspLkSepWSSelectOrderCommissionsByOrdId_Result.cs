using System;

namespace CRM.Models;

public class CRMspLkSepWSSelectOrderCommissionsByOrdId_Result
{
	public int OrderCommissionId { get; set; }

	public DateTime CommDateTime { get; set; }

	public string CommDatePersian { get; set; }

	public int CommOrderId { get; set; }

	public int? CommUserId { get; set; }

	public string CommUser { get; set; }

	public double? CommRate { get; set; }

	public decimal CommAmount { get; set; }

	public string CommDesc { get; set; }

	public int? CommTypeId { get; set; }

	public string CommTypeTitle { get; set; }

	public int? CommKindId { get; set; }

	public string CommKindTitle { get; set; }

	public int? CommTypeCmpId { get; set; }

	public string CommTypeCmp { get; set; }

	public int? CommTypePrsId { get; set; }

	public string CommTypePrs { get; set; }

	public int? LinkAccHeaderId { get; set; }

	public string LinkAccHeaderNumber { get; set; }

	public int? LinkAccDetailId { get; set; }

	public int? LinkAccVoucherId { get; set; }

	public string LinkAccVoucherNumber { get; set; }

	public string LinkAccHeaderIdStr { get; set; }

	public string LinkAccDetailIdStr { get; set; }

	public string LinkAccVoucherIdStr { get; set; }

	public string LinkAccType { get; set; }

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public string LinkAccFirstTransferDateStr { get; set; }

	public string LinkAccLastTransferDateStr { get; set; }

	public int? SepHeaderId { get; set; }

	public string SepHeaderNumber { get; set; }

	public decimal? SepHeaderSumAmount { get; set; }

	public int? SepDetailId { get; set; }

	public int? SepVoucherId { get; set; }

	public int? SepVoucherNumber { get; set; }

	public int? CommAmountCurrUnId { get; set; }

	public string CommAmountCurrUnName { get; set; }

	public double? CommAmountCurrencyRate { get; set; }

	public bool? CommAmountCurrUnIsDecimal { get; set; }
}
