using System;

namespace navalgo.model
{
	public class CoordenadasInvalidasParaAreaDePosicionesValidasException : Exception
	{
		public CoordenadasInvalidasParaAreaDePosicionesValidasException (string mensaje)
			:base (mensaje)
		{
		}
	}
}

