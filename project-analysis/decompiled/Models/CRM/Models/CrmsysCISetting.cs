using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmsysCISettingMetadata))]
public class CrmsysCISetting
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

	public string C2CUrl { get; set; }

	public string ApiUser { get; set; }

	public string ApiPass { get; set; }

	public string RecFileDlUrl { get; set; }

	public virtual CrmsysCIDeviceType CrmsysCIDeviceType { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }
}
