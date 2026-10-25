namespace CRMIdealApi.ApiModels;

public class ApispInsertConversation_Result
{
	public int? ErrorNumber { get; set; }

	public int? ErrorSeverity { get; set; }

	public int? ErrorState { get; set; }

	public string ErrorProcedure { get; set; }

	public int? ErrorLine { get; set; }

	public string ErrorMessage { get; set; }
}
