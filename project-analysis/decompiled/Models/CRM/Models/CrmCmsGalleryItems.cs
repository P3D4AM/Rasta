using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCmsGalleryItemsMetadata))]
public class CrmCmsGalleryItems
{
	public int GalleryItemId { get; set; }

	public int GalleryId { get; set; }

	public string ItemTitle { get; set; }

	public string ItemTitleFontColor { get; set; }

	public string ItemDesc { get; set; }

	public string ItemDescFontColor { get; set; }

	public string ItemLink { get; set; }

	public string ItemLinkTitle { get; set; }

	public string ItemLinkBgColor { get; set; }

	public string ItemLinkFontColor { get; set; }

	public int? TargetMode { get; set; }

	public bool? IsActive { get; set; }

	public bool? IsShowTitle { get; set; }

	public bool? IsShowDesc { get; set; }

	public string FileName { get; set; }

	public string FolderName { get; set; }

	public string FilePath { get; set; }

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

	public virtual CrmCmsGallery CrmCmsGallery { get; set; }

	public virtual ICollection<CrmCmsGalleryItems_Lang> CrmCmsGalleryItems_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmCmsGalleryItems()
	{
		CrmCmsGalleryItems_Lang = (ICollection<CrmCmsGalleryItems_Lang>)new HashSet<CrmCmsGalleryItems_Lang>();
	}
}
