using System;
using System.Collections.Generic;

namespace CRM.Models;

public class CrmHourlyMissionDetailsViewModel
{
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

	public int? LeaveTypeId { get; set; }

	public DateTime? FromDateTime { get; set; }

	public string FromDate { get; set; }

	public DateTime? ToDateTime { get; set; }

	public string ToDate { get; set; }

	public int? LeaveStatusId { get; set; }

	public string LeaveStatus { get; set; }

	public int? VerifierUserId { get; set; }

	public string VerifierUser { get; set; }

	public string RequestDateTimeStr { get; set; }

	public string Description { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime RegisterDate { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public string LeaveStatusStr { get; set; }

	public int? KindId { get; set; }

	public string Kind { get; set; }

	public string Place { get; set; }

	public string Place_Lang { get; set; }

	public int? CompanyId { get; set; }

	public string Company { get; set; }

	public int? CountryId { get; set; }

	public string Country { get; set; }

	public int? ProvinceId { get; set; }

	public string Province { get; set; }

	public int? CityId { get; set; }

	public string City { get; set; }

	public string CityFullName { get; set; }

	public int? VehicleTypeId { get; set; }

	public string VehicleType { get; set; }

	public int? StayTypeId { get; set; }

	public string StayType { get; set; }

	public string PlaceCoordinateLatitude { get; set; }

	public string PlaceCoordinateLongitude { get; set; }

	public int? PlaceCoordinateZoomLevel { get; set; }

	public int? VerificationWorkFlowId { get; set; }

	public int? LeaveVerificationWorkFlowId { get; set; }

	public bool? ReplaceUserIsVerified { get; set; }

	public bool? IsCanceled { get; set; }

	public int? CancelerUserId { get; set; }

	public string CancelerUser { get; set; }

	public string CanceledDatePersian { get; set; }

	public string LeaveCancelStr { get; set; }

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

	public DateTime? VerifiedRegisterDate { get; set; }

	public string VerifiedRegisterDatePersian { get; set; }

	public WSspSelectVerificationWorkFlowWithId_Result VerificationWorkFlowItem { get; set; }

	public List<WSspSelectVerificationWorkFlowSteps_Result> VerificationWorkFlowStepsList { get; set; }

	public WSspSelectVerificationRequests_Result VerificationRequestItem { get; set; }

	public List<WSspSelectVerificationRequestDetails_Result> VerificationRequestDetailsList { get; set; }
}
