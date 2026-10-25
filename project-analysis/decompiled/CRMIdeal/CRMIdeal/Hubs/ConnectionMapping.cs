using System.Collections.Generic;
using System.Linq;

namespace CRMIdeal.Hubs;

public class ConnectionMapping<T>
{
	private readonly Dictionary<T, HashSet<string>> _connections = new Dictionary<T, HashSet<string>>();

	public int Count => _connections.Count;

	public void Add(T key, string connectionId)
	{
		lock (_connections)
		{
			if (!_connections.TryGetValue(key, out var value))
			{
				value = new HashSet<string>();
				_connections.Add(key, value);
			}
			lock (value)
			{
				value.Add(connectionId);
			}
		}
	}

	public IEnumerable<string> GetConnections(T key)
	{
		if (_connections.TryGetValue(key, out var value))
		{
			return (IEnumerable<string>)value;
		}
		return Enumerable.Empty<string>();
	}

	public void Remove(T key, string connectionId)
	{
		lock (_connections)
		{
			if (!_connections.TryGetValue(key, out var value))
			{
				return;
			}
			lock (value)
			{
				value.Remove(connectionId);
				if (value.Count == 0)
				{
					_connections.Remove(key);
				}
			}
		}
	}
}
