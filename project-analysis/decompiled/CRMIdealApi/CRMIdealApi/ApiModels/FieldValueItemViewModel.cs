namespace CRMIdealApi.ApiModels;

public class FieldValueItemViewModel
{
	public int FormId { get; set; }

	public int? CompanyId { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? ProjectId { get; set; }

	public int? ConversationId { get; set; }

	public int? MasterObjectId { get; set; }

	public int? DetailObjectId { get; set; }

	public int? SubDetailObjectId { get; set; }

	public int? MasterValueId { get; set; }

	public string FieldTitle { get; set; }

	public string FieldType { get; set; }

	public string Value { get; set; }

	public long FieldRepeatId { get; set; }
}
