using System;

namespace navalgo.model
{
	public class FilaInvalidaException : PosicionInvalidaException
	{
		public FilaInvalidaException (int filaInvalida)
			: base(string.Format ("La fila '{0}' es invalida", filaInvalida))
		{
		}
	}
}

