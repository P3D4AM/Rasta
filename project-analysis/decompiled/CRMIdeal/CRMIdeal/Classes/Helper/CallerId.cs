using System;
using System.Collections.Generic;
using System.Linq;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using Elmah;

namespace CRMIdeal.Classes.Helper;

public class CallerId
{
	public class CallLogData
	{
		public string UId { get; set; }

		public string LinkedId { get; set; }

		public int CallHistoryId { get; set; }
	}

	public class AsteriskCall
	{
		public class EventType
		{
			public const string NewChannel = "NewChannel";

			public const string NewCallerId = "NewCallerId";

			public const string NewExten = "NewExten";

			public const string CDR = "CDR";

			public const string Popup = "Popup";
		}

		public class CallType
		{
			public const string In_In = "In_In";

			public const string In_Out = "In_Out";

			public const string Out_In = "Out_In";
		}

		public class CrmCallTypeId
		{
			public const int In_Out = 1;

			public const int Out_In = 2;

			public const int In_In = 3;

			public const int Mob_In = 10;

			public const int Mob_Out = 11;

			public const int Mob_Lost = 12;

			public const int Mob_Reject = 13;
		}

		public class Disposition
		{
			public const string Answered = "ANSWERED";

			public const string No_Answer = "NO ANSWER";
		}

		public class Data
		{
			public string EventType { get; set; }

			public string UId { get; set; }

			public string LinkedId { get; set; }

			public string Source { get; set; }

			public string Destination { get; set; }

			public string Channel { get; set; }

			public string ChannelState { get; set; }

			public string Disposition { get; set; }

			public string Context { get; set; }

			public string SipLine { get; set; }

			public string CallType { get; set; }

			public string PreFileName { get; set; }

			public string FileName { get; set; }

			public string RemoteLocation { get; set; }

			public string FileLocation { get; set; }

			public string DownloadErrors { get; set; }

			public DateTime? StartTime { get; set; }

			public DateTime? EndTime { get; set; }

			public string DateReceived { get; set; }

			public long? Duration { get; set; }

			public string EventData { get; set; }

			public int InsertMode { get; set; }

			public int? CrmCallHistoryId { get; set; }

			public int? CrmCallTypeId { get; set; }

			public string CalcTelNumClean { get; set; }

			public int? CalcLineNumber { get; set; }

			public string CalcExtension { get; set; }

			public bool? CalcIsFinished { get; set; }

			public int? CalcDevType { get; set; }

			public string TelNumNoClean { get; set; }

			public string SourceNoClean { get; set; }

			public string DestinationNoClean { get; set; }

			public int? InternalDigit_ExtenLen { get; set; }
		}
	}

	public static List<CallLogData> CallLogs = new List<CallLogData>();

