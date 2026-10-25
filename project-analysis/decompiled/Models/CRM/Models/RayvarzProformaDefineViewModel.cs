using System.Collections.Generic;

namespace CRM.Models;

public class RayvarzProformaDefineViewModel
{
	public long? issueDocNo { get; set; }

	public long? deliveryDocNo { get; set; }

	public long? salesFiscalYearId { get; set; }

	public string salesFiscalYear { get; set; }

	public string warehouseId { get; set; }

	public string warehouse { get; set; }

	public string docDate { get; set; }

	public long? numberOfNextStepDoc { get; set; }

	public string contractNo { get; set; }

	public string customerId { get; set; }

	public string customer { get; set; }

	public long? isCancel { get; set; }

	public long? voucherRunNo { get; set; }

	public long? discountTypeId { get; set; }

	public string discountType { get; set; }

	public long? hasDiscount { get; set; }

	public long? salesTypeId { get; set; }

	public string salesType { get; set; }

	public long? receiveTypeId { get; set; }

	public string receiveType { get; set; }

	public decimal? dailyCurrencyRate { get; set; }

	public string currencyRateDate { get; set; }

	public string userId { get; set; }

	public string user { get; set; }

	public string buyerId { get; set; }

	public string buyer { get; set; }

	public decimal? totalDocAmount { get; set; }

	public decimal? totalDocAmountEquivalentRial { get; set; }

	public decimal? totalDiscountAmount { get; set; }

	public decimal? totalDiscountAmountEquivalentRial { get; set; }

	public decimal? totalAmountAfterDiscountDeduct { get; set; }

	public decimal? totalTollAmount { get; set; }

	public decimal? totalTollAmountEquivalentRial { get; set; }

	public decimal? totalPreReceiveAmount { get; set; }

	public decimal? totalCommissionAmount { get; set; }

	public decimal? totalPayableAmount { get; set; }

	public string currencyId { get; set; }

	public string currency { get; set; }

	public long? isRemainedDoc { get; set; }

	public string receiptDate { get; set; }

	public long? receiptPeriod { get; set; }

	public long? salesConfirmLevelId { get; set; }

	public string salesConfirmLevel { get; set; }

	public long? sendToWarehouse { get; set; }

	public long? customerGroupId { get; set; }

	public string customerGroup { get; set; }

	public long? buyerGroupId { get; set; }

	public string buyerGroup { get; set; }

	public long? buyerCenterId { get; set; }

	public string buyerCenter { get; set; }

	public long? customerCenterId { get; set; }

	public string customerCenter { get; set; }

	public long? beforeYearTrnsfer { get; set; }

	public long? nextYearTransfer { get; set; }

	public long? endSalesCycle { get; set; }

	public long? previousStepDocId { get; set; }

	public long? quotaGroup { get; set; }

	public long? salesDocProduceTypeId { get; set; }

	public long? parentIssueDocId { get; set; }

	public long? parentDeliveryDocId { get; set; }

	public string proFormaDocDate { get; set; }

	public string parentDocDate { get; set; }

	public string issueDocDate { get; set; }

	public string deliveryDocDate { get; set; }

	public string invoiceDocDate { get; set; }

	public long? parentDocNo { get; set; }

	public long? invoiceDocNo { get; set; }

	public long? parentFactorId { get; set; }

	public decimal? totalCreditDiscountAmount { get; set; }

	public long? multimediaDoc { get; set; }

	public string multiMediaDocX { get; set; }

	public long? branchId { get; set; }

	public string branch { get; set; }

	public long? sendSms { get; set; }

	public string docSerial { get; set; }

	public List<RayvarzProformaItemDefineViewModel> salesJournalItems { get; set; }

	public string[] journalGeneralAdjectives { get; set; }

	public string[] journalSpecialAdjective { get; set; }

	public long? customerRequestId { get; set; }

	public string customerRequest { get; set; }

	public string contractNo2 { get; set; }

	public string rayGuid { get; set; }

	public int? state { get; set; }

	public int? lastState { get; set; }

	public string backupOriginalData { get; set; }

	public string[] rayValidationResults { get; set; }

	public string[] validationErrors { get; set; }

	public string[] validationErrorsMessages { get; set; }

	public long? metadataRaySystemId { get; set; }

	public bool? hasMetadata { get; set; }

	public string[] modifiedProperties { get; set; }

	public bool? hasErrors { get; set; }

	public bool? disposing { get; set; }
}
