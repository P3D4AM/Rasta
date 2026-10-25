using System.Collections.Generic;

namespace CRMIdealApi.ApiModels;

public class InsertUpdateCenterProductsMultiViewModel : PublicParametersWithOutCenter
{
	public List<InsertUpdateCenterProductsViewModel> CenterProductsList { get; set; }
}
