using System;

namespace navalgo.model
{
	public class Lancha : Nave
	{
		private const int TamanioInicial = 2;

		public Lancha (Posicion posicion, Direccion direccion)
			: base(TamanioInicial, posicion, direccion)
		{
		}
	}
}

