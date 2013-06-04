using System;

namespace navalgo.model
{
	public class MinaPorContacto : Disparo
	{
		public MinaPorContacto (Posicion posicionObjetivo)
			: base(posicionObjetivo)
		{
		}

		public override void ImpactarNave(INave nave)
		{
			nave.DaniarConMina (new[] { this.PosicionObjetivo });
		}

		public override void DecrementarVidaUtil ()
		{
			this.VidaUtilRestante = 0;
		}
	}
}

