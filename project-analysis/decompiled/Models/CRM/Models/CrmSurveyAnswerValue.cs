using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmSurveyAnswerValueMetadata))]
public class CrmSurveyAnswerValue
{
	public int SurveyAnswerValueId { get; set; }

	public int suravSystemPartId { get; set; }

	public int suravSystemPartObjectId { get; set; }

	public int? suravReplyCompanyId { get; set; }

	public int? suravReplyUserId { get; set; }

	public int suravHistoryId { get; set; }

	public int suravSurveyId { get; set; }

	public int suravQuestionId { get; set; }

	public int? suravAnswerId { get; set; }

	public string suravTextValue { get; set; }

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

	public int? suravCId { get; set; }

	public virtual CrmSurvey CrmSurvey { get; set; }

	public virtual CrmSurveyAnswers CrmSurveyAnswers { get; set; }

	public virtual CrmSurveyHistory CrmSurveyHistory { get; set; }

	public virtual CrmSurveyQuestions CrmSurveyQuestions { get; set; }

	public virtual CrmSystemParts CrmSystemParts { get; set; }

	public virtual ICollection<CrmSurveyAnswerValue_Lang> CrmSurveyAnswerValue_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmSurveyAnswerValue()
	{
		CrmSurveyAnswerValue_Lang = (ICollection<CrmSurveyAnswerValue_Lang>)new HashSet<CrmSurveyAnswerValue_Lang>();
	}
}
