namespace Mobile.Models;

public class MobspSelectConversationTopics_Result
{
	public int Id { get; set; }

	public string Title { get; set; }

	public bool? CheckUserDistanceCmp { get; set; }

	public double? UserDistanceCmpVal { get; set; }

	public long? OrderView { get; set; }
}
