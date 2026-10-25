namespace Mobile.Models;

public class InsertAnswerValueViewModel
{
	public int systemPartId { get; set; }

	public int systemPartObjectId { get; set; }

	public int? replyCompanyId { get; set; }

	public int? replyUserId { get; set; }

	public int historyId { get; set; }

	public int surveyId { get; set; }

	public int questionId { get; set; }

	public int? answerId { get; set; }

	public string textValue { get; set; }

	public int? languageId { get; set; }
}
