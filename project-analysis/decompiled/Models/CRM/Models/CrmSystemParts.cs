using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmSystemPartsMetadata))]
public class CrmSystemParts
{
	public int SystemPartId { get; set; }

	public string PartTitle { get; set; }

	public string Part { get; set; }

	public string Type { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public bool? DeActive { get; set; }

	public int? OrderView { get; set; }

	public virtual ICollection<CrmDyForms> CrmDyForms { get; set; }

	public virtual ICollection<CrmDyForms> CrmDyForms1 { get; set; }

	public virtual ICollection<CrmSurvey> CrmSurvey { get; set; }

	public virtual ICollection<CrmSurveyAnswerValue> CrmSurveyAnswerValue { get; set; }

	public virtual ICollection<CrmSurveyHistory> CrmSurveyHistory { get; set; }

	public virtual ICollection<CrmSystemParts_Lang> CrmSystemParts_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmCompanyMoneyBag> CrmCompanyMoneyBag { get; set; }

	public virtual ICollection<UserMoneyBag> UserMoneyBag { get; set; }

	public virtual ICollection<WSDiscountStrategy> WSDiscountStrategy { get; set; }

	public virtual ICollection<CrmCmsWidgetGroups> CrmCmsWidgetGroups { get; set; }

	public virtual ICollection<CrmTempEmails> CrmTempEmails { get; set; }

	public virtual ICollection<EmailUserTempTank> EmailUserTempTank { get; set; }

	public virtual ICollection<CrmCmsHomePageSectionItems> CrmCmsHomePageSectionItems { get; set; }

	public virtual ICollection<PrintFormat> PrintFormat { get; set; }

	public virtual ICollection<Scores> Scores { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmSystemParts()
	{
		CrmDyForms = (ICollection<CrmDyForms>)new HashSet<CrmDyForms>();
		CrmDyForms1 = (ICollection<CrmDyForms>)new HashSet<CrmDyForms>();
		CrmSurvey = (ICollection<CrmSurvey>)new HashSet<CrmSurvey>();
		CrmSurveyAnswerValue = (ICollection<CrmSurveyAnswerValue>)new HashSet<CrmSurveyAnswerValue>();
		CrmSurveyHistory = (ICollection<CrmSurveyHistory>)new HashSet<CrmSurveyHistory>();
		CrmSystemParts_Lang = (ICollection<CrmSystemParts_Lang>)new HashSet<CrmSystemParts_Lang>();
		CrmCompanyMoneyBag = (ICollection<CrmCompanyMoneyBag>)new HashSet<CrmCompanyMoneyBag>();
		UserMoneyBag = (ICollection<UserMoneyBag>)new HashSet<UserMoneyBag>();
		WSDiscountStrategy = (ICollection<WSDiscountStrategy>)new HashSet<WSDiscountStrategy>();
		CrmCmsWidgetGroups = (ICollection<CrmCmsWidgetGroups>)new HashSet<CrmCmsWidgetGroups>();
		CrmTempEmails = (ICollection<CrmTempEmails>)new HashSet<CrmTempEmails>();
		EmailUserTempTank = (ICollection<EmailUserTempTank>)new HashSet<EmailUserTempTank>();
		CrmCmsHomePageSectionItems = (ICollection<CrmCmsHomePageSectionItems>)new HashSet<CrmCmsHomePageSectionItems>();
		PrintFormat = (ICollection<PrintFormat>)new HashSet<PrintFormat>();
		Scores = (ICollection<Scores>)new HashSet<Scores>();
	}
}
