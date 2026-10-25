using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class ProductValidityIndicatorViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "PrdValidityIndicatorPrdId")]
	public string PrdValidityIndicatorPrdId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdValidityIndicatorFromDate")]
	public string FromPordIValidityExpireDateEnd { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdValidityIndicatorToDate")]
	public string ToPordIValidityExpireDateEnd { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdValidityIndicatorFromDate")]
	public string FromPordIValidityExpireDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdValidityIndicatorToDate")]
	public string ToPordIValidityExpireDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdValidityIndicatorPordOpr")]
	public int? PreOrderOprId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdValidityIndicatorPordType")]
	public int? PreOrderTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdValidityIndicatorFromDate")]
	public string FromPordDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdValidityIndicatorToDate")]
	public string ToPordDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdValidityIndicatorFromDate")]
	public string FromOrdIValidityExpireDateEnd { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdValidityIndicatorToDate")]
	public string ToOrdIValidityExpireDateEnd { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdValidityIndicatorFromDate")]
	public string FromOrdIValidityExpireDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdValidityIndicatorToDate")]
	public string ToOrdIValidityExpireDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdValidityIndicatorOrdOpr")]
	public int? OrderOprId { get; set; }
}
