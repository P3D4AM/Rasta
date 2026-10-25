using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSDeliveryScheduleExceptLanguageViewModel
{
	[Key]
	public int DeliveryScheduleExceptId { get; set; }

	public DateTime ExDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DelvSchExDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string ExDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DelvSchExFTime")]
	[RegularExpression("^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ExFTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DelvSchExTTime")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[RegularExpression("^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	[MaxLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ExTTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DelvSchExCnt")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int ExCnt { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DelvSchExDesc")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ExDesc { get; set; }

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

	[Display(ResourceType = typeof(Labels), Name = "DelvSchExTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ExTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DelvSchExPrd")]
	public string ExPrdJson { get; set; }

	public string PrdjsonByName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DelvSchExDeActive")]
	public bool? ExDeActive { get; set; }

	public string ExDesc_Lang { get; set; }

	public string ExTitle_Lang { get; set; }
}
