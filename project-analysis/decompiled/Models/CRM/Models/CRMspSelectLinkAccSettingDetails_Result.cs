using System;

namespace CRM.Models;

public class CRMspSelectLinkAccSettingDetails_Result
{
	public int LinkAccSettingDetailId { get; set; }

	public int LinkAccSettingId { get; set; }

	public int? ObjectId { get; set; }

	public string PartField { get; set; }

	public string PartValue { get; set; }

	public string Description { get; set; }

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

	public string EditUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public string PartTitle { get; set; }

	public string ObjectTypeTitle { get; set; }

	public string ObjectType { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }
}
