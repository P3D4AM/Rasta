namespace CRM.Models;

public class CRMspRpt_CallCountInConversationTopics_Result
{
	public string ConversationTopic { get; set; }

	public int? cnvsTopicId { get; set; }

	public string cnvsReferUser { get; set; }

	public int? cnvsReferUserId { get; set; }

	public int? CallCnt { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public string FDate { get; set; }

	public string TDate { get; set; }

	public string UserName { get; set; }
}
