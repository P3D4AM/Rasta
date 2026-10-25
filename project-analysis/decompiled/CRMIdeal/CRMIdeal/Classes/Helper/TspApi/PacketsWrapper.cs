using System.Collections;
using Newtonsoft.Json;

namespace CRMIdeal.Classes.Helper.TspApi;

public class PacketsWrapper
{
	[JsonProperty]
	private IList packets;

	public PacketsWrapper()
	{
	}

	public PacketsWrapper(IList packets)
	{
		this.packets = packets;
	}

	public IList GetPackets()
	{
		return packets;
	}

	public void SetPackets(IList packets)
	{
		this.packets = packets;
	}
}
