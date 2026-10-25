using System;
using System.ComponentModel.DataAnnotations;

namespace Mobile.Models;

[MetadataType(typeof(MobCompanyAppInfoMetadata))]
public class MobCompanyAppInfo
{
	public int MobCompanyAppInfoID { get; set; }

	public int CompanyID { get; set; }

	public int CompanyPersonID { get; set; }

	public string RegisterCode { get; set; }

	public string DownloadURL { get; set; }

	public string WcfURL { get; set; }

	public string ExtraCode { get; set; }

	public bool? IsActive { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public Guid? GUId { get; set; }

	public string ImeiCode { get; set; }

	public string cmp { get; set; }

	public int? DevTypeId { get; set; }

	public string AppName { get; set; }

	public string LastVersion { get; set; }

	public string NewVersionDownloadURL { get; set; }

	public string CurrentVersion { get; set; }

	public bool? NewVersionAlarmActive { get; set; }

	public bool? JustLastVersionActive { get; set; }

	public string AppDomain { get; set; }

	public string PwaServerUrl { get; set; }
}
