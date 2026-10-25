namespace Mobile.Models;

public class WSspRpt_PrintPaymentByIdAndType_Result
{
	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public string RptUser { get; set; }

	public int PaymentId { get; set; }

	public int payTypeId { get; set; }

	public string payType { get; set; }

	public int payObjectId { get; set; }

	public string payObjectInfo { get; set; }

	public decimal payAmount { get; set; }

	public string payDocNumber { get; set; }

	public string payDocDatePerWithSlash { get; set; }

	public decimal? payDocAmount { get; set; }

	public string payDescription { get; set; }

	public string ImportDatePerWithSlash { get; set; }

	public string FirstRegisterUser { get; set; }

	public string FirstRegisteDatePerWithSlash { get; set; }

	public string RegisterUser { get; set; }

	public string RegisteDatePerWithSlash { get; set; }

	public string AppType { get; set; }
}
