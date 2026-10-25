using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmsysDBTempInfoMetadata))]
public class CrmsysDBTempInfo
{
	public long ID { get; set; }

	public int? UserId { get; set; }

	public Guid? GUId { get; set; }

	public int? TypeId { get; set; }

	public string TXT { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string TXTObjType { get; set; }

	public string TXTJsResult { get; set; }

	public virtual CrmsysDBTempInfoType CrmsysDBTempInfoType { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }
}
