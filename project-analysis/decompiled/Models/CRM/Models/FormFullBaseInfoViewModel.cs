using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class FormFullBaseInfoViewModel
{
	public class ItemDroupDownGroup
	{
		public string text { get; set; }

		public string value { get; set; }
	}

	[Key]
	public int ItemId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FullbaseInfoCountryCode")]
	public string ItemCountryCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FullbaseInfoItemTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string ItemTitle { get; set; }

	public string ItemTitle_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FullbaseInfoItemDesc")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ItemDesc { get; set; }

	public string ItemDesc_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FullbaseInfoItemOrder")]
	public string ItemOrder { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FullbaseInfoItemDefault")]
	public bool? ItemDefault { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FullbaseInfoItemRate")]
	public double? ItemRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FullbaseInfoItemDeActive")]
	public bool? ItemDeActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FullbaseInfoItemScoreRate")]
	public double? ItemScoreRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FullbaseInfoItemCode")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ItemCode { get; set; }

	public string ItemCodeVisibale { get; set; }

	public string NamefieldCode { get; set; }

	public string ItemCountryCodeVisibale { get; set; }

	public string ItemTitleVisibale { get; set; }

	public string ItemDescVisibale { get; set; }

	public string ItemOrderVisibale { get; set; }

	public string ItemDefaultVisibale { get; set; }

	public string ItemRateVisibale { get; set; }

	public string ItemDeActiveVisibale { get; set; }

	public string ItemScoreRateVisibale { get; set; }

	public string TitlePage { get; set; }

	public string TypeAccess { get; set; }

	public string TypeAction { get; set; }

	public string NameTabel { get; set; }

	public string NameTabel_Lang { get; set; }

	public string NameTabel_Delete { get; set; }

	public string NamefieldID { get; set; }

	public string NamefieldID_Lang { get; set; }

	public string NamefieldI { get; set; }

	public string NamefieldI_Lang { get; set; }

	public string NamefieldII { get; set; }

	public string NamefieldII_Lang { get; set; }

	public string NamefieldIII { get; set; }

	public string NamefieldIII_Lang { get; set; }

	public string NamefieldIV { get; set; }

	public string NamefieldIV_Lang { get; set; }

	public string NamefieldVI { get; set; }

	public string NamefieldVI_Lang { get; set; }

	public string NamefieldVII { get; set; }

	public string NamefieldVII_Lang { get; set; }

	public string NamefieldVIII { get; set; }

	public string NamefieldVIII_Lang { get; set; }

	public string NamefieldIX { get; set; }

	public string NamefieldIX_Lang { get; set; }

	public string NamefieldX { get; set; }

	public string NamefieldX_Lang { get; set; }

	public string NamefieldScoreRate { get; set; }

	public string NamefieldScoreRate_Lang { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public bool isLanguage { get; set; }

	public string Parametes { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public string AppType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FullbaseInfoFODefault")]
	public bool? FODefault { get; set; }

	public string FODefaultVisible { get; set; }

	public string NamefieldFODefault { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FullbaseInfoCheckUserDistanceCmp")]
	public bool? CheckUserDistanceCmp { get; set; }

	public string CheckUserDistanceCmpVisible { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FullbaseInfoUserDistanceCmpVal")]
	public double? UserDistanceCmpVal { get; set; }

	public string UserDistanceCmpValVisible { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FullbaseInfoSHPVisible")]
	public bool? SHPVisible { get; set; }

	public string SHPVisible_Visible { get; set; }

	public string NamefieldSHPVisible { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FullbaseInfoSHPDefault")]
	public bool? SHPDefault { get; set; }

	public string SHPDefaultVisible { get; set; }

	public string NamefieldSHPDefault { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FullbaseInfoSHPNeedAddress")]
	public bool? SHPNeedAddress { get; set; }

	public string SHPNeedAddressVisible { get; set; }

	public string NamefieldSHPNeedAddress { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FullbaseInfoUserAccessAll")]
	public bool? ItemUserAccessAll { get; set; }
}
