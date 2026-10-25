using System;

namespace CRM.Models;

public class CRMspCmsSelectActiveGallery_Result
{
	public int GalleryId { get; set; }

	public string GalleryTitle { get; set; }

	public int? GalleryInterval { get; set; }

	public int? GalleryEffect { get; set; }

	public string GalleryEffectTitle { get; set; }

	public bool? IsActive { get; set; }

	public bool? IsShowTitle { get; set; }

	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string EditUser { get; set; }

	public string FirstRegisterUser { get; set; }
}
