using System;

namespace Mobile.Models;

public class MobspSelectCompanyLetters_Result
{
	public int LetterId { get; set; }

	public int LetterTypeId { get; set; }

	public DateTime LetterDateTime { get; set; }

	public string LetterPreNumber { get; set; }

	public long LetterNumber { get; set; }

	public string LetterPreNumberII { get; set; }

	public long? LetterNumberII { get; set; }

	public int? LetterCompanyId { get; set; }

	public int? LettercmpPersonId { get; set; }

	public string LettercmpPersonNickName { get; set; }

	public int? LettercmpProjectId { get; set; }

	public string LetterSubject { get; set; }

	public string LettercmpPerson { get; set; }

	public string LettercmpProject { get; set; }

	public string LetterType { get; set; }

	public long? RowNum { get; set; }

	public int? AllPage { get; set; }

	public string LetterCompany { get; set; }

	public int? LetterPrintFormatId { get; set; }

	public bool? LetterIsVerified { get; set; }

	public bool? LetterIsFixed { get; set; }
}
