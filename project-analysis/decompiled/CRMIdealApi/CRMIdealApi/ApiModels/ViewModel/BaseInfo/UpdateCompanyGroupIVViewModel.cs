namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateCompanyGroupIVViewModel : PublicParametersWithOutCenter
{
	public int ApiCompanyGroupIVId { get; set; }

	public string ApiGroupIVName { get; set; }

	public string ApiGroupIVDesc { get; set; }

	public int? ApiOrderView { get; set; }

	public float? ApiScoreRate { get; set; }
}
