using System;

namespace CRMIdealApi.ApiModels;

public class SelectProductCostViewModel : PublicParameters
{
	public int? ApiProductCostID { get; set; }

	public int? ApiPrdId { get; set; }

	public int? ApiWHId { get; set; }

	public string ApiDocNumber { get; set; }

	public DateTime? ApiFromDocDateTime { get; set; }

	public DateTime? ApiToDocDateTime { get; set; }

	public DateTime? ApiFromRegisterDate { get; set; }

	public DateTime? ApiToRegisterDate { get; set; }

	public DateTime? ApiFromFirstRegisterDate { get; set; }

	public DateTime? ApiToFirstRegisterDate { get; set; }
}