	public static int GetCallHistoryId(string uId = "", string linkedId = "")
	{
		int result = 0;
		try
		{
			if (string.IsNullOrWhiteSpace(uId) || string.IsNullOrWhiteSpace(linkedId))
			{
				return result;
			}
			uId = uId.Split(new char[1] { '.' })[0];
			linkedId = (linkedId ?? "").Split(new char[1] { '.' })[0];
			CallLogData callLogData = null;
			if (callLogData == null && !string.IsNullOrWhiteSpace(uId))
			{
				callLogData = Enumerable.FirstOrDefault<CallLogData>((IEnumerable<CallLogData>)CallLogs, (Func<CallLogData, bool>)((CallLogData x) => x.UId.Contains(uId)));
			}
			if (callLogData == null && !string.IsNullOrWhiteSpace(linkedId))
			{
				callLogData = Enumerable.FirstOrDefault<CallLogData>((IEnumerable<CallLogData>)CallLogs, (Func<CallLogData, bool>)((CallLogData x) => x.LinkedId.Contains(linkedId)));
			}
			if (callLogData != null)
			{
				result = callLogData.CallHistoryId;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = 0;
		}
		return result;
	}

	public static bool SetCallHistoryId(int callHistoryId, string uId = "", string linkedId = "")
	{
		bool result = false;
		try
		{
			if (string.IsNullOrWhiteSpace(uId) || string.IsNullOrWhiteSpace(linkedId))
			{
				return result;
			}
			uId = uId.Split(new char[1] { '.' })[0];
			linkedId = (linkedId ?? "").Split(new char[1] { '.' })[0];
			if (GetCallHistoryId(uId, linkedId) != 0 && callHistoryId != 0)
			{
				for (int i = 0; i < CallLogs.Count; i++)
				{
					if ((!string.IsNullOrWhiteSpace(uId) && CallLogs[i].UId.Contains(uId)) || (!string.IsNullOrWhiteSpace(linkedId) && CallLogs[i].LinkedId.Contains(linkedId)))
					{
						CallLogs[i].CallHistoryId = callHistoryId;
					}
				}
			}
			else
			{
				CallLogs.Add(new CallLogData
				{
					UId = uId,
					LinkedId = linkedId,
					CallHistoryId = callHistoryId
				});
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public static bool RemoveAllCalls(string uId = "", string linkedId = "")
	{
		bool result = false;
		try
		{
			if (string.IsNullOrWhiteSpace(uId) || string.IsNullOrWhiteSpace(linkedId))
			{
				return result;
			}
			uId = uId.Split(new char[1] { '.' })[0];
			linkedId = (linkedId ?? "").Split(new char[1] { '.' })[0];
			for (int num = CallLogs.Count - 1; num >= 0; num--)
			{
				if ((!string.IsNullOrWhiteSpace(uId) && CallLogs[num].UId.Contains(uId)) || (!string.IsNullOrWhiteSpace(linkedId) && CallLogs[num].LinkedId.Contains(linkedId)))
				{
					CallLogs.RemoveAt(num);
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public static string CleanNumber(string num = "", int callTypeId = 0, string source = "", string destination = "", int internalDigit_ExtenLen = 0)
	{
		if (string.IsNullOrWhiteSpace(num))
		{
			return null;
		}
		string text = "";
		try
		{
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			string text2 = "";
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				text2 = cRMspSelectCrmsysSetting_Result.ProvincePreCode ?? "";
			}
			num = CleanNumberByUserCallPreNumber(num, callTypeId, source, destination);
			if (string.IsNullOrWhiteSpace(num))
			{
				return null;
			}
			if (num.StartsWith("+"))
			{
				num = "00" + num.Substring(1);
			}
			text = string.Join("", Enumerable.Where<char>((IEnumerable<char>)num.ToCharArray(), (Func<char, bool>)char.IsDigit));
			while (text.StartsWith("0") && text.Length > internalDigit_ExtenLen)
			{
				text = text.Substring(1);
			}
			if (num.StartsWith("0") && text.Length > internalDigit_ExtenLen)
			{
				if (text.Length <= 10)
				{
					text = "0" + text;
				}
				else if (text.Length > 10)
				{
					text = "00" + text;
				}
			}
			if (text.StartsWith("0098") && text.Length > internalDigit_ExtenLen)
			{
				text = text.Substring(4);
				if (text.Length > 8)
				{
					text = "0" + text;
				}
			}
			if (text.StartsWith("098") && text.Length > internalDigit_ExtenLen)
			{
				text = text.Substring(3);
				if (text.Length > 8)
				{
					text = "0" + text;
				}
			}
			if (text.StartsWith("98") && text.Length > internalDigit_ExtenLen)
			{
				text = text.Substring(2);
				if (text.Length > 8)
				{
					text = "0" + text;
				}
			}
			if (!string.IsNullOrWhiteSpace(text2))
			{
				string[] array = text2.Split(new char[1] { ',' });
				for (int i = 0; i < Enumerable.Count<string>((IEnumerable<string>)array); i++)
				{
					if (text.StartsWith(array[i]) && text.Length > internalDigit_ExtenLen)
					{
						text = text.Substring(array[i].Length);
						break;
					}
				}
			}
			if (text.StartsWith("2222222222") || text.StartsWith("22222222"))
			{
				text = "";
			}
			if (text.Length == 10)
			{
				text = "0" + text;
			}
			else if (text.Length > 8 && !text.StartsWith("00") && !text.StartsWith("0"))
			{
				text = text.Substring(text.Length - 8, 8);
			}
			if (text.StartsWith("0"))
			{
				if (text.Length > 15)
				{
					text = text.Substring(0, 15);
				}
			}
			else if (!text.StartsWith("0") && text.Length > 8)
			{
				text = text.Substring(0, 8);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = "";
		}
		return text;
	}

	private static string CleanNumberByUserCallPreNumber(string num = "", int callTypeId = 0, string source = "", string destination = "")
	{
		CRMSpIIIEntities cRMSpIIIEntities = new CRMSpIIIEntities();
		try
		{
			if (!string.IsNullOrWhiteSpace(num))
			{
				CRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result cRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result = Enumerable.FirstOrDefault<CRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result>((IEnumerable<CRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result>)cRMSpIIIEntities.CRMspCallerIDCleanPhoneNumberByUserCallPreNumber(callTypeId, num, source, destination));
				if (cRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result != null)
				{
					string text = cRMspCallerIDCleanPhoneNumberByUserCallPreNumber_Result.PhoneNumber ?? "";
					if (!string.IsNullOrWhiteSpace(text) && text != num)
					{
						num = text;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIIIEntities?.Dispose();
		}
		return num;
	}
}
