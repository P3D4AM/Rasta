using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmSurveyAnswerCategoryDetailsMetadata))]
public class CrmSurveyAnswerCategoryDetails
{
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

	public virtual CrmSurveyAnswerCategory CrmSurveyAnswerCategory { get; set; }

	public virtual ICollection<CrmSurveyAnswerCategoryDetails_Lang> CrmSurveyAnswerCategoryDetails_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmSurveyAnswerCategoryDetailValues> CrmSurveyAnswerCategoryDetailValues { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmSurveyAnswerCategoryDetails()
	{
		CrmSurveyAnswerCategoryDetails_Lang = (ICollection<CrmSurveyAnswerCategoryDetails_Lang>)new HashSet<CrmSurveyAnswerCategoryDetails_Lang>();
		CrmSurveyAnswerCategoryDetailValues = (ICollection<CrmSurveyAnswerCategoryDetailValues>)new HashSet<CrmSurveyAnswerCategoryDetailValues>();
	}
}
