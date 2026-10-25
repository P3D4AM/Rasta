using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSDiscountCodeLanguageViewModel
{
	[Key]
	public int DiscountCodeId { get; set; }

	public int Mode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DisCodeTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DisTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DisCode")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DisCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DisCodeAmount")]
	public decimal? DisAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DisCodeAmountPercent")]
	public decimal? DisAmountPercent { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DisCodeExpDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string DisExpDatePersian { get; set; }

	public DateTime DisExpDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DisCodeCmpId")]
	public int? DisCmpId { get; set; }

	public string DisCmpName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DisCodePrdId")]
	public int? DisPrdId { get; set; }

	public string DisPrdName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DisCodeUseCnt")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int DisUseCnt { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public string DisTitle_Lang { get; set; }

	public double? ScoreRate { get; set; }

	public bool? DisCanChangeToScore { get; set; }

	public int? DisUseCntPerCmp { get; set; }
}
