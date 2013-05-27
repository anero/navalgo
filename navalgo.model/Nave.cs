using System;
using System.Collections.Generic;
using System.Linq;

namespace navalgo.model
{
	public abstract class Nave : INave
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

		public IEnumerable<Posicion> PosicionesOcupadas {
			get {
				return this.CalcularPosicionesOcupadas ();
			}
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

		public virtual void DaniarConDisparoConvencional(Posicion posicionImpactada)
		{
			this.DestruirParte ();
		}

		public virtual void DaniarConMina(IEnumerable<Posicion> posicionesImpactadas)
		{
			this.DestruirParte ();
		}

		private void DestruirParte()
		{
			if (this.PartesSanas == 0)
				throw new NaveYaDestruidaException ();

			this.PartesDestruidas += 1;
		}

		private IEnumerable<Posicion> CalcularPosicionesOcupadas()
		{
			var posicionesOcupadas = new List<Posicion> () { this.Posicion };
			for(int i=0; i < this.PartesSanas - 1; i++)
			{
				posicionesOcupadas.Add (posicionesOcupadas.Last().ObtenerSiguientePosicion(this.Direccion));
			}

			return posicionesOcupadas;
		}
	}
}

