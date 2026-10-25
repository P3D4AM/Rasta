using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class DocGenerateDocItemSerialViewModel
{
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "DocGenerateSerialCount")]
	public int Count { get; set; }

	public int ItemId { get; set; }

	public int WHId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocGenerateSerialDescription")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Description { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocGenerateSerialExpDate")]
	public DateTime? ExpDate { get; set; }

	public string ExpDate_Text { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocGenerateSerialExpDatePersian")]
	public string ExpDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocGenerateSerialPreFixSerial")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PreFixSerial { get; set; }

	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Serial { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocGenerateSerialIncSerial")]
	public bool? IncSerial { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocGenerateSerialPreFixInfoI")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PreFixInfoI { get; set; }

	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string InfoI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocGenerateSerialIncInfoI")]
	public bool? IncInfoI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocGenerateSerialPreFixInfoII")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PreFixInfoII { get; set; }

	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string InfoII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocGenerateSerialIncInfoII")]
	public bool? IncInfoII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocGenerateSerialPreFixInfoIII")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PreFixInfoIII { get; set; }

	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string InfoIII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocGenerateSerialIncInfoIII")]
	public bool? IncInfoIII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocGenerateSerialPreFixInfoIV")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PreFixInfoIV { get; set; }

	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string InfoIV { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocGenerateSerialIncInfoIV")]
	public bool? IncInfoIV { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocGenerateSerialPreFixInfoV")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PreFixInfoV { get; set; }

	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string InfoV { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocGenerateSerialIncInfoV")]
	public bool? IncInfoV { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocGenerateSerialPreFixInfoVI")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PreFixInfoVI { get; set; }

	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string InfoVI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocGenerateSerialIncInfoVI")]
	public bool? IncInfoVI { get; set; }

	public int DocId { get; set; }

	public string Description_Lang { get; set; }
}
