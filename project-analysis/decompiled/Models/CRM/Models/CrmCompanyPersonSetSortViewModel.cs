using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmCompanyPersonSetSortViewModel
{
	[Key]
	public int CompanyPersonID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsCompanyId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int prsCompanyId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsLName")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsLName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsFName")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsFName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsTitleId")]
	public int? prsTitleId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsTitleId")]
	public string prsTitleIdStr { get; set; }

	public string prsPerson => prsTitleIdStr + " " + prsLName + " " + prsFName;

	[Display(ResourceType = typeof(Labels), Name = "prsJobId")]
	public int? prsJobId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsJobId")]
	public string prsJobIdStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsDepartmentId")]
	public int? prsDepartmentId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsDepartmentId")]
	public string prsDepartmentIdStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsWorkingOut")]
	public bool? prsWorkingOut { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsWorkingOut")]
	public bool prsWorkingOutTitle
	{
		get
		{
			if (!prsWorkingOut.HasValue)
			{
				return false;
			}
			if (prsWorkingOut.HasValue && prsWorkingOut == false)
			{
				return false;
			}
			return true;
		}
	}

	[Display(ResourceType = typeof(Labels), Name = "prsOrderView")]
	public int? prsOrderView { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }
}
