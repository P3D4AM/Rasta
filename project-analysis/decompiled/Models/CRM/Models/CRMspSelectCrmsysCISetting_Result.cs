using System;

namespace CRM.Models;

public class CRMspSelectCrmsysCISetting_Result
{
	public int Id { get; set; }

	public string DeviceName { get; set; }

	public string ComPort { get; set; }

	public string ComSetting { get; set; }

	public int? StartLineNumber { get; set; }

	public string CIServerIP { get; set; }

	public string SrvName { get; set; }

	public string DBName { get; set; }

	public string SUser { get; set; }

	public string SPass { get; set; }

	public bool? IsActive { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? DeviceTypeId { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string VoipApiType { get; set; }

	public string VoipApiUrl { get; set; }

	public string VoipUDPIpAddress { get; set; }

	public string VoipUDPPort { get; set; }

	public string VoipCount { get; set; }

	public string VoipTrunkCount { get; set; }
}
