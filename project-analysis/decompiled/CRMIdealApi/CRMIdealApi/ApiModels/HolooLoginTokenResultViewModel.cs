namespace CRMIdealApi.ApiModels;

public class HolooLoginTokenResultViewModel
{
	public bool State { get; set; }

	public string Token { get; set; }

	public string Error { get; set; }

	public long ErrorCode { get; set; }
}
