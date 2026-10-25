using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CRMResultsReminderCartableViewModel
{
	[Key]
	public int CompanyID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpName")]
	public string CompanyName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsPerson")]
	public string Person { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsPreTel")]
	public string prsPreTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsTel")]
	public string prsTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsTelUpTo")]
	public string prsTelUpTo { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsTelDesc")]
	public string prsTelDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsMobile")]
	public string prsMobile { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cKartablProjectTitle")]
	public string prjTitle { get; set; }

	public int ProjectID { get; set; }

	public int ConversationId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDesc")]
	public string cnvsDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusId")]
	public int? cnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatus")]
	public string cnvsStatus { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CReminderProgressPercent")]
	public int? ProgressPercent { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CReminderProgressPercent")]
	public string ProgressPercentWD { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CReminderRemindDate")]
	public string RemindDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDay")]
	public string cnvsDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CcnvsDate")]
	public string cnvsDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cKartablRegisterDate")]
	public string RegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cKartablPriority")]
	public string Priority { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cKartablPriority")]
	public string PriorityColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cKartablPriority")]
	public int? PriorityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsUserId")]
	public string cnvsUserName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CcnvsReferUserId")]
	public string cnvsReferName { get; set; }

	public int UserId { get; set; }

	public int? cnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpPreTel")]
	public string cmpPreTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTel")]
	public string cmpTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelUpTo")]
	public string cmpTelUpTo { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelDesc")]
	public string cmpTelDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpPreTelII")]
	public string cmpPreTelII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelII")]
	public string cmpTelII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelUpToII")]
	public string cmpTelUpToII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelIIDesc")]
	public string cmpTelIIDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFax")]
	public string cmpFax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFaxDesc")]
	public string cmpFaxDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpCountryId")]
	public int? cmpCountryId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpCountryId")]
	public string Country { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpProvinceId")]
	public int? cmpProvinceId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpProvinceId")]
	public string Province { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpCityId")]
	public int? cmpCityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpCityId")]
	public string City { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpAddress")]
	public string cmpAddress { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsPersonId")]
	public int? cnvsPersonId { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsRemindDateForAllarm")]
	public string cnvsRemindDateForAllarm { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CcnvsTime")]
	public string cnvsTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsRemindTime")]
	public string cnvsRemindTime { get; set; }

	public string TimeForSort { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpPresentationId")]
	public string cmpPresentation { get; set; }
}
