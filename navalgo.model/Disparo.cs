using System;

namespace navalgo.model
{
	public abstract class Disparo : IDisparo
	{
		public Posicion PosicionObjetivo {
			get;
			private set;
		}

		public Disparo (Posicion posicionObjetivo)
		{
			if (posicionObjetivo == null) {
				throw new ArgumentNullException ("posicionObjetivo");
			}

			this.PosicionObjetivo = posicionObjetivo;
		}

		public abstract void ImpactarNave(INave nave);
	}
}

