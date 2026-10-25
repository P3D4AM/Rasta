using System;

namespace CRM.Models;

public class SmsspSelectDefaultBodyTextInMode_Result
{
	public int Id { get; set; }

	public string Title { get; set; }

	public string Text { get; set; }

	public string Description { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? GroupId { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string GroupName { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }
}
