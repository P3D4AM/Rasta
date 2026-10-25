using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(PrintFormatMetadata))]
public class PrintFormat
{
	public int PrintFormatID { get; set; }

	public int PrintFormatTypeId { get; set; }

	public string Title { get; set; }

	public string FileName { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string FileNameWeb { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? CId { get; set; }

	public int? SysPartId { get; set; }

	public int? SysPartObjectId { get; set; }

	public bool? IsDefault { get; set; }

	public virtual ICollection<CrmDyForms> CrmDyForms { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<PayRollUserCycle> PayRollUserCycle { get; set; }

	public virtual ICollection<PrintFormat_Lang> PrintFormat_Lang { get; set; }

	public virtual PrintFormatType PrintFormatType { get; set; }

	public virtual ICollection<SecLetterDefaultSettings> SecLetterDefaultSettings { get; set; }

	public virtual ICollection<SecLetters> SecLetters { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder { get; set; }

	public virtual ICollection<WSBuyOrderDefaultSetting> WSBuyOrderDefaultSetting { get; set; }

	public virtual ICollection<WSStockSupply> WSStockSupply { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting1 { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual CrmSystemParts CrmSystemParts { get; set; }

	public virtual ICollection<WSOrderDefaultSetting> WSOrderDefaultSetting { get; set; }

	public virtual ICollection<WSPreOrderDefaultSetting> WSPreOrderDefaultSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public PrintFormat()
	{
		CrmDyForms = (ICollection<CrmDyForms>)new HashSet<CrmDyForms>();
		PayRollUserCycle = (ICollection<PayRollUserCycle>)new HashSet<PayRollUserCycle>();
		PrintFormat_Lang = (ICollection<PrintFormat_Lang>)new HashSet<PrintFormat_Lang>();
		SecLetterDefaultSettings = (ICollection<SecLetterDefaultSettings>)new HashSet<SecLetterDefaultSettings>();
		SecLetters = (ICollection<SecLetters>)new HashSet<SecLetters>();
		WSBuyOrder = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSPreOrder = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSBuyOrderDefaultSetting = (ICollection<WSBuyOrderDefaultSetting>)new HashSet<WSBuyOrderDefaultSetting>();
		WSStockSupply = (ICollection<WSStockSupply>)new HashSet<WSStockSupply>();
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
		CrmMobSetting = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmFoSetting = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting1 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		WSOrderDefaultSetting = (ICollection<WSOrderDefaultSetting>)new HashSet<WSOrderDefaultSetting>();
		WSPreOrderDefaultSetting = (ICollection<WSPreOrderDefaultSetting>)new HashSet<WSPreOrderDefaultSetting>();
	}
}
