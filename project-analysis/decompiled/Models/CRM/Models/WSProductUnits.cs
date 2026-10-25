using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductUnitsMetadata))]
public class WSProductUnits
{
	public int ProductUnitID { get; set; }

	public string Unit { get; set; }

	public int? QuantityInUnit { get; set; }

	public string Description { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string UnitEn { get; set; }

	public Guid? GUId { get; set; }

	public double? FCR { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? UnitLinkAccUnitId { get; set; }

	public double? FCRI { get; set; }

	public string SHPUnit { get; set; }

	public string UnitLinkAccUnitIdStr { get; set; }

	public string TspUnitCode { get; set; }

	public DateTime? UnitLinkAccFirstTransferDate { get; set; }

	public DateTime? UnitLinkAccLastTransferDate { get; set; }

	public string UnitLinkAccData { get; set; }

	public string UnitIFormula { get; set; }

	public string UnitIIFormula { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSBuyOrderItems> WSBuyOrderItems { get; set; }

	public virtual ICollection<WSProductUnits_Lang> WSProductUnits_Lang { get; set; }

	public virtual ICollection<WSBuyOrderItems> WSBuyOrderItems1 { get; set; }

	public virtual ICollection<WSOrderItems> WSOrderItems { get; set; }

	public virtual ICollection<WSOrderItems> WSOrderItems1 { get; set; }

	public virtual ICollection<WSPreOrderItems> WSPreOrderItems { get; set; }

	public virtual ICollection<WSPreOrderItems> WSPreOrderItems1 { get; set; }

	public virtual ICollection<WSTmpUserItemCopy> WSTmpUserItemCopy { get; set; }

	public virtual ICollection<WSTmpUserItemCopy> WSTmpUserItemCopy1 { get; set; }

	public virtual ICollection<WSStockSupplyItems> WSStockSupplyItems { get; set; }

	public virtual ICollection<WSStockSupplyItems> WSStockSupplyItems1 { get; set; }

	public virtual ICollection<WSProducts> WSProducts { get; set; }

	public virtual ICollection<WSProducts> WSProducts1 { get; set; }

	public virtual ICollection<WSProductImportFromExcel> WSProductImportFromExcel { get; set; }

	public virtual ICollection<WSDocItems> WSDocItems { get; set; }

	public virtual ICollection<WSDocItems> WSDocItems1 { get; set; }

	public virtual ICollection<WSBuyOrderItems> WSBuyOrderItems2 { get; set; }

	public virtual ICollection<WSDocItems> WSDocItems2 { get; set; }

	public virtual ICollection<WSOrderItems> WSOrderItems2 { get; set; }

	public virtual ICollection<WSPreOrderItems> WSPreOrderItems2 { get; set; }

	public virtual ICollection<WSProducts> WSProducts2 { get; set; }

	public virtual ICollection<WSStockSupplyItems> WSStockSupplyItems2 { get; set; }

	public virtual ICollection<WSTmpUserItemCopy> WSTmpUserItemCopy2 { get; set; }

	public virtual ICollection<WSProductImportFromExcel> WSProductImportFromExcel1 { get; set; }

	public virtual ICollection<WSProductImportFromExcel> WSProductImportFromExcel2 { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSProductUnits()
	{
		WSBuyOrderItems = (ICollection<WSBuyOrderItems>)new HashSet<WSBuyOrderItems>();
		WSProductUnits_Lang = (ICollection<WSProductUnits_Lang>)new HashSet<WSProductUnits_Lang>();
		WSBuyOrderItems1 = (ICollection<WSBuyOrderItems>)new HashSet<WSBuyOrderItems>();
		WSOrderItems = (ICollection<WSOrderItems>)new HashSet<WSOrderItems>();
		WSOrderItems1 = (ICollection<WSOrderItems>)new HashSet<WSOrderItems>();
		WSPreOrderItems = (ICollection<WSPreOrderItems>)new HashSet<WSPreOrderItems>();
		WSPreOrderItems1 = (ICollection<WSPreOrderItems>)new HashSet<WSPreOrderItems>();
		WSTmpUserItemCopy = (ICollection<WSTmpUserItemCopy>)new HashSet<WSTmpUserItemCopy>();
		WSTmpUserItemCopy1 = (ICollection<WSTmpUserItemCopy>)new HashSet<WSTmpUserItemCopy>();
		WSStockSupplyItems = (ICollection<WSStockSupplyItems>)new HashSet<WSStockSupplyItems>();
		WSStockSupplyItems1 = (ICollection<WSStockSupplyItems>)new HashSet<WSStockSupplyItems>();
		WSProducts = (ICollection<WSProducts>)new HashSet<WSProducts>();
		WSProducts1 = (ICollection<WSProducts>)new HashSet<WSProducts>();
		WSProductImportFromExcel = (ICollection<WSProductImportFromExcel>)new HashSet<WSProductImportFromExcel>();
		WSDocItems = (ICollection<WSDocItems>)new HashSet<WSDocItems>();
		WSDocItems1 = (ICollection<WSDocItems>)new HashSet<WSDocItems>();
		WSBuyOrderItems2 = (ICollection<WSBuyOrderItems>)new HashSet<WSBuyOrderItems>();
		WSDocItems2 = (ICollection<WSDocItems>)new HashSet<WSDocItems>();
		WSOrderItems2 = (ICollection<WSOrderItems>)new HashSet<WSOrderItems>();
		WSPreOrderItems2 = (ICollection<WSPreOrderItems>)new HashSet<WSPreOrderItems>();
		WSProducts2 = (ICollection<WSProducts>)new HashSet<WSProducts>();
		WSStockSupplyItems2 = (ICollection<WSStockSupplyItems>)new HashSet<WSStockSupplyItems>();
		WSTmpUserItemCopy2 = (ICollection<WSTmpUserItemCopy>)new HashSet<WSTmpUserItemCopy>();
		WSProductImportFromExcel1 = (ICollection<WSProductImportFromExcel>)new HashSet<WSProductImportFromExcel>();
		WSProductImportFromExcel2 = (ICollection<WSProductImportFromExcel>)new HashSet<WSProductImportFromExcel>();
	}
}
