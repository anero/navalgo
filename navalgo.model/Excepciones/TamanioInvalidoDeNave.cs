using System;

namespace navalgo.model
{
	public class TamanioInvalidoDeNave : Exception
	{
		public TamanioInvalidoDeNave (int tamanioInvalido)
			: base(string.Format ("El tamano provisto '{0}' es invalido", tamanioInvalido))
		{
		}
	}
}

