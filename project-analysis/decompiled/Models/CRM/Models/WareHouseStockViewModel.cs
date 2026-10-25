using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WareHouseStockViewModel
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

	public double EqualStkVal { get; set; }

	public double MaxStkVal { get; set; }

	public double MinStkVal { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int Mode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseStockPrdModel")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string PrdModel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseStockPrdTracing")]
	public string Tracing { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseStockPrdKind")]
	public int PrdKind { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseStockPrdInActive")]
	public int PrdInActive { get; set; }

	public bool isNotUsePrdInDoc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseStockPrdFDate")]
	public string FDate { get; set; }

	public DateTime? FDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseStockPrdTDate")]
	public string TDate { get; set; }

	public DateTime? TDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseStockPrdType")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string PrdType { get; set; }
}
