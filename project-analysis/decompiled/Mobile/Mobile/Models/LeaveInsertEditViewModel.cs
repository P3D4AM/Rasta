using System;

namespace Mobile.Models;

public class LeaveInsertEditViewModel
{
	public bool IsEdit { get; set; }

	public int? LeaveId { get; set; }

	public int? LeaveTypeId { get; set; }

	public int? RequestUserId { get; set; }

	public int? ReplaceUserId { get; set; }

	public DateTime? FromDateTime { get; set; }

	public string FromDate { get; set; }

	public DateTime? ToDateTime { get; set; }

	public string ToDate { get; set; }

	public DateTime? RequestDateTime { get; set; }

	public string RequestDate { get; set; }

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

	public string PlaceCoordinateLatitude { get; set; }

	public string PlaceCoordinateLongitude { get; set; }

	public int? PlaceCoordinateZoomLevel { get; set; }

	public int? LanguageId { get; set; }

	public string MsgLangValue { get; set; }

	public string Reason_Lang { get; set; }

	public string Place_Lang { get; set; }
}
