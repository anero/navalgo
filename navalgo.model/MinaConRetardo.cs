using System;

namespace navalgo.model
{
	public class MinaConRetardo : Disparo
	{
		public MinaConRetardo (Posicion posicionObjetivo)
			: base(posicionObjetivo)
		{
			this.VidaUtilRestante = 1;
		}

		public override void ImpactarNave (INave nave)
		{
			nave.DaniarConMina (new[] { this.PosicionObjetivo });
		}

		public override void DecrementarVidaUtil ()
		{
			if (this.Destruida)
				throw new DisparoYaDestruidoException ();

			this.VidaUtilRestante--;
		}
	}
}

