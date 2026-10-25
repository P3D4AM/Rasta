using System.Collections.Generic;

namespace CRM.Models;

public class RahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel
{
	public string description { get; set; }

	public string id { get; set; }

	public int? index { get; set; }

	public string productId { get; set; }

	public string quantity { get; set; }

	public string salesAreaId { get; set; }

	public int? settlementRespite { get; set; }

	public string unitId { get; set; }

	public string additionAmount { get; set; }

	public string fee { get; set; }

	public string freeProductPolicyConditionRowId { get; set; }

	public string freeProductPolicyId { get; set; }

	public string netPrice { get; set; }

	public int? parentItemIndex { get; set; }

	public List<RahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel> policyResults { get; set; }

	public string price { get; set; }

	public string reductionAmount { get; set; }

	public int? type { get; set; }

	public string inventoryID { get; set; }

	public string plantID { get; set; }

	public string productPackItemRef { get; set; }

	public string productPackQuantity { get; set; }

	public string productPackRef { get; set; }

	public string referenceID { get; set; }

	public RahkaranInternalSalesCalculatePoliciesItemReferenceTypeDefineResponseViewModel referenceType { get; set; }

	public string shippingPointID { get; set; }
}
