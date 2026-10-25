using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(EmailUserDefaultSettingMetadata))]
public class EmailUserDefaultSetting
{
	public int EmailUserDefaultSettingId { get; set; }

	public string eudTitle { get; set; }

	public string eudBody { get; set; }

	public int FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime RegisterDate { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<SecLetterDefaultSettings> SecLetterDefaultSettings { get; set; }

	public virtual ICollection<SecLetters> SecLetters { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual ICollection<WSOrderDefaultSetting> WSOrderDefaultSetting { get; set; }

	public virtual ICollection<WSPreOrderDefaultSetting> WSPreOrderDefaultSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public EmailUserDefaultSetting()
	{
		SecLetterDefaultSettings = (ICollection<SecLetterDefaultSettings>)new HashSet<SecLetterDefaultSettings>();
		SecLetters = (ICollection<SecLetters>)new HashSet<SecLetters>();
		WSPreOrder = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
		WSOrderDefaultSetting = (ICollection<WSOrderDefaultSetting>)new HashSet<WSOrderDefaultSetting>();
		WSPreOrderDefaultSetting = (ICollection<WSPreOrderDefaultSetting>)new HashSet<WSPreOrderDefaultSetting>();
	}
}
