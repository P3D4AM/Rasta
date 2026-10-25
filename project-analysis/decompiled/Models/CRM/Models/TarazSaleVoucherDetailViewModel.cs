namespace CRM.Models;

public class TarazSaleVoucherDetailViewModel
{
	public double? quantity { get; set; }

	public decimal? fee { get; set; }

	public string detailXDesc { get; set; }

	public decimal? feeAgreement { get; set; }

	public decimal? feeDiscountPrice { get; set; }

	public decimal? feeDiscountPercent { get; set; }

	public long? voucherDetailID { get; set; }

	public long? goodsID { get; set; }

	public long? secUnitID { get; set; }

	public long? storeID { get; set; }

	public double? crmFcr { get; set; }
}
