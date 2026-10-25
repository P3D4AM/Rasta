namespace CRMIdeal.Classes.Common;

public static class FlagsForTelegram
{
	private static bool _flagSendRecieveFromTelegram = true;

	public static bool FlagSendRecieveFromTelegram
	{
		get
		{
			return _flagSendRecieveFromTelegram;
		}
		set
		{
			_flagSendRecieveFromTelegram = value;
		}
	}
}
