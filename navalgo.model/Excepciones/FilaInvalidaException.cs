using System;

namespace navalgo.model
{
	public class FilaInvalidaException : Exception
	{
		public FilaInvalidaException (int filaInvalida)
			: base(string.Format ("La fila '{0}' es invalida", filaInvalida))
		{
		}
	}
}

