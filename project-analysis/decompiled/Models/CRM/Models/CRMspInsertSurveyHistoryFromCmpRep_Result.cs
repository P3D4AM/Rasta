namespace CRM.Models;

public class CRMspInsertSurveyHistoryFromCmpRep_Result
{
	public int? CompanyId { get; set; }

	public int? cmpNumber { get; set; }

	public string CompanyName { get; set; }

	public string cmpMainPerson { get; set; }

	public string cmpMainPersonMobile { get; set; }

	public int? TypeError { get; set; }

	public int? SurveyHistoryId { get; set; }

	public int? cmpMainPersonId { get; set; }

	public string cmpMainPersonEmail { get; set; }

	public int? EmailTypeError { get; set; }

	public string LinkSurvey { get; set; }
}
