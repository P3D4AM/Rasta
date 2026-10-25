using System;

namespace CRM.Models;

public class SecspSearchLetters_Result
{
	public int LetterId { get; set; }

	public int LetterTypeId { get; set; }

	public string LetterPreNumber { get; set; }

	public long LetterNumber { get; set; }

	public string LetterPreNumberII { get; set; }

	public long? LetterNumberII { get; set; }

	public int? LetterCompanyId { get; set; }

	public int? LetterPersonId { get; set; }

	public int? LetterProjectId { get; set; }

	public string LetterSubject { get; set; }

	public DateTime LetterDateTime { get; set; }

	public string LetterDate { get; set; }

	public string Company { get; set; }

	public string Person { get; set; }

	public string Project { get; set; }
}
