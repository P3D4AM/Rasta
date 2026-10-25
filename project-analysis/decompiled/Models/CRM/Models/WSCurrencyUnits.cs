using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSCurrencyUnitsMetadata))]
public class WSCurrencyUnits
{
	public int CurrencyUnitID { get; set; }

	public string CurrencyUnit { get; set; }

	public string Description { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string CurrencyUnitEn { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public bool? IsDecimal { get; set; }

	public string TspCurrencyUnitCode { get; set; }

	public string LinkAccCurrencyUnitIdStr { get; set; }

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public string LinkAccData { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder1 { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder2 { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder3 { get; set; }

	public virtual ICollection<WSBuyOrderItems> WSBuyOrderItems { get; set; }

	public virtual ICollection<WSBuyOrderItems> WSBuyOrderItems1 { get; set; }

	public virtual ICollection<WSBuyOrderItems> WSBuyOrderItems2 { get; set; }

	public virtual ICollection<WSBuyOrderItems> WSBuyOrderItems3 { get; set; }

	public virtual ICollection<WSCostSheets> WSCostSheets { get; set; }

	public virtual ICollection<WSCostSheets> WSCostSheets1 { get; set; }

	public virtual ICollection<WSCurrencyUnitRate> WSCurrencyUnitRate { get; set; }

	public virtual ICollection<WSCurrencyUnitRate> WSCurrencyUnitRate1 { get; set; }

	public virtual ICollection<WSCurrencyUnits_Lang> WSCurrencyUnits_Lang { get; set; }

	public virtual ICollection<WSPreOrderCommissions> WSPreOrderCommissions { get; set; }

	public virtual ICollection<WSProductCost> WSProductCost { get; set; }

	public virtual ICollection<WSProductPrice> WSProductPrice { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder { get; set; }

	public virtual ICollection<WSOrderItems> WSOrderItems { get; set; }

	public virtual ICollection<WSPreOrderItems> WSPreOrderItems { get; set; }

	public virtual ICollection<WSTmpUserItemCopy> WSTmpUserItemCopy { get; set; }

	public virtual ICollection<WSBuyOrderDefaultSetting> WSBuyOrderDefaultSetting { get; set; }

	public virtual ICollection<WSOrderCommissions> WSOrderCommissions { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder31 { get; set; }

	public virtual ICollection<WSBuyOrderDefaultSetting> WSBuyOrderDefaultSetting1 { get; set; }

	public virtual ICollection<WSBuyOrderItems> WSBuyOrderItems31 { get; set; }

	public virtual ICollection<WSOrderItems> WSOrderItems1 { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder1 { get; set; }

	public virtual ICollection<WSPreOrderItems> WSPreOrderItems1 { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual ICollection<WSOrder> WSOrder1 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting1 { get; set; }

	public virtual ICollection<WSProductImportFromExcel> WSProductImportFromExcel { get; set; }

	public virtual ICollection<WSProductImportFromExcel> WSProductImportFromExcel1 { get; set; }

	public virtual ICollection<WSOrderDefaultSetting> WSOrderDefaultSetting { get; set; }

	public virtual ICollection<WSOrderDefaultSetting> WSOrderDefaultSetting1 { get; set; }

	public virtual ICollection<WSPreOrderDefaultSetting> WSPreOrderDefaultSetting { get; set; }

	public virtual ICollection<WSPreOrderDefaultSetting> WSPreOrderDefaultSetting1 { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSCurrencyUnits()
	{
		WSBuyOrder = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSBuyOrder1 = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSBuyOrder2 = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSBuyOrder3 = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSBuyOrderItems = (ICollection<WSBuyOrderItems>)new HashSet<WSBuyOrderItems>();
		WSBuyOrderItems1 = (ICollection<WSBuyOrderItems>)new HashSet<WSBuyOrderItems>();
		WSBuyOrderItems2 = (ICollection<WSBuyOrderItems>)new HashSet<WSBuyOrderItems>();
		WSBuyOrderItems3 = (ICollection<WSBuyOrderItems>)new HashSet<WSBuyOrderItems>();
		WSCostSheets = (ICollection<WSCostSheets>)new HashSet<WSCostSheets>();
		WSCostSheets1 = (ICollection<WSCostSheets>)new HashSet<WSCostSheets>();
		WSCurrencyUnitRate = (ICollection<WSCurrencyUnitRate>)new HashSet<WSCurrencyUnitRate>();
		WSCurrencyUnitRate1 = (ICollection<WSCurrencyUnitRate>)new HashSet<WSCurrencyUnitRate>();
		WSCurrencyUnits_Lang = (ICollection<WSCurrencyUnits_Lang>)new HashSet<WSCurrencyUnits_Lang>();
		WSPreOrderCommissions = (ICollection<WSPreOrderCommissions>)new HashSet<WSPreOrderCommissions>();
		WSProductCost = (ICollection<WSProductCost>)new HashSet<WSProductCost>();
		WSProductPrice = (ICollection<WSProductPrice>)new HashSet<WSProductPrice>();
		WSPreOrder = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSOrderItems = (ICollection<WSOrderItems>)new HashSet<WSOrderItems>();
		WSPreOrderItems = (ICollection<WSPreOrderItems>)new HashSet<WSPreOrderItems>();
		WSTmpUserItemCopy = (ICollection<WSTmpUserItemCopy>)new HashSet<WSTmpUserItemCopy>();
		WSBuyOrderDefaultSetting = (ICollection<WSBuyOrderDefaultSetting>)new HashSet<WSBuyOrderDefaultSetting>();
		WSOrderCommissions = (ICollection<WSOrderCommissions>)new HashSet<WSOrderCommissions>();
		WSBuyOrder31 = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSBuyOrderDefaultSetting1 = (ICollection<WSBuyOrderDefaultSetting>)new HashSet<WSBuyOrderDefaultSetting>();
		WSBuyOrderItems31 = (ICollection<WSBuyOrderItems>)new HashSet<WSBuyOrderItems>();
		WSOrderItems1 = (ICollection<WSOrderItems>)new HashSet<WSOrderItems>();
		WSPreOrder1 = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSPreOrderItems1 = (ICollection<WSPreOrderItems>)new HashSet<WSPreOrderItems>();
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
		WSOrder1 = (ICollection<WSOrder>)new HashSet<WSOrder>();
		CrmFoSetting = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmMobSetting = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting1 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		WSProductImportFromExcel = (ICollection<WSProductImportFromExcel>)new HashSet<WSProductImportFromExcel>();
		WSProductImportFromExcel1 = (ICollection<WSProductImportFromExcel>)new HashSet<WSProductImportFromExcel>();
		WSOrderDefaultSetting = (ICollection<WSOrderDefaultSetting>)new HashSet<WSOrderDefaultSetting>();
		WSOrderDefaultSetting1 = (ICollection<WSOrderDefaultSetting>)new HashSet<WSOrderDefaultSetting>();
		WSPreOrderDefaultSetting = (ICollection<WSPreOrderDefaultSetting>)new HashSet<WSPreOrderDefaultSetting>();
		WSPreOrderDefaultSetting1 = (ICollection<WSPreOrderDefaultSetting>)new HashSet<WSPreOrderDefaultSetting>();
	}
}
