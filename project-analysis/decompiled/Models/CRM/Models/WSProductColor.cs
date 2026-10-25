using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductColorMetadata))]
public class WSProductColor
{
	public int ProductColorID { get; set; }

	public string Color { get; set; }

	public string ColorDescription { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string ColorEn { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string ColorCode { get; set; }

	public string LinkAccColorIdStr { get; set; }

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public string LinkAccData { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSProductColor_Lang> WSProductColor_Lang { get; set; }

	public virtual ICollection<WSBuyOrderItems> WSBuyOrderItems { get; set; }

	public virtual ICollection<WSOrderItems> WSOrderItems { get; set; }

	public virtual ICollection<WSPreOrderItems> WSPreOrderItems { get; set; }

	public virtual ICollection<WSTmpUserItemCopy> WSTmpUserItemCopy { get; set; }

	public virtual ICollection<WSStockSupplyItems> WSStockSupplyItems { get; set; }

	public virtual ICollection<WSProducts> WSProducts { get; set; }

	public virtual ICollection<WSProductImportFromExcel> WSProductImportFromExcel { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSProductColor()
	{
		WSProductColor_Lang = (ICollection<WSProductColor_Lang>)new HashSet<WSProductColor_Lang>();
		WSBuyOrderItems = (ICollection<WSBuyOrderItems>)new HashSet<WSBuyOrderItems>();
		WSOrderItems = (ICollection<WSOrderItems>)new HashSet<WSOrderItems>();
		WSPreOrderItems = (ICollection<WSPreOrderItems>)new HashSet<WSPreOrderItems>();
		WSTmpUserItemCopy = (ICollection<WSTmpUserItemCopy>)new HashSet<WSTmpUserItemCopy>();
		WSStockSupplyItems = (ICollection<WSStockSupplyItems>)new HashSet<WSStockSupplyItems>();
		WSProducts = (ICollection<WSProducts>)new HashSet<WSProducts>();
		WSProductImportFromExcel = (ICollection<WSProductImportFromExcel>)new HashSet<WSProductImportFromExcel>();
	}
}
