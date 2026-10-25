namespace Mobile.Models;

public class MobspSelectSurvey_Result
{
	public int SurveyId { get; set; }

	public int surSystemPartId { get; set; }

	public string surSystemPart { get; set; }

	public string surSystemPartTitle { get; set; }

	public string surTitle { get; set; }

	public string surDesc { get; set; }

	public bool? surInactive { get; set; }

	public int? OrderView { get; set; }
}
