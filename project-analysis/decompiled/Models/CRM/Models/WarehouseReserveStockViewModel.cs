using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WarehouseReserveStockViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "WareHouseStockWhrName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int WHId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseStockFgName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int FGId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseStockSgName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int SGId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseStockPrdName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int PrdId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseStockPrdModel")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string PrdModel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseStockPrdTracing")]
	public string Tracing { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseStockPrdKind")]
	public int PrdKind { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseStockPrdInActive")]
	public int PrdInActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseReserveStockFDate")]
	public string FDate { get; set; }

	public DateTime? FDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseReserveStockTDate")]
	public string TDate { get; set; }

	public DateTime? TDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseReserveStockExpFDate")]
	public string ExpireFDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseReserveStockExpTDate")]
	public string ExpireTDate { get; set; }

	public bool IsExpireDateEmpty { get; set; }

	public DateTime? ExpireFDateTime { get; set; }

	public DateTime? ExpireTDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseStockPrdType")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string PrdType { get; set; }
}
