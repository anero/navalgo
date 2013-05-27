using System;

namespace navalgo.model
{
	public class Lancha : Nave
	{
		private const int TamanioInicial = 2;

		public Lancha (Posicion posicion)
			: base(TamanioInicial, posicion)
		{
		}
	}
}

