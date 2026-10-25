using System.Collections.Generic;

namespace CRM.Models;

public class RahkaranInternalSalesQuotationDefineResponseViewModel
{
	public string addressId { get; set; }

	public string brokerId { get; set; }

	public string currencyId { get; set; }

	public string customerId { get; set; }

	public string date { get; set; }

	public string description { get; set; }

	public string id { get; set; }

	public string inventoryId { get; set; }

	public List<RahkaranInternalSalesQuotationItemDefineResponseViewModel> items { get; set; }

	public int? payerType { get; set; }

	public string paymentAgreementId { get; set; }

	public string plantId { get; set; }

	public string salesAreaId { get; set; }

	public string salesOfficeId { get; set; }

	public string salesTypeId { get; set; }

	public int? settlementRespite { get; set; }

	public string additionAmount { get; set; }

	public string netPrice { get; set; }

	public RahkaranInternalSalesQuotationOperationControlPolicyResultDefineResponseViewModel operationControlPolicyResult { get; set; }

	public int? operationControlPolicyResultApplicationMoment { get; set; }

	public List<RahkaranInternalSalesQuotationPolicyResultsDefineResponseViewModel> policyResults { get; set; }

	public string price { get; set; }

	public string reductionAmount { get; set; }

	public string agentID { get; set; }

	public string deliveryAddressRef { get; set; }

	public int? deliveryAddressType { get; set; }

	public string oneTimeCustomerID { get; set; }

	public string payerAccountID { get; set; }

	public int? recipientType { get; set; }

	public string shippingPointID { get; set; }
}
