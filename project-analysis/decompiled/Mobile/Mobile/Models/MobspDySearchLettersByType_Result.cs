using System;

namespace Mobile.Models;

public class MobspDySearchLettersByType_Result
{
	public int LetterId { get; set; }

	public string LetterDate { get; set; }

	public DateTime LetterDateTime { get; set; }

	public int LetterTypeId { get; set; }

	public string LetterType { get; set; }

	public long LetterNumber { get; set; }

	public long? LetterNumberII { get; set; }

	public string LetterInfo { get; set; }

	public string TxtHelp { get; set; }
}
