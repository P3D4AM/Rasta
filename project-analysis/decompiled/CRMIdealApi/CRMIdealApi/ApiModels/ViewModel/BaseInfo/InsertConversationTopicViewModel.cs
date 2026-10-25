namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class InsertConversationTopicViewModel : PublicParametersWithOutCenter
{
	public string ApiTopic { get; set; }

	public string ApiTopicDesc { get; set; }

	public short? ApiTopicOrder { get; set; }

	public int? ApiOrderView { get; set; }

	public bool? ApiFoDefault { get; set; }

	public bool? ApiCheckUserDistanceCmp { get; set; }

	public float? ApiUserDistanceCmpVal { get; set; }
}
