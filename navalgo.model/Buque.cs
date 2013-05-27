using System;

namespace navalgo.model
{
	public class Buque : Nave
	{
		private const int TamanioInicial = 4;

		public Buque (Posicion posicion, Direccion direccion)
			: base(TamanioInicial, posicion, direccion)
		{
		}

		public override void DaniarConDisparoConvencional ()
		{
			this.PartesDestruidas = TamanioInicial;
		}

		public override void DaniarConMina ()
		{
			this.PartesDestruidas = TamanioInicial;
		}
	}
}

