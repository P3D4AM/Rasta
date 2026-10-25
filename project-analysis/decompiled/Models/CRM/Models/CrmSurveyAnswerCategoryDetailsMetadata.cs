using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmSurveyAnswerCategoryDetailsMetadata
{
	[Key]
	public int SurveyAnswerCategoryDetailId { get; set; }

	public int suracdCategoryId { get; set; }

	public string suracdDetailTitle { get; set; }

	public bool? suracdInactive { get; set; }

	public int? OrderView { get; set; }

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
}
