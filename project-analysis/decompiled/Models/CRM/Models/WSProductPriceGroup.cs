using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductPriceGroupMetadata))]
public class WSProductPriceGroup
{
	public int ProductPriceGroupID { get; set; }

	public string ProductPriceGroupName { get; set; }

	public string ProductPriceGroupDesc { get; set; }

	public int? OrderView { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public bool? SHPDefaultPriceGroup { get; set; }

	public bool? SHPPriceGroupVisible { get; set; }

	public string LinkAccPrdPriceGroupIdStr { get; set; }

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public string LinkAccData { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSProductPrice> WSProductPrice { get; set; }

	public virtual ICollection<WSProductPriceGroup_Lang> WSProductPriceGroup_Lang { get; set; }

	public virtual ICollection<WSUserFavproductItems> WSUserFavproductItems { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting { get; set; }

	public virtual ICollection<WSProductImportFromExcel> WSProductImportFromExcel { get; set; }

	public virtual ICollection<WSOrderDefaultSetting> WSOrderDefaultSetting { get; set; }

	public virtual ICollection<WSPreOrderDefaultSetting> WSPreOrderDefaultSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSProductPriceGroup()
	{
		WSProductPrice = (ICollection<WSProductPrice>)new HashSet<WSProductPrice>();
		WSProductPriceGroup_Lang = (ICollection<WSProductPriceGroup_Lang>)new HashSet<WSProductPriceGroup_Lang>();
		WSUserFavproductItems = (ICollection<WSUserFavproductItems>)new HashSet<WSUserFavproductItems>();
		WSPreOrder = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
		CrmMobSetting = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		WSProductImportFromExcel = (ICollection<WSProductImportFromExcel>)new HashSet<WSProductImportFromExcel>();
		WSOrderDefaultSetting = (ICollection<WSOrderDefaultSetting>)new HashSet<WSOrderDefaultSetting>();
		WSPreOrderDefaultSetting = (ICollection<WSPreOrderDefaultSetting>)new HashSet<WSPreOrderDefaultSetting>();
	}
}
