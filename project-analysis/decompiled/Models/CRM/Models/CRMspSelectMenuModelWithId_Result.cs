using System;

namespace CRM.Models;

public class CRMspSelectMenuModelWithId_Result
{
	public int MenuModelID { get; set; }

	public int? MenuTypeId { get; set; }

	public string MenuType { get; set; }

	public string Title { get; set; }

	public bool? IsDefault { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public int? OrderView { get; set; }
}
