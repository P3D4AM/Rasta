using System;

namespace CRM.Models;

public class CrmHourlyMissionInsertEditLanguageViewModel
{
	public bool IsEdit { get; set; }

	public int? LeaveId { get; set; }

	public int? RequestUserId { get; set; }

	public int? ReplaceUserId { get; set; }

	public string ReplaceUser { get; set; }

	public string RequestUser { get; set; }

	public DateTime? RequestDateTime { get; set; }

	public string RequestDate { get; set; }

	public string FromTime { get; set; }

	public string ToTime { get; set; }

	public string HourCount { get; set; }

	public string Reason { get; set; }

	public string Reason_Lang { get; set; }

	public int? KindId { get; set; }

	public int? StayTypeId { get; set; }

	public int? VehicleTypeId { get; set; }

	public int? StepGroupId { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? ProjectId { get; set; }

	public string Place { get; set; }

	public string Place_Lang { get; set; }

	public int? CompanyId { get; set; }

	public string Company { get; set; }

	public int? CountryId { get; set; }

	public int? ProvinceId { get; set; }

	public int? CityId { get; set; }

	public string CityFullName { get; set; }

	public string PlaceCoordinateLatitude { get; set; }

	public string PlaceCoordinateLongitude { get; set; }

	public int? PlaceCoordinateZoomLevel { get; set; }

	public int? LeaveTypeId { get; set; }

	public DateTime? FromDateTime { get; set; }

	public string FromDate { get; set; }

	public DateTime? ToDateTime { get; set; }

	public string ToDate { get; set; }

	public string MsgLangValue { get; set; }

	public int? DayCount { get; set; }

	public int? LeaveStatusId { get; set; }

	public int MonthlyDailySum { get; set; }

	public int MonthlyHourlySumInMin { get; set; }

	public string MonthlyHourlySumTxt { get; set; }

	public int YearlyDailySum { get; set; }

	public int YearlyHourlySumInMin { get; set; }

	public string YealyHourlySumTxt { get; set; }

	public int TotallyDailySum { get; set; }

	public int TotallyHourlySumInMin { get; set; }

	public string TotallyHourlySumTxt { get; set; }

	public string MonthlyLeaveStr { get; set; }

	public string YearlyLeaveStr { get; set; }

	public string TotallyLeaveStr { get; set; }

	public string UserDepartment { get; set; }

	public string UserResponsible { get; set; }

	public string DailyDateTimeInfo { get; set; }
}
