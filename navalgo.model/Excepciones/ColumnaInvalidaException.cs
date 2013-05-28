using System;

namespace navalgo.model
{
	public class ColumnaInvalidaException : PosicionInvalidaException
	{
		public ColumnaInvalidaException (char columnaInvalida)
			: base(string.Format ("La columna '{0}' es invalida", columnaInvalida))
		{
		}
	}
}

