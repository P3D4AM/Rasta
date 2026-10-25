namespace CRMIdealApi.ApiModels;

public class InsertLinkedProductViewModel : PublicParameters
{
	public int? ApiPrdId { get; set; }

	public int? ApiLinkedPrdId { get; set; }

	public string ApiLinkedPrdCode { get; set; }

	public int? ApiOrderView { get; set; }

	public double? ApiLinkedPrdQuantity { get; set; }

	public bool? ApiLinkedPrdNotVisible { get; set; }

	public bool? ApiLinkedPrdNotInSum { get; set; }

	public bool? ApiLinkedPrdAddQuantity { get; set; }

	public bool? ApiLinkedPrdAddPrice { get; set; }

	public bool? ApiLinkedPrdAddDiscount { get; set; }

	public bool? ApiLinkedPrdIsSelect { get; set; }
}
