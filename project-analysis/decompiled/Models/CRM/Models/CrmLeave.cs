using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLeaveMetadata))]
public class CrmLeave
{
	public int LeaveId { get; set; }

	public int? LeaveTypeId { get; set; }

	public int? RequestUserId { get; set; }

	public int? ReplaceUserId { get; set; }

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

	public int? CountryId { get; set; }

	public int? ProvinceId { get; set; }

	public int? CityId { get; set; }

	public int? VehicleTypeId { get; set; }

	public int? StayTypeId { get; set; }

	public int? LeaveStatusId { get; set; }

	public int? VerifierUserId { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

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

	public bool? IsCanceled { get; set; }

	public int? CancelerUserId { get; set; }

	public DateTime? CanceledDate { get; set; }

	public string CanceledDatePersian { get; set; }

	public int? ReplaceUserIntMsgId { get; set; }

	public string DailyDateTimeInfo { get; set; }

	public int? StepGroupId { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? ProjectId { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual City City { get; set; }

	public virtual Country Country { get; set; }

	public virtual CrmLeaveKinds CrmLeaveKinds { get; set; }

	public virtual CrmLeaveStatus CrmLeaveStatus { get; set; }

	public virtual CrmLeaveStayType CrmLeaveStayType { get; set; }

	public virtual CrmLeaveType CrmLeaveType { get; set; }

	public virtual CrmLeaveVehicleType CrmLeaveVehicleType { get; set; }

	public virtual Province Province { get; set; }

	public virtual WSVerificationWorkFlows WSVerificationWorkFlows { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual CrmInternalMessage CrmInternalMessage { get; set; }

	public virtual ICollection<CrmTimeAttendance> CrmTimeAttendance { get; set; }

	public virtual CrmCompanyPersons CrmCompanyPersons { get; set; }

	public virtual CrmProjects CrmProjects { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public CrmLeave()
	{
		CrmTimeAttendance = (ICollection<CrmTimeAttendance>)new HashSet<CrmTimeAttendance>();
	}
}
