using System;

namespace navalgo.model
{
	public class DisparoConvencional : Disparo
	{
		public DisparoConvencional (Posicion posicionObjetivo)
			: base(posicionObjetivo)
		{
			
		}

		public override void ImpactarNave(INave nave)
		{
			nave.DaniarConDisparoConvencional (this.PosicionObjetivo);
		}
	}
}

