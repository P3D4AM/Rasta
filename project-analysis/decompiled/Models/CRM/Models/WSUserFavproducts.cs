using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSUserFavproductsMetadata))]
public class WSUserFavproducts
{
	public int UserFavproductId { get; set; }

	public string FavprdTitle { get; set; }

	public string FavprdDesc { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? OrderView { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public bool? FavprdInActive { get; set; }

	public bool? FavprdUseInIssueQuick { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSUserFavproductItems> WSUserFavproductItems { get; set; }

	public virtual ICollection<WSUserFavproducts_Lang> WSUserFavproducts_Lang { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSUserFavproducts()
	{
		WSUserFavproductItems = (ICollection<WSUserFavproductItems>)new HashSet<WSUserFavproductItems>();
		WSUserFavproducts_Lang = (ICollection<WSUserFavproducts_Lang>)new HashSet<WSUserFavproducts_Lang>();
	}
}
