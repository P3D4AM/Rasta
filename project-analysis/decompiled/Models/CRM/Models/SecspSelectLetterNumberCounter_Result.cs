using System;

namespace CRM.Models;

public class SecspSelectLetterNumberCounter_Result
{
	public int LetterNumberCounterId { get; set; }

	public int LetterTypeId { get; set; }

	public string LetterType { get; set; }

	public string LtrNumCntTitle { get; set; }

	public long LtrNumCntBeginner { get; set; }

	public string LtrNumCntPreNumber { get; set; }

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

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }
}
