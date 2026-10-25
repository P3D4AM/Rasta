namespace CRM.Models;

public class ArianSystemWarehouseResponseViewModel
{
	public bool? InActive { get; set; }

	public bool? IsBuyAutoVoucher { get; set; }

	public bool? IsFormSale { get; set; }

	public bool? IsSaleAutoVoucher { get; set; }

	public short? PlaceId { get; set; }

	public string StockCode { get; set; }

	public bool? StockCountMode { get; set; }

	public string StockDesc { get; set; }

	public string StockDescL { get; set; }

	public int? StockID { get; set; }

	public int? StockTypeID { get; set; }

	public string TafsiliCode { get; set; }

	public string TafsiliDesc { get; set; }

	public bool? IsVirtual { get; set; }

	public int? FatherId { get; set; }

	public byte?[] _TimeStamp { get; set; }

	public bool? NoCheckGoodsCount { get; set; }
}
