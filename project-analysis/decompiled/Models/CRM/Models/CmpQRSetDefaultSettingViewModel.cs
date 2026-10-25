using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CmpQRSetDefaultSettingViewModel
{
	public int? cmpQDefCountryId { get; set; }

	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpQDefProjectTitle { get; set; }

	public int? cmpQDefProjectGroupId { get; set; }

	public int? cmpQDefcnvsTopicId { get; set; }

	public bool? cmpQNotNullProjectGroup { get; set; }

	public bool? cmpQNotNullProjectGrade { get; set; }

	public bool? cmpQNotNullProjectPriority { get; set; }

	public bool? cmpQDefPrintAfterSave { get; set; }
}
