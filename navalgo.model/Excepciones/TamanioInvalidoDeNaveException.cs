using System;

namespace navalgo.model
{
	public class TamanioInvalidoDeNaveException : Exception
	{
		public TamanioInvalidoDeNaveException (int tamanioInvalido)
			: base(string.Format ("El tamano provisto '{0}' es invalido", tamanioInvalido))
		{
		}
	}
}

