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
			get;
			private set;
		}

		public int PartesDestruidas {
			get;
			private set;
		}

		public Lancha ()
			: base(TamanioInicial)
		{
			this.PartesSanas = TamanioInicial;
			this.PartesDestruidas = 0;
		}

		public void Impactar(IDisparo disparo)
		{
			this.PartesSanas -= 1;
			this.PartesDestruidas += 1;
		}
	}
}

