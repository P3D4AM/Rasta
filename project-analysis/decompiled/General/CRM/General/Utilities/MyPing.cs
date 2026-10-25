using System;
using System.ComponentModel;
using System.Net.NetworkInformation;

namespace CRM.General.Utilities;

public class MyPing
{
	public string PingIpAddress(string strIp)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Invalid comparison between Unknown and I4
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Invalid comparison between Unknown and I4
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Invalid comparison between Unknown and I4
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Invalid comparison between Unknown and I4
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Invalid comparison between Unknown and I4
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Invalid comparison between Unknown and I4
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Invalid comparison between Unknown and I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Invalid comparison between Unknown and I4
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		string empty = string.Empty;
		string result = string.Empty;
		Ping val = new Ping();
		try
		{
			PingReply val2 = val.Send(strIp);
			IPStatus status = val2.Status;
			if ((int)status <= 11003)
			{
				if ((int)status != -1)
				{
					if ((int)status != 0)
					{
						if ((int)status != 11003)
						{
							goto IL_0134;
						}
						result = "Destination Host Unreachable";
					}
					else
					{
						strIp = ((object)val2.Address).ToString();
						empty = ((val2.RoundtripTime != 0L) ? $"={val2.RoundtripTime.ToString()}" : "<1");
						result = $"Reply from {strIp}: bytes={val2.Buffer.Length.ToString()} time{empty}ms TTL={val2.Options.Ttl}";
					}
				}
				else
				{
					result = "error: Unknown";
				}
			}
			else if ((int)status <= 11010)
			{
				if ((int)status != 11008)
				{
					if ((int)status != 11010)
					{
						goto IL_0134;
					}
					result = "Request Timed Out";
				}
				else
				{
					result = "Hard ware Error";
				}
			}
			else if ((int)status != 11018)
			{
				if ((int)status != 11040)
				{
					goto IL_0134;
				}
				result = "Destination Unreachable";
			}
			else
			{
				result = "Bad Destination";
			}
			goto end_IL_0012;
			IL_0134:
			IPStatus status2 = val2.Status;
			result = $" Request {((object)(IPStatus)(ref status2)).ToString()}";
			end_IL_0012:;
		}
		catch (Exception ex)
		{
			result = $" error: {ex.Message}";
		}
		finally
		{
			((Component)val).Dispose();
		}
		return result;
	}
}
