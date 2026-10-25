using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductPictureMetadata))]
public class WSProductPicture
{
	public int PrdPictureID { get; set; }

	public int PrdId { get; set; }

	public byte[] PrdFirstPic { get; set; }

	public string PrdFirstPicDesc { get; set; }

	public byte[] PrdSecondPic { get; set; }

	public string PrdSecondPicDesc { get; set; }

	public byte[] PrdThirdPic { get; set; }

	public string PrdThirdPicDesc { get; set; }

	public byte[] PrdFourthPic { get; set; }

	public string PrdFourthPicDesc { get; set; }

	public byte[] PrdFifthPic { get; set; }

	public string PrdFifthPicDesc { get; set; }

	public string Description { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? WHId { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public DateTime? CompressDate { get; set; }

	public string CompressDatePersian { get; set; }

	public int? CompressUserId { get; set; }

	public string CompressInfo { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSProductPicture_Lang> WSProductPicture_Lang { get; set; }

	public virtual WsWareHouse WsWareHouse { get; set; }

	public virtual WSProducts WSProducts { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSProductPicture()
	{
		WSProductPicture_Lang = (ICollection<WSProductPicture_Lang>)new HashSet<WSProductPicture_Lang>();
	}
}
