using System;

namespace Mobile.Models;

public class TarazProductsViewModel
{
	public decimal? PRICE { get; set; }

	public long? UNITID { get; set; }

	public string UNITDESC { get; set; }

	public long? STOREID { get; set; }

	public string STORENAME { get; set; }

	public string STORECODE { get; set; }

	public long? GOODSID { get; set; }

	public string GOODSDESC { get; set; }

	public string GOODSCODE { get; set; }

	public string BARCODE { get; set; }

	public long? ProductId { get; set; }

	public long? RowNumber { get; set; }

	public int? AllPage { get; set; }

	public DateTime? createDate { get; set; }

	public DateTime? modifyDate { get; set; }

	public string latinDesc { get; set; }

	public long? minQuantity { get; set; }

	public long? maxQuantity { get; set; }

	public DateTime? unitCreateDate { get; set; }

	public DateTime? unitModifyDate { get; set; }
}
