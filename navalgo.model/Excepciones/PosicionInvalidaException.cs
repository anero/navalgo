using System;

namespace navalgo.model
{
	public class PosicionInvalidaException : Exception
	{
		public PosicionInvalidaException (string message)
			: base(message)
		{
		}
	}
}

