using System;

namespace JsonServices.Transport
{
	public class MessageEventArgs
	{
		public string SessionId { get; set; }

		public string Data { get; set; }
	}
}