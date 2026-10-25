using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectConversationTopics_Result
{
	public short? ApiTopicOrder { get; set; }

	public string ApiTopic { get; set; }

	public string ApiTopicDesc { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public int? ApiOrderView { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }

	public bool? ApiFODefault { get; set; }

	public int? ApiConversationTopicsID { get; set; }
}
