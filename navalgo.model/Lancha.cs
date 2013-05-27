using System;

namespace navalgo.model
{
	public class Lancha : Nave
	{
		private const int TamanioInicial = 2;

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
			private set;
		}

		public Lancha ()
			: base(TamanioInicial)
		{
			this.PartesDestruidas = 0;
		}

		public void Impactar(IDisparo disparo)
		{
			if (this.PartesSanas == 0)
				throw new NaveYaDestruidaException ();

			this.PartesDestruidas += 1;
		}
	}
}

