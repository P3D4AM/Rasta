namespace CRM.Models;

public class RayvarzCustomerDefineViewModel
{
	public bool? isValidationsApplied { get; set; }

	public string customerId { get; set; }

	public string name { get; set; }

	public string nameEn { get; set; }

	public string attachmentId { get; set; }

	public int? salesTypeId { get; set; }

	public string salesType { get; set; }

	public int? regionId { get; set; }

	public string region { get; set; }

	public string firstContactDate { get; set; }

	public string managerName { get; set; }

	public int? statusId { get; set; }

	public string status { get; set; }

	public int? customerGroupId { get; set; }

	public string customerGroup { get; set; }

	public string economicalCode { get; set; }

	public string cashId { get; set; }

	public string nationalId { get; set; }

	public long? centerId { get; set; }

	public string center { get; set; }

	public long? discountTypeId { get; set; }

	public string discountType { get; set; }

	public int? hasDiscount { get; set; }

	public int? countyId { get; set; }

	public string county { get; set; }

	public string address1 { get; set; }

	public string address2 { get; set; }

	public string zipCode { get; set; }

	public string postBoxNo { get; set; }

	public string tel1 { get; set; }

	public string tel2 { get; set; }

	public string fax { get; set; }

	public string email { get; set; }

	public int? salesPathId { get; set; }

	public string salesPath { get; set; }

	public decimal? distance { get; set; }

	public string fatherName { get; set; }

	public string birthCertificateNo { get; set; }

	public string birthCertificateSerialNo { get; set; }

	public int? birthCertificateIssuePlaceId { get; set; }

	public string birthCertificateIssuePlace { get; set; }

	public decimal? remainingCredit { get; set; }

	public decimal? minimumPurchase { get; set; }

	public decimal? maximumPurchase { get; set; }

	public string buyerId { get; set; }

	public string buyer { get; set; }

	public decimal? creditDiscountAmount { get; set; }

	public string creditDiscountDate { get; set; }

	public string shippingAgentId { get; set; }

	public string shippingAgent { get; set; }

	public int? taxCityId { get; set; }

	public string taxCity { get; set; }

	public int? taxMainId { get; set; }

	public string taxMain { get; set; }

	public int? taxSubId { get; set; }

	public string taxSub { get; set; }

	public string firstName { get; set; }

	public string lastName { get; set; }

	public int? disShareGroupId { get; set; }

	public string disShareGroup { get; set; }

	public string rayGuid { get; set; }

	public int? state { get; set; }

	public int? lastState { get; set; }

	public string rowVersion { get; set; }

	public string[] backupOriginalData { get; set; }

	public string[] rayValidationResults { get; set; }

	public string[] validationErrors { get; set; }

	public string[] validationErrorsMessages { get; set; }

	public int? metadataRaySystemId { get; set; }

	public bool? hasMetadata { get; set; }

	public string[] modifiedProperties { get; set; }

	public bool? hasErrors { get; set; }

	public bool? disposing { get; set; }
}
