using System;

namespace Mobile.Models;

public class MobspResultsDailyCartable_Result
{
	public long? RowNumber { get; set; }

	public int companyId { get; set; }

	public string CompanyName { get; set; }

	public string personName { get; set; }

	public string prsPreTel { get; set; }

	public string prsTel { get; set; }

	public string prsTelUpTo { get; set; }

	public string prsTelDesc { get; set; }

	public string prsMobile { get; set; }

	public string projectTitle { get; set; }

	public int projectId { get; set; }

	public int? prjcnvsStatusGroupId { get; set; }

	public int conversationId { get; set; }

	public string cnvsDesc { get; set; }

	public int? cnvsStatusId { get; set; }

	public string cnvsStatus { get; set; }

	public int? progressPercent { get; set; }

	public string progressPercentWD { get; set; }

	public string remindDate { get; set; }

	public DateTime? remindDateTime { get; set; }

	public string cnvsTime { get; set; }

	public string cnvsDay { get; set; }

	public string cnvsDate { get; set; }

	public DateTime? cnvsDateTime { get; set; }

	public string registerDatePersian { get; set; }

	public DateTime registerDate { get; set; }

	public string priority { get; set; }

	public string priorityColor { get; set; }

	public int? priorityId { get; set; }

	public string cnvsUserName { get; set; }

	public string cnvsReferName { get; set; }

	public int? cnvsUserId { get; set; }

	public int? cnvsReferUserId { get; set; }

	public int userId { get; set; }

	public string cmpPreTel { get; set; }

	public string cmpTel { get; set; }

	public string cmpTelUpTo { get; set; }

	public string cmpTelDesc { get; set; }

	public string cmpPreTelII { get; set; }

	public string cmpTelII { get; set; }

	public string cmpTelUpToII { get; set; }

	public string cmpTelIIDesc { get; set; }

	public string cmpFax { get; set; }

	public string cmpFaxDesc { get; set; }

	public int? cmpCountryId { get; set; }

	public string cmpCountry { get; set; }

	public int? cmpProvinceId { get; set; }

	public string cmpProvince { get; set; }

	public int? cmpCityId { get; set; }

	public string cmpCity { get; set; }

	public string cmpAddress { get; set; }

	public string cmpPresentation { get; set; }

	public int? cnvsPersonId { get; set; }

	public DateTime? cnvsRemindDateTimeForAllarm { get; set; }

	public bool? cnvsRemindOk { get; set; }

	public int? AllPage { get; set; }
}
