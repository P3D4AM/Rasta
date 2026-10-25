using System;
using System.Collections.Generic;

namespace Mobile.Models;

public class LoginResult
{
	public string token { get; set; }

	public string FullName { get; set; }

	public int UserId { get; set; }

	public int RollId { get; set; }

	public string RollName { get; set; }

	public string CoordinateLatitude { get; set; }

	public string CoordinateLongitude { get; set; }

	public string CoordinateLastDate { get; set; }

	public string CoordinateLastTime { get; set; }

	public string CoordinateLastDatePersian { get; set; }

	public Dictionary<string, bool> Permissions { get; set; }

	public string CoName { get; set; }

	public bool LimitPreOrderDiscountActive { get; set; }

	public decimal LimitPreOrderDiscountPercent { get; set; }

	public bool LimitOrderDiscountActive { get; set; }

	public decimal LimitOrderDiscountPercent { get; set; }

	public int MaxNumberCmpDraft { get; set; }

	public bool? MobDeActiveAccessToLocation { get; set; }

	public bool? UserAccessDailyChrtAllUsers { get; set; }

	public bool? UserAccessSaleChrtAllUsers { get; set; }

	public bool? DeActiveSmartTimeAttendance { get; set; }

	public string MobImeiCode { get; set; }

	public bool MobFinancial { get; set; }

	public bool VBTicketPlus { get; set; }

	public bool VBPreOrder { get; set; }

	public bool VBOrder { get; set; }

	public bool VBPordPlus { get; set; }

	public bool VBMobDyForm { get; set; }

	public bool VBDyForm { get; set; }

	public bool VBLeave { get; set; }

	public bool VBWareHouse { get; set; }

	public bool VBWareHouseUserPermission { get; set; }

	public bool VBProjectProductHistory { get; set; }

	public bool VBSmartTimeAttendance { get; set; }

	public bool VBIssueMultiDraftFromOrd { get; set; }

	public bool VBLetters { get; set; }

	public bool VBLetterNumberCounter { get; set; }

	public bool VBEmails { get; set; }

	public bool VBSms { get; set; }

	public List<string> MaliciousFileExtensions { get; set; }

	public int MaxFileSizeForUploadMb { get; set; }

	public int MaxFileCountForUpload { get; set; }

	public int FileDirectoryTitleLength { get; set; }

	public bool? ActiveMobMovementTracking { get; set; }

	public double? MobMovementTrackingDistanceInterval { get; set; }

	public int? MobMovementTrackingTimeInterval { get; set; }

	public string DefMapType { get; set; }

	public string DepartmentInfo { get; set; }

	public int? ResponsibleUserId { get; set; }

	public string ResponsibleUser { get; set; }

	public bool? MobDeActiveScreenshot { get; set; }

	public string DefCmpPrjTitle { get; set; }

	public bool? MobCallerIdDeActive { get; set; }

	public string MobAppDevSetting { get; set; }

	public int MaxFileCountToDwonload { get; set; }

	public DateTime ServerCurrentDateTime { get; set; }

	public int MobHRMLoginMode { get; set; }

	public int? UserLastCId { get; set; }

	public string UserCIds { get; set; }

	public bool VBFund { get; set; }

	public bool VBCenter { get; set; }

	public bool VBLinkAcc { get; set; }

	public bool? AppLocationRequired { get; set; }

	public int? ShiftWorkingId { get; set; }

	public string UserExtensions { get; set; }

	public string TimeAttendanceLocation { get; set; }
}
