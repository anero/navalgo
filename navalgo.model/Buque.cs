using System;
using System.Collections.Generic;

namespace navalgo.model
{
	public class Buque : Nave
	{
		private const int TamanioInicial = 4;

		public Buque (Posicion posicion, Direccion direccion, AreaDePosicionesValidas areaDePosicionesValidas)
			: base(TamanioInicial, posicion, direccion, typeof(Parte), areaDePosicionesValidas)
		{
		}

		public override void DaniarConDisparoConvencional (Posicion posicionImpactada)
		{
			this.DestruirBuque ();
		}

		public override void DaniarConMina (IEnumerable<Posicion> posicionesImpactadas)
		{
			this.DestruirBuque ();
		}

		private void DestruirBuque()
		{
			foreach (IParte parte in this.Partes) 
			{
				if (!parte.Destruida ()) 
				{
					parte.RecibirImpacto ();
				}
			}
		}
	}
}

