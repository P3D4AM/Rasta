using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSUserFavproductsLanguageViewModel
{
	[Key]
	public int UserFavproductId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FavprdTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FavprdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FavprdDesc")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FavprdDesc { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? OrderView { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FavprdPriceGroupID")]
	public int? FavprdPriceGroupID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FavprdInActive")]
	public bool? FavprdInActive { get; set; }

	public string FavprdTitle_Lang { get; set; }

	public string FavprdDesc_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FavprdUseInIssueQuick")]
	public bool? FavprdUseInIssueQuick { get; set; }
}
