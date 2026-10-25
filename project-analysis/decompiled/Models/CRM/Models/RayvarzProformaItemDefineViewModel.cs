namespace CRM.Models;

public class RayvarzProformaItemDefineViewModel
{
	public bool? isValidationsApplied { get; set; }

	public bool? isDataFast { get; set; }

	public decimal? partialAmount { get; set; }

	public decimal? adjustTotalQtyDescription { get; set; }

	public decimal? adjustPartialQtyDescription { get; set; }

	public decimal? adjustmentUnitPricePer { get; set; }

	public decimal? adjustmentUnitPriceDifferent { get; set; }

	public decimal? inventoryConvertQty { get; set; }

	public long? row { get; set; }

	public string itemDataId { get; set; }

	public string itemData { get; set; }

	public string serialNo { get; set; }

	public decimal? partialQty { get; set; }

	public string partialQtyUnitId { get; set; }

	public string partialQtyUnit { get; set; }

	public decimal? totalQty { get; set; }

	public string totalQtyUnitId { get; set; }

	public string totalQtyUnit { get; set; }

	public decimal? unitAmount { get; set; }

	public decimal? totalAmount { get; set; }

	public decimal? rialEquivalent { get; set; }

	public decimal? discountPercent { get; set; }

	public decimal? perDiscountUnitRate { get; set; }

	public decimal? discountAmount { get; set; }

	public decimal? discountAmountEquivalentRial { get; set; }

	public long? discountComputeStyle { get; set; }

	public decimal? totalTollAmount { get; set; }

	public decimal? totalTollAmountEquivalentRial { get; set; }

	public decimal? preReceive { get; set; }

	public decimal? preReceivePercent { get; set; }

	public decimal? totalWeight { get; set; }

	public string unitWeightId { get; set; }

	public string unitWeight { get; set; }

	public decimal? afterDiscountDeduct { get; set; }

	public long? discountTypeId { get; set; }

	public string discountType { get; set; }

	public long? salesTypeId { get; set; }

	public string salesType { get; set; }

	public long? receiveTypeId { get; set; }

	public string receiveType { get; set; }

	public decimal? userEnteredWeight { get; set; }

	public string buyerId { get; set; }

	public string buyer { get; set; }

	public long? isPrize { get; set; }

	public long? discountTemplateId { get; set; }

	public long? unitPriceTemplateId { get; set; }

	public string unitPriceTemplate { get; set; }

	public long? previousSalesJournalItemId { get; set; }

	public string previousSalesJournalItem { get; set; }

	public decimal? customerCreditDiscount { get; set; }

	public long? salesJournalId { get; set; }

	public decimal? payableAmount { get; set; }

	public string itemGroupId { get; set; }

	public string itemGroup { get; set; }

	public long? centerId { get; set; }

	public string center { get; set; }

	public long? buyerCenterId { get; set; }

	public string buyerCenter { get; set; }

	public long? salesFiscalYearId { get; set; }

	public string salesFiscalYear { get; set; }

	public string docDate { get; set; }

	public long? salesDocTypeId { get; set; }

	public string salesDocType { get; set; }

	public string warehouseId { get; set; }

	public string warehouse { get; set; }

	public long? isCanceled { get; set; }

	public decimal? adjustTotalQty { get; set; }

	public decimal? adjustPartialQty { get; set; }

	public decimal? adjustmentalUnitAmount { get; set; }

	public decimal? consumedTotalQty { get; set; }

	public decimal? consumedPartialQty { get; set; }

	public long? returnReasonId { get; set; }

	public string returnReason { get; set; }

	public long? adjustmentReasonId { get; set; }

	public string adjustmentReason { get; set; }

	public decimal? pourcentage { get; set; }

	public decimal? commissionPercent { get; set; }

	public decimal? payablePrcWithOutEffect { get; set; }

	public string rayGuid { get; set; }

	public string[] salesJournalItemAdjectives { get; set; }

	public decimal? deliveryDocNo { get; set; }

	public string salesErrorMessage { get; set; }

	public long? docNo { get; set; }

	public string description { get; set; }

	public string technicalNo { get; set; }

	public long? state { get; set; }

	public long? lastState { get; set; }

	public string[] backupOriginalData { get; set; }

	public string[] rayValidationResults { get; set; }

	public string[] validationErrors { get; set; }

	public string[] validationErrorsMessages { get; set; }

	public long? metadataRaySystemId { get; set; }

	public bool? hasMetadata { get; set; }

	public string[] modifiedProperties { get; set; }

	public bool? hasErrors { get; set; }

	public bool? disposing { get; set; }

	public int? CrmOrdItemId { get; set; }
}
