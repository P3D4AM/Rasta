using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectProductGallery_Result
{
	public int ApiProductGalleryId { get; set; }

	public int ApiPrdId { get; set; }

	public string ApiProductName { get; set; }

	public bool? ApiIsMain { get; set; }

	public string ApiFolderName { get; set; }

	public string ApiFileName { get; set; }

	public string ApiFilePath { get; set; }

	public int? ApiOrderView { get; set; }

	public int ApiFPId { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime ApiFirstRegisterDate { get; set; }
}
