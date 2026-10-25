using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSUserFavproductItemsMetadata))]
public class WSUserFavproductItems
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

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public decimal? FavprdIDiscountPercent { get; set; }

	public bool? FavprdINotVisible { get; set; }

	public bool? FavprdINotInSum { get; set; }

	public int? FavprdIPriceGroupId { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSProductPriceGroup WSProductPriceGroup { get; set; }

	public virtual ICollection<WSUserFavproductItems_Lang> WSUserFavproductItems_Lang { get; set; }

	public virtual WSUserFavproducts WSUserFavproducts { get; set; }

	public virtual WsWareHouse WsWareHouse { get; set; }

	public virtual WSProducts WSProducts { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSUserFavproductItems()
	{
		WSUserFavproductItems_Lang = (ICollection<WSUserFavproductItems_Lang>)new HashSet<WSUserFavproductItems_Lang>();
	}
}
