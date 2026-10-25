using System;

namespace CRM.Models;

public class CRMspSelectDefaultFormObjectProperties_Result
{
	public int ID { get; set; }

	public int? FormId { get; set; }

	public string ObjectType { get; set; }

	public string ObjectName { get; set; }

	public string ObjectPersianName { get; set; }

	public bool? Visible { get; set; }

	public bool? Enable { get; set; }

	public int? Leftt { get; set; }

	public int? Topp { get; set; }

	public int? Width { get; set; }

	public int? Height { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? UserId { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? LanguageID { get; set; }
}
