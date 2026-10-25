using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSProductPictureViewModel
{
	public int PrdPictureID { get; set; }

	public int PrdId { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "frmErrorEmpty")]
	public string PrdFirstPicPath { get; set; }

	public string PrdFirstPicDesc { get; set; }

	public int FPId { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string AppType { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }
}
