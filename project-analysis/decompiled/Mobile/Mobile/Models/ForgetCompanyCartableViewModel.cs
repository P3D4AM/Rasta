using System;

namespace Mobile.Models;

public class ForgetCompanyCartableViewModel
{
	public string FDate { get; set; }

	public string TDate { get; set; }

	public DateTime FDateTime { get; set; }

	public DateTime TDateTime { get; set; }

	public string CnvsStatusId { get; set; }

	public string PrjTitle { get; set; }

	public string CnvsUserId { get; set; }

	public string CnvsReferUserId { get; set; }

	public bool NoRemindDate { get; set; }

	public string PrjPostFix { get; set; }

	public int? PageSize { get; set; }

	public int? PageNumber { get; set; }

	public int? LanguageId { get; set; }

	public int? CenterId { get; set; }
}
