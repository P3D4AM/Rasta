using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmShowTableFieldInFOMetadata))]
public class CrmShowTableFieldInFO
{
	public int ID { get; set; }

	public string TableName { get; set; }

	public int? TableId { get; set; }

	public string FieldName { get; set; }

	public bool? Visible { get; set; }

	public int? OrderView { get; set; }

	public bool? IsActive { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }
}
