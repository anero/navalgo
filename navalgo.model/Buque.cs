using System;
using System.Collections.Generic;

namespace navalgo.model
{
	public class Buque : Nave
	{
		private const int TamanioInicial = 4;

		public Buque (Posicion posicion, Direccion direccion)
			: base(TamanioInicial, posicion, direccion)
		{
		}

		public override void DaniarConDisparoConvencional (Posicion posicionImpactada)
		{
			this.PartesDestruidas = TamanioInicial;
		}

		public override void DaniarConMina (IEnumerable<Posicion> posicionesImpactadas)
		{
			this.PartesDestruidas = TamanioInicial;
		}
	}
}

