using System;

namespace CRM.Models;

public class CRMspRpt_CalenderEvent_Result
{
	public int? CompanyId { get; set; }

	public int? CompanyPersonId { get; set; }

	public string cmpTitle { get; set; }

	public string cmpName { get; set; }

	public string cmpNumber { get; set; }

	public string prsTitle { get; set; }

	public string prsFName { get; set; }

	public string prsLName { get; set; }

	public string prsMobile { get; set; }

	public string prsJob { get; set; }

	public string prsPhone { get; set; }

	public string BirthDate { get; set; }

	public string MarriageDate { get; set; }

	public DateTime? BirthDateTime { get; set; }

	public DateTime? MarriageDateTime { get; set; }

	public string UserName { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public string FDate { get; set; }

	public string TDate { get; set; }
}
