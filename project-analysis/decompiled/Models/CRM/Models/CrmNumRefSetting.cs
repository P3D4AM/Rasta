using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmNumRefSettingMetadata))]
public class CrmNumRefSetting
{
	public int NumRefSettingId { get; set; }

	public string prjNumRefFormula { get; set; }

	public string pordNumRefFormula { get; set; }

	public string ordNumRefFormula { get; set; }

	public string bordNumRefFormula { get; set; }

	public string DocNumRefFormula { get; set; }

	public string ctshNumRefFormula { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string FileDirectoryNumRefFormula { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }
}
