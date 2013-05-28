using System;
using System.Collections.Generic;
using System.Linq;

namespace navalgo.model
{
	public abstract class Nave : INave
	{
		protected IEnumerable<IParte> Partes {
			get;
			private set;
		}

		public int Tamanio {
			get { return this.Partes.Count (); }
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
			get { return this.Partes.Count (p => !p.Destruida()); }
		}

		public int PartesDestruidas {
			get { return this.Partes.Count (p => p.Destruida()); }
		}

		public IEnumerable<Posicion> PosicionesOcupadas {
			get {
				return this.Partes.Where (p => !p.Destruida()).Select (p => p.Posicion);
			}
		}

		protected Nave(int tamanio, Posicion posicion, Direccion direccion, Type tipoDeParte)
		{
			if (tamanio <= 0) {
				throw new TamanioInvalidoDeNaveException (tamanio);
			}

			if (posicion == null) {
				throw new ArgumentNullException ("posicion");
			}

			this.Posicion = posicion;
			this.Direccion = direccion;

			this.CrearPartes (tamanio, tipoDeParte);
		}

		public virtual void DaniarConDisparoConvencional(Posicion posicionImpactada)
		{
			this.DestruirParte (new[] { posicionImpactada });
		}

		public virtual void DaniarConMina(IEnumerable<Posicion> posicionesImpactadas)
		{
			this.DestruirParte (posicionesImpactadas);
		}

		private void DestruirParte(IEnumerable<Posicion> posicionesImpactadas)
		{
			if (this.PartesSanas == 0)
				throw new NaveYaDestruidaException ();

			foreach (var posicionImpactada in posicionesImpactadas) 
			{
				IParte parteImpactada = this.Partes.FirstOrDefault (p => p.Posicion.Equals(posicionImpactada));
				if (parteImpactada != null)
				{
					parteImpactada.RecibirImpacto ();
				}
			}
		}

		void CrearPartes (int tamanio, Type tipoDeParte)
		{
			var partesCreadas = new List<IParte>();

			Posicion posicionParaParteCreada = this.Posicion;

			try
			{
				for (int i=0; i < tamanio; i++) 
				{
					partesCreadas.Add((IParte)Activator.CreateInstance (tipoDeParte, posicionParaParteCreada));
					posicionParaParteCreada = posicionParaParteCreada.ObtenerSiguientePosicion (this.Direccion);
				}

				this.Partes = partesCreadas;
			}
			catch(PosicionInvalidaException)
			{
				throw new NaveFueraDeRangoException ();
			}
		}
	}
}

