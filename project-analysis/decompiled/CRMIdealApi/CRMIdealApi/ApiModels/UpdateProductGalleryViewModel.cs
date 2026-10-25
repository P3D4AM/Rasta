namespace CRMIdealApi.ApiModels;

public class UpdateProductGalleryViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int UserId { get; set; }

	public int ApiPrdGalleryId { get; set; }

	public bool? ApiIsMain { get; set; }

	public int? ApiOrderView { get; set; }

	public int? LanguageId { get; set; }
}
