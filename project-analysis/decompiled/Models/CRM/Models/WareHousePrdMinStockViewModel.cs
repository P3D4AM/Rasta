using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WareHousePrdMinStockViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "WareHousePrdMinStockWithWh")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int WHId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHousePrdMinStockWithFG")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int FGId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHousePrdMinStockWithSG")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int SGId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHousePrdMinStockWithTracing")]
	public string Tracing { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHousePrdMinStockWithKind")]
	public int PrdKind { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHousePrdMinStockWithInActive")]
	public int PrdInActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHousePrdMinStockWithPrd")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int PrdId { get; set; }

	public int MinStock { get; set; }
}
