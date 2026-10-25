namespace CRMIdealApi.ApiModels;

public class InsertProductCostGroupViewModel : PublicParameters
{
	public string ApiProductCostGroupName { get; set; }

	public string ApiProductCostGroupDesc { get; set; }

	public int? ApiOrderView { get; set; }
}
