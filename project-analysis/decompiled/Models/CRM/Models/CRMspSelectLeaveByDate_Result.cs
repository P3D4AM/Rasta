using System;

namespace CRM.Models;

public class CRMspSelectLeaveByDate_Result
{
	public int LeaveId { get; set; }

	public int? LeaveTypeId { get; set; }

	public string LeaveType { get; set; }

	public int? RequestUserId { get; set; }

	public string RequestUser { get; set; }

	public int? ReplaceUserId { get; set; }

	public string ReplaceUser { get; set; }

	public string FromDate { get; set; }

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

	public string Company { get; set; }

	public int? CountryId { get; set; }

	public string Country { get; set; }

	public int? ProvinceId { get; set; }

	public string Province { get; set; }

	public int? CityId { get; set; }

	public string City { get; set; }

	public int? VehicleTypeId { get; set; }

	public string VehicleType { get; set; }

	public int? StayTypeId { get; set; }

	public string StayType { get; set; }

	public int? LeaveStatusId { get; set; }

	public string LeaveStatus { get; set; }

	public int? VerifierUserId { get; set; }

	public string VerifierUser { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public DateTime? FromDateTime { get; set; }

	public DateTime? ToDateTime { get; set; }

	public string PlaceCoordinateLatitude { get; set; }

	public string PlaceCoordinateLongitude { get; set; }

	public int? PlaceCoordinateZoomLevel { get; set; }

	public bool? ReplaceUserIsVerified { get; set; }

	public DateTime? ReplaceUserVerifiedDate { get; set; }

	public string ReplaceUserVerifiedDatePersian { get; set; }

	public DateTime? VerifiedRegisterDate { get; set; }

	public string VerifiedRegisterDatePersian { get; set; }

	public int? VerificationWorkFlowId { get; set; }

	public string VerificationWorkFlow { get; set; }

	public bool? IsCanceled { get; set; }

	public int? CancelerUserId { get; set; }

	public string CancelerUser { get; set; }

	public DateTime? CanceledDate { get; set; }

	public string CanceledDatePersian { get; set; }

	public int? ReplaceUserIntMsgId { get; set; }

	public string DailyDateTimeInfo { get; set; }

	public bool? IsEnteryRegistered { get; set; }

	public int? StepGroupId { get; set; }

	public string StepGroup { get; set; }

	public int? CompanyPersonId { get; set; }

	public string CompanyPerson { get; set; }

	public int? ProjectId { get; set; }

	public string Project { get; set; }
}
