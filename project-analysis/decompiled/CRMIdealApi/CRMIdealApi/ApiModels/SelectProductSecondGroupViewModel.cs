namespace CRMIdealApi.ApiModels;

public class SelectProductSecondGroupViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int? ApiSecondGroupId { get; set; }

	public string ApiSecondGroupCode { get; set; }

	public int? ApiFirstGroupId { get; set; }

	public string ApiFirstGroupCode { get; set; }

	public int? LanguageId { get; set; }
}
