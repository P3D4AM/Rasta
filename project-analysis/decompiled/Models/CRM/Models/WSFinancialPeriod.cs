using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSFinancialPeriodMetadata))]
public class WSFinancialPeriod
{
	public int ID { get; set; }

	public string Name { get; set; }

	public string FDate { get; set; }

	public string TDate { get; set; }

	public string Description { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public short? Year1 { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? FpLinkAccFPId { get; set; }

	public DateTime? FpLinkAccFirstTransferDate { get; set; }

	public DateTime? FpLinkAccLastTransferDate { get; set; }

	public string FpLinkAccData { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder { get; set; }

	public virtual ICollection<WSBuyOrderItems> WSBuyOrderItems { get; set; }

	public virtual ICollection<WSBuyOrderItemSerials> WSBuyOrderItemSerials { get; set; }

	public virtual ICollection<WSBuyOrderPayments> WSBuyOrderPayments { get; set; }

	public virtual ICollection<WSBuyOrderPaymentTypes> WSBuyOrderPaymentTypes { get; set; }

	public virtual ICollection<WSBuyOrderStatus> WSBuyOrderStatus { get; set; }

	public virtual ICollection<WSCostSheetDyFieldGroups> WSCostSheetDyFieldGroups { get; set; }

	public virtual ICollection<WSCostSheetDyFieldTitle> WSCostSheetDyFieldTitle { get; set; }

	public virtual ICollection<WSCostSheetDyFieldValues> WSCostSheetDyFieldValues { get; set; }

	public virtual ICollection<WSCostSheetItems> WSCostSheetItems { get; set; }

	public virtual ICollection<WSCostSheetProducts> WSCostSheetProducts { get; set; }

	public virtual ICollection<WSCostSheets> WSCostSheets { get; set; }

	public virtual ICollection<WSCreditDuration> WSCreditDuration { get; set; }

	public virtual ICollection<WSCurrencyUnitRate> WSCurrencyUnitRate { get; set; }

	public virtual ICollection<WSDeliveryScheduleExcept> WSDeliveryScheduleExcept { get; set; }

	public virtual ICollection<WSDeliveryTime> WSDeliveryTime { get; set; }

	public virtual ICollection<WSDiscountCode> WSDiscountCode { get; set; }

	public virtual ICollection<WSDiscountCodeHistory> WSDiscountCodeHistory { get; set; }

	public virtual ICollection<WSGuaranty> WSGuaranty { get; set; }

	public virtual ICollection<WSLinkedProducts> WSLinkedProducts { get; set; }

	public virtual ICollection<WSLogo> WSLogo { get; set; }

	public virtual ICollection<WSOrderItemSerials> WSOrderItemSerials { get; set; }

	public virtual ICollection<WSOrderStatus> WSOrderStatus { get; set; }

	public virtual ICollection<WSPayCondition> WSPayCondition { get; set; }

	public virtual ICollection<WSPreOrderItemSpecification> WSPreOrderItemSpecification { get; set; }

	public virtual ICollection<WSPreOrderOpr> WSPreOrderOpr { get; set; }

	public virtual ICollection<WSPreOrderPrdGroupMustExistReasons> WSPreOrderPrdGroupMustExistReasons { get; set; }

	public virtual ICollection<WSPreOrderStatus> WSPreOrderStatus { get; set; }

	public virtual ICollection<WSPreOrderTypes> WSPreOrderTypes { get; set; }

	public virtual ICollection<WSProductCost> WSProductCost { get; set; }

	public virtual ICollection<WSProductFirstGroup> WSProductFirstGroup { get; set; }

	public virtual ICollection<WSProductGallery> WSProductGallery { get; set; }

	public virtual ICollection<WSProductGroupPicture> WSProductGroupPicture { get; set; }

	public virtual ICollection<WSProductPicture> WSProductPicture { get; set; }

	public virtual ICollection<WSProductPrice> WSProductPrice { get; set; }

	public virtual ICollection<WSProductRelationLimit> WSProductRelationLimit { get; set; }

	public virtual ICollection<WSProductRelationType> WSProductRelationType { get; set; }

	public virtual ICollection<WSProductSecondGroup> WSProductSecondGroup { get; set; }

	public virtual ICollection<WSProductShpStockManageTypes> WSProductShpStockManageTypes { get; set; }

	public virtual ICollection<WSProductSpecification> WSProductSpecification { get; set; }

	public virtual ICollection<WSProductsRate> WSProductsRate { get; set; }

	public virtual ICollection<WSProductsUserDiscount> WSProductsUserDiscount { get; set; }

	public virtual ICollection<WSSaleCenters> WSSaleCenters { get; set; }

	public virtual ICollection<WSSignature> WSSignature { get; set; }

	public virtual ICollection<WsWareHouse> WsWareHouse { get; set; }

	public virtual ICollection<WSWareHouseUserPermissions> WSWareHouseUserPermissions { get; set; }

	public virtual ICollection<WSOrderPayments> WSOrderPayments { get; set; }

	public virtual ICollection<WSPreOrderPayments> WSPreOrderPayments { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder { get; set; }

	public virtual ICollection<WSOrderPaymentTypes> WSOrderPaymentTypes { get; set; }

	public virtual ICollection<WSDeliverySchedule> WSDeliverySchedule { get; set; }

	public virtual ICollection<WSOrderItems> WSOrderItems { get; set; }

	public virtual ICollection<WSPreOrderItems> WSPreOrderItems { get; set; }

	public virtual ICollection<WSDeliveryTerms> WSDeliveryTerms { get; set; }

	public virtual ICollection<WSBuyOrderDefaultSetting> WSBuyOrderDefaultSetting { get; set; }

	public virtual ICollection<WSStockSupply> WSStockSupply { get; set; }

	public virtual ICollection<WSStockSupplyItems> WSStockSupplyItems { get; set; }

	public virtual ICollection<WSDiscountStrategy> WSDiscountStrategy { get; set; }

	public virtual ICollection<WSOrderDiscounts> WSOrderDiscounts { get; set; }

	public virtual ICollection<WSPreOrderDiscounts> WSPreOrderDiscounts { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual ICollection<WSOrderGroups> WSOrderGroups { get; set; }

	public virtual ICollection<WSProductSpecificationFieldGroups> WSProductSpecificationFieldGroups { get; set; }

	public virtual ICollection<WSProductSpecificationFieldTypes> WSProductSpecificationFieldTypes { get; set; }

	public virtual ICollection<WSProductSpecificationFields> WSProductSpecificationFields { get; set; }

	public virtual ICollection<WSProductShpException> WSProductShpException { get; set; }

	public virtual ICollection<WSSaleAreas> WSSaleAreas { get; set; }

	public virtual ICollection<WSOrderPaymentGroupsI> WSOrderPaymentGroupsI { get; set; }

	public virtual ICollection<WSOrderPaymentGroupsII> WSOrderPaymentGroupsII { get; set; }

	public virtual ICollection<WSProducts> WSProducts { get; set; }

	public virtual ICollection<WSDoc> WSDoc { get; set; }

	public virtual ICollection<WSDocItems> WSDocItems { get; set; }

	public virtual ICollection<WSDocItemSerials> WSDocItemSerials { get; set; }

	public virtual ICollection<WSBuyOrderOpr> WSBuyOrderOpr { get; set; }

	public virtual ICollection<WSDocOpr> WSDocOpr { get; set; }

	public virtual ICollection<WSOrderOpr> WSOrderOpr { get; set; }

	public virtual ICollection<WSOrderDefaultSetting> WSOrderDefaultSetting { get; set; }

	public virtual ICollection<WSPreOrderDefaultSetting> WSPreOrderDefaultSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSFinancialPeriod()
	{
		WSBuyOrder = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSBuyOrderItems = (ICollection<WSBuyOrderItems>)new HashSet<WSBuyOrderItems>();
		WSBuyOrderItemSerials = (ICollection<WSBuyOrderItemSerials>)new HashSet<WSBuyOrderItemSerials>();
		WSBuyOrderPayments = (ICollection<WSBuyOrderPayments>)new HashSet<WSBuyOrderPayments>();
		WSBuyOrderPaymentTypes = (ICollection<WSBuyOrderPaymentTypes>)new HashSet<WSBuyOrderPaymentTypes>();
		WSBuyOrderStatus = (ICollection<WSBuyOrderStatus>)new HashSet<WSBuyOrderStatus>();
		WSCostSheetDyFieldGroups = (ICollection<WSCostSheetDyFieldGroups>)new HashSet<WSCostSheetDyFieldGroups>();
		WSCostSheetDyFieldTitle = (ICollection<WSCostSheetDyFieldTitle>)new HashSet<WSCostSheetDyFieldTitle>();
		WSCostSheetDyFieldValues = (ICollection<WSCostSheetDyFieldValues>)new HashSet<WSCostSheetDyFieldValues>();
		WSCostSheetItems = (ICollection<WSCostSheetItems>)new HashSet<WSCostSheetItems>();
		WSCostSheetProducts = (ICollection<WSCostSheetProducts>)new HashSet<WSCostSheetProducts>();
		WSCostSheets = (ICollection<WSCostSheets>)new HashSet<WSCostSheets>();
		WSCreditDuration = (ICollection<WSCreditDuration>)new HashSet<WSCreditDuration>();
		WSCurrencyUnitRate = (ICollection<WSCurrencyUnitRate>)new HashSet<WSCurrencyUnitRate>();
		WSDeliveryScheduleExcept = (ICollection<WSDeliveryScheduleExcept>)new HashSet<WSDeliveryScheduleExcept>();
		WSDeliveryTime = (ICollection<WSDeliveryTime>)new HashSet<WSDeliveryTime>();
		WSDiscountCode = (ICollection<WSDiscountCode>)new HashSet<WSDiscountCode>();
		WSDiscountCodeHistory = (ICollection<WSDiscountCodeHistory>)new HashSet<WSDiscountCodeHistory>();
		WSGuaranty = (ICollection<WSGuaranty>)new HashSet<WSGuaranty>();
		WSLinkedProducts = (ICollection<WSLinkedProducts>)new HashSet<WSLinkedProducts>();
		WSLogo = (ICollection<WSLogo>)new HashSet<WSLogo>();
		WSOrderItemSerials = (ICollection<WSOrderItemSerials>)new HashSet<WSOrderItemSerials>();
		WSOrderStatus = (ICollection<WSOrderStatus>)new HashSet<WSOrderStatus>();
		WSPayCondition = (ICollection<WSPayCondition>)new HashSet<WSPayCondition>();
		WSPreOrderItemSpecification = (ICollection<WSPreOrderItemSpecification>)new HashSet<WSPreOrderItemSpecification>();
		WSPreOrderOpr = (ICollection<WSPreOrderOpr>)new HashSet<WSPreOrderOpr>();
		WSPreOrderPrdGroupMustExistReasons = (ICollection<WSPreOrderPrdGroupMustExistReasons>)new HashSet<WSPreOrderPrdGroupMustExistReasons>();
		WSPreOrderStatus = (ICollection<WSPreOrderStatus>)new HashSet<WSPreOrderStatus>();
		WSPreOrderTypes = (ICollection<WSPreOrderTypes>)new HashSet<WSPreOrderTypes>();
		WSProductCost = (ICollection<WSProductCost>)new HashSet<WSProductCost>();
		WSProductFirstGroup = (ICollection<WSProductFirstGroup>)new HashSet<WSProductFirstGroup>();
		WSProductGallery = (ICollection<WSProductGallery>)new HashSet<WSProductGallery>();
		WSProductGroupPicture = (ICollection<WSProductGroupPicture>)new HashSet<WSProductGroupPicture>();
		WSProductPicture = (ICollection<WSProductPicture>)new HashSet<WSProductPicture>();
		WSProductPrice = (ICollection<WSProductPrice>)new HashSet<WSProductPrice>();
		WSProductRelationLimit = (ICollection<WSProductRelationLimit>)new HashSet<WSProductRelationLimit>();
		WSProductRelationType = (ICollection<WSProductRelationType>)new HashSet<WSProductRelationType>();
		WSProductSecondGroup = (ICollection<WSProductSecondGroup>)new HashSet<WSProductSecondGroup>();
		WSProductShpStockManageTypes = (ICollection<WSProductShpStockManageTypes>)new HashSet<WSProductShpStockManageTypes>();
		WSProductSpecification = (ICollection<WSProductSpecification>)new HashSet<WSProductSpecification>();
		WSProductsRate = (ICollection<WSProductsRate>)new HashSet<WSProductsRate>();
		WSProductsUserDiscount = (ICollection<WSProductsUserDiscount>)new HashSet<WSProductsUserDiscount>();
		WSSaleCenters = (ICollection<WSSaleCenters>)new HashSet<WSSaleCenters>();
		WSSignature = (ICollection<WSSignature>)new HashSet<WSSignature>();
		WsWareHouse = (ICollection<WsWareHouse>)new HashSet<WsWareHouse>();
		WSWareHouseUserPermissions = (ICollection<WSWareHouseUserPermissions>)new HashSet<WSWareHouseUserPermissions>();
		WSOrderPayments = (ICollection<WSOrderPayments>)new HashSet<WSOrderPayments>();
		WSPreOrderPayments = (ICollection<WSPreOrderPayments>)new HashSet<WSPreOrderPayments>();
		WSPreOrder = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSOrderPaymentTypes = (ICollection<WSOrderPaymentTypes>)new HashSet<WSOrderPaymentTypes>();
		WSDeliverySchedule = (ICollection<WSDeliverySchedule>)new HashSet<WSDeliverySchedule>();
		WSOrderItems = (ICollection<WSOrderItems>)new HashSet<WSOrderItems>();
		WSPreOrderItems = (ICollection<WSPreOrderItems>)new HashSet<WSPreOrderItems>();
		WSDeliveryTerms = (ICollection<WSDeliveryTerms>)new HashSet<WSDeliveryTerms>();
		WSBuyOrderDefaultSetting = (ICollection<WSBuyOrderDefaultSetting>)new HashSet<WSBuyOrderDefaultSetting>();
		WSStockSupply = (ICollection<WSStockSupply>)new HashSet<WSStockSupply>();
		WSStockSupplyItems = (ICollection<WSStockSupplyItems>)new HashSet<WSStockSupplyItems>();
		WSDiscountStrategy = (ICollection<WSDiscountStrategy>)new HashSet<WSDiscountStrategy>();
		WSOrderDiscounts = (ICollection<WSOrderDiscounts>)new HashSet<WSOrderDiscounts>();
		WSPreOrderDiscounts = (ICollection<WSPreOrderDiscounts>)new HashSet<WSPreOrderDiscounts>();
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
		WSOrderGroups = (ICollection<WSOrderGroups>)new HashSet<WSOrderGroups>();
		WSProductSpecificationFieldGroups = (ICollection<WSProductSpecificationFieldGroups>)new HashSet<WSProductSpecificationFieldGroups>();
		WSProductSpecificationFieldTypes = (ICollection<WSProductSpecificationFieldTypes>)new HashSet<WSProductSpecificationFieldTypes>();
		WSProductSpecificationFields = (ICollection<WSProductSpecificationFields>)new HashSet<WSProductSpecificationFields>();
		WSProductShpException = (ICollection<WSProductShpException>)new HashSet<WSProductShpException>();
		WSSaleAreas = (ICollection<WSSaleAreas>)new HashSet<WSSaleAreas>();
		WSOrderPaymentGroupsI = (ICollection<WSOrderPaymentGroupsI>)new HashSet<WSOrderPaymentGroupsI>();
		WSOrderPaymentGroupsII = (ICollection<WSOrderPaymentGroupsII>)new HashSet<WSOrderPaymentGroupsII>();
		WSProducts = (ICollection<WSProducts>)new HashSet<WSProducts>();
		WSDoc = (ICollection<WSDoc>)new HashSet<WSDoc>();
		WSDocItems = (ICollection<WSDocItems>)new HashSet<WSDocItems>();
		WSDocItemSerials = (ICollection<WSDocItemSerials>)new HashSet<WSDocItemSerials>();
		WSBuyOrderOpr = (ICollection<WSBuyOrderOpr>)new HashSet<WSBuyOrderOpr>();
		WSDocOpr = (ICollection<WSDocOpr>)new HashSet<WSDocOpr>();
		WSOrderOpr = (ICollection<WSOrderOpr>)new HashSet<WSOrderOpr>();
		WSOrderDefaultSetting = (ICollection<WSOrderDefaultSetting>)new HashSet<WSOrderDefaultSetting>();
		WSPreOrderDefaultSetting = (ICollection<WSPreOrderDefaultSetting>)new HashSet<WSPreOrderDefaultSetting>();
	}
}
