using System;
using System.Collections.Generic;

namespace navalgo.model
{
	public class Destructor  :	Nave
	{
		private const int TamanioInicial = 3;

		public Destructor (Posicion posicion, Direccion direccion)
			: base(TamanioInicial, posicion, direccion, typeof(Parte))
		{
		}

		public override void DaniarConMina (IEnumerable<Posicion> posicionesImpactadas)
		{
			// Las minas no danian a los destructores
		}
	}
}

