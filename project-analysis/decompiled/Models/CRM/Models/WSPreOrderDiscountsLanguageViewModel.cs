using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSPreOrderDiscountsLanguageViewModel
{
	[Key]
	public int PreOrderDiscountId { get; set; }

	public int pordDisPreOrderId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDisDiscountStrategyId")]
	public int? pordDisDiscountStrategyId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDisTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordDisTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDisAmount")]
	public decimal? pordDisAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordDisPercent")]
	public decimal? pordDisPercent { get; set; }

	public int? pordDisPrdId { get; set; }

	public string pordDisPrdName { get; set; }

	public string pordDisPrdJson { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string AppType { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public string pordDisTitle_Lang { get; set; }
}
