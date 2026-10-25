using System;

namespace CRM.Models;

public class WSUserFavproductItemsMetadata
{
	public int UserFavproductItemId { get; set; }

	public int UserFavproductId { get; set; }

	public int FavprdIPrdId { get; set; }

	public double? FavprdIQuantity { get; set; }

	public string FavprdIQuantityDesc { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? FavprdIOrderView { get; set; }

	public bool? Selector { get; set; }

	public Guid? GUId { get; set; }

	public int? FavprdIWHId { get; set; }

	public string AppType { get; set; }
}
