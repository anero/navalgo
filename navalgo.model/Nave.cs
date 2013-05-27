using System;

namespace navalgo.model
{
	public abstract class Nave
	{
		public int Tamanio {
			get;
			private set;
		}

		protected Nave (int tamanio)
		{
			if (tamanio <= 0) {
				throw new TamanioInvalidoDeNaveException (tamanio);
			}

			this.Tamanio = tamanio;
		}
	}
}

