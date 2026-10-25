using System.Collections.Generic;

namespace CRM.Models;

public class RahkaranInternalSalesQuotationItemResponseViewModel
{
	public decimal? Additions { get; set; }

	public long? DeliveryAddressRef { get; set; }

	public int? DeliveryAddressType { get; set; }

	public string DeliveryAddressTypeTitle { get; set; }

	public string Description { get; set; }

	public long? ID { get; set; }

	public decimal? NetPrice { get; set; }

	public decimal? Price { get; set; }

	public decimal? Reductions { get; set; }

	public long? DocumentRef { get; set; }

	public decimal? Fee { get; set; }

	public double? InitialQuantity { get; set; }

	public List<RahkaranInternalSalesQuotationPoliciesResponseViewModel> Policies { get; set; }

	public long? ProductRef { get; set; }

	public double? Quantity { get; set; }

	public long? ReferenceRef { get; set; }

	public int? ReferenceType { get; set; }

	public string ReferenceTypeTitle { get; set; }

	public int? RowNumber { get; set; }

	public long? UnitRef { get; set; }
}
