using System;

namespace navalgo.model
{
	public class Rompehielos : Nave
	{
		private const int TamanioInicial = 3;

		public Rompehielos (Posicion posicion, Direccion direccion, AreaDePosicionesValidas areaDePosicionesValidas)
			: base(TamanioInicial, posicion, direccion, typeof(ParteDobleDuracion), areaDePosicionesValidas)
		{
		}
	}
}

