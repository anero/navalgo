using System;

namespace navalgo.model
{
	public abstract class Nave
	{
		public int Tamanio {
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

		protected Nave (int tamanio)
		{
			if (tamanio <= 0) {
				throw new TamanioInvalidoDeNaveException (tamanio);
			}

			this.Tamanio = tamanio;
			this.PartesDestruidas = 0;
		}

		public virtual void Impactar(IDisparo disparo)
		{
			if (this.PartesSanas == 0)
				throw new NaveYaDestruidaException ();

			this.PartesDestruidas += 1;
		}
	}
}

