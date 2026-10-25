using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSRegisterBarCodeMetadata))]
public class WSRegisterBarCode
{
	public int ID { get; set; }

	public int? DocId { get; set; }

	public string BarCode { get; set; }

	public int? DocItemId { get; set; }

	public int? PrdId { get; set; }

	public string PrdName { get; set; }

	public string Description { get; set; }

	public int? BarcodeMode { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public int WHId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? Opr { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }
}
