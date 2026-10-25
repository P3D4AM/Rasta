using System;

namespace Mobile.Models;

public class LetterIndicatorViewModel
{
	public string LetterTypeId { get; set; }

	public DateTime? LetterFDateTime { get; set; }

	public DateTime? LetterTDateTime { get; set; }

	public string LetterPreNumber { get; set; }

	public string LetterNumber { get; set; }

	public string LetterCompanyNameId { get; set; }

	public string LetterSubject { get; set; }

	public string LetterSubjectLikely { get; set; }

	public string LetterContext { get; set; }

	public string LetterContextLikely { get; set; }

	public int? PageNumber { get; set; }

	public int? PageSize { get; set; }

	public int? LanguageId { get; set; }

	public int? CenterId { get; set; }
}
