using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCmsGalleryMetadata))]
public class CrmCmsGallery
{
	public int GalleryId { get; set; }

	public string GalleryTitle { get; set; }

	public int? GalleryInterval { get; set; }

	public int? GalleryEffect { get; set; }

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

	public string GallerySystemPartIds { get; set; }

	public virtual ICollection<CrmCmsGallery_Lang> CrmCmsGallery_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmCmsGalleryItems> CrmCmsGalleryItems { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting1 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting2 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting3 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting4 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting5 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting6 { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmCmsGallery()
	{
		CrmCmsGallery_Lang = (ICollection<CrmCmsGallery_Lang>)new HashSet<CrmCmsGallery_Lang>();
		CrmCmsGalleryItems = (ICollection<CrmCmsGalleryItems>)new HashSet<CrmCmsGalleryItems>();
		CrmFoSetting = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting1 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting2 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting3 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting4 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting5 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting6 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
	}
}
