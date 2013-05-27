using System;

namespace navalgo.model
{
	public abstract class Nave
	{
		public int Tamanio {
			get;
			private set;
		}

		public Posicion Posicion {
			get;
			private set;
		}

		public Direccion Direccion {
			get;
			private set;
		}

		public bool Destruida {
			get {
				return PartesSanas == 0;
			}
		}

		public int PartesSanas {
			get {
				return this.Tamanio - this.PartesDestruidas;
			}
		}

		public int PartesDestruidas {
			get;
			protected set;
		}

		protected Nave (int tamanio, Posicion posicion, Direccion direccion)
		{
			if (tamanio <= 0) {
				throw new TamanioInvalidoDeNaveException (tamanio);
			}

			if (posicion == null) {
				throw new ArgumentNullException ("posicion");
			}

			this.Tamanio = tamanio;
			this.Posicion = posicion;
			this.Direccion = direccion;
			this.PartesDestruidas = 0;
		}

		public virtual void DaniarConDisparoConvencional()
		{
			this.DestruirParte ();
		}

		public virtual void DaniarConMina()
		{
			this.DestruirParte ();
		}

		private void DestruirParte()
		{
			if (this.PartesSanas == 0)
				throw new NaveYaDestruidaException ();

			this.PartesDestruidas += 1;
		}
	}
}

