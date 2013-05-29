using System;

namespace navalgo.model
{
	public class Parte : IParte
	{
		private bool destruida;

		public Posicion Posicion {
			get;
			private set;
		}

		public Parte (Posicion posicion)
		{
			if (posicion == null)
			{
				throw new ArgumentNullException ("posicion");
			}

			this.destruida = false;
			this.Posicion = posicion;
		}

		public virtual void RecibirImpacto()
		{
			if (this.destruida)
				throw new ParteDestruidaException ();

			this.destruida = true;
		}

		public virtual bool Destruida()
		{
			return this.destruida;
		}

		public void ActualizarPosicion(Posicion nuevaPosicion)
		{
			if (nuevaPosicion == null) 
			{
				throw new ArgumentNullException ("nuevaPosicion");
			}
			this.Posicion = nuevaPosicion;
		}
	}
}

