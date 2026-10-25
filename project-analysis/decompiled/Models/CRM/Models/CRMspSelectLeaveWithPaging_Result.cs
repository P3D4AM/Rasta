using System;

namespace CRM.Models;

public class CRMspSelectLeaveWithPaging_Result
{
	public int LeaveId { get; set; }

	public int? LeaveTypeId { get; set; }

	public int? RequestUserId { get; set; }

	public int? ReplaceUserId { get; set; }

	public string FromDate { get; set; }

	public string FromDateI { get; set; }

	public string ToDate { get; set; }

	public int? DayCount { get; set; }

	public string FromTime { get; set; }

	public string ToTime { get; set; }

	public string HourCount { get; set; }

	public string Reason { get; set; }

	public string Description { get; set; }

	public int? KindId { get; set; }

	public string Place { get; set; }

	public int? CompanyId { get; set; }

	public int? CountryId { get; set; }

	public int? ProvinceId { get; set; }

	public int? CityId { get; set; }

	public int? VehicleTypeId { get; set; }

	public int? StayTypeId { get; set; }

	public int? LeaveStatusId { get; set; }

	public int? VerifierUserId { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public DateTime? FromDateTime { get; set; }

	public DateTime? ToDateTime { get; set; }

	public string PlaceCoordinateLatitude { get; set; }

	public string PlaceCoordinateLongitude { get; set; }

	public int? PlaceCoordinateZoomLevel { get; set; }

	public string LeaveLang { get; set; }

	public bool? ReplaceUserIsVerified { get; set; }

	public DateTime? ReplaceUserVerifiedDate { get; set; }

	public string ReplaceUserVerifiedDatePersian { get; set; }

	public DateTime? VerifiedRegisterDate { get; set; }

	public string VerifiedRegisterDatePersian { get; set; }

	public int? VerificationWorkFlowId { get; set; }

	public string VerificationWorkFlow { get; set; }

	public int? LeaveTypeOpr { get; set; }

	public int? UserDepartmentLeaveVerificationWorkFlowId { get; set; }

	public int? UserDepartmentMissionVerificationWorkFlowId { get; set; }

	public string UserDepartmentLeaveVerificationWorkFlow { get; set; }

	public string UserDepartmentMissionVerificationWorkFlow { get; set; }

	public string LeaveType { get; set; }

	public string RequestUser { get; set; }

	public string ReplaceUser { get; set; }

	public string Kind { get; set; }

	public string Company { get; set; }

	public string Country { get; set; }

	public string Province { get; set; }

	public string City { get; set; }

	public string VehicleType { get; set; }

	public string StayType { get; set; }

	public string LeaveStatus { get; set; }

	public string VerifierUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public bool? IsCanceled { get; set; }

	public int? CancelerUserId { get; set; }

	public DateTime? CanceledDate { get; set; }

	public string CanceledDatePersian { get; set; }

	public string CancelerUser { get; set; }

	public int? ReplaceUserIntMsgId { get; set; }

	public string DailyDateTimeInfo { get; set; }

	public int? StepGroupId { get; set; }

	public string StepGroup { get; set; }

	public int? TotalCount { get; set; }
}
