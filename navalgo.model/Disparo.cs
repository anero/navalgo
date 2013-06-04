using System;

namespace navalgo.model
{
	public abstract class Disparo : IDisparo
	{
		public Posicion PosicionObjetivo {
			get;
			private set;
		}

		public int VidaUtilRestante {
			get;
			protected set;
		}

		public bool Destruida {
			get {
				return this.VidaUtilRestante == 0;
			}
		}

		public Disparo (Posicion posicionObjetivo)
		{
			if (posicionObjetivo == null) {
				throw new ArgumentNullException ("posicionObjetivo");
			}

			this.PosicionObjetivo = posicionObjetivo;
		}

		public abstract void ImpactarNave(INave nave);

		public abstract void DecrementarVidaUtil ();
	}
}

