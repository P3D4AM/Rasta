namespace CRMIdealApi.ApiModels;

public class UpdateProductCostGroupViewModel : PublicParameters
{
	public int? ApiProductCostGroupID { get; set; }

	public string ApiProductCostGroupName { get; set; }

	public string ApiProductCostGroupDesc { get; set; }

	public int? ApiOrderView { get; set; }
}
