using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSLogoMetadata))]
public class WSLogo
{
	public int LogoID { get; set; }

	public byte[] Logo { get; set; }

	public string LogoDescription { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSLogo_Lang> WSLogo_Lang { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder1 { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual ICollection<WSOrder> WSOrder1 { get; set; }

	public virtual ICollection<WSOrderDefaultSetting> WSOrderDefaultSetting { get; set; }

	public virtual ICollection<WSOrderDefaultSetting> WSOrderDefaultSetting1 { get; set; }

	public virtual ICollection<WSPreOrderDefaultSetting> WSPreOrderDefaultSetting { get; set; }

	public virtual ICollection<WSPreOrderDefaultSetting> WSPreOrderDefaultSetting1 { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSLogo()
	{
		WSLogo_Lang = (ICollection<WSLogo_Lang>)new HashSet<WSLogo_Lang>();
		WSPreOrder = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSPreOrder1 = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
		WSOrder1 = (ICollection<WSOrder>)new HashSet<WSOrder>();
		WSOrderDefaultSetting = (ICollection<WSOrderDefaultSetting>)new HashSet<WSOrderDefaultSetting>();
		WSOrderDefaultSetting1 = (ICollection<WSOrderDefaultSetting>)new HashSet<WSOrderDefaultSetting>();
		WSPreOrderDefaultSetting = (ICollection<WSPreOrderDefaultSetting>)new HashSet<WSPreOrderDefaultSetting>();
		WSPreOrderDefaultSetting1 = (ICollection<WSPreOrderDefaultSetting>)new HashSet<WSPreOrderDefaultSetting>();
	}
}
