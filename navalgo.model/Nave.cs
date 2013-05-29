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

		public Direccion Direccion {
			get;
			private set;
		}

		public bool Destruida {
			get {
				return PosicionesDePartesSanas.Count () == 0;
			}
		}

		public IEnumerable<Posicion> PosicionesDePartesSanas {
			get { return this.Partes.Where (p => !p.Destruida()).Select (p => p.Posicion); }
		}

		public IEnumerable<Posicion> PosicionesDePartesDestruidas {
			get { return this.Partes.Where (p => p.Destruida()).Select (p => p.Posicion); }
		}

		public IEnumerable<Posicion> PosicionesOcupadas {
			get {
				return this.Partes.Select (p => p.Posicion);
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

			this.Direccion = direccion;

			this.CrearPartes (tamanio, posicion, tipoDeParte);
		}

		public virtual void DaniarConDisparoConvencional(Posicion posicionImpactada)
		{
			this.DestruirParte (new[] { posicionImpactada });
		}

		public virtual void DaniarConMina(IEnumerable<Posicion> posicionesImpactadas)
		{
			this.DestruirParte (posicionesImpactadas);
		}

		public void AvanzarPosicion()
		{
			foreach (IParte parte in this.Partes) 
			{
				parte.ActualizarPosicion (parte.Posicion.ObtenerSiguientePosicion(this.Direccion));
			}
		}

		public void RevertirDireccion ()
		{
			this.Direccion = this.Direccion.DireccionOpuesta();
			this.InvertirPartes();
		}

		private void DestruirParte(IEnumerable<Posicion> posicionesImpactadas)
		{
			if (this.PosicionesDePartesSanas.Count () == 0)
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

		private void CrearPartes (int tamanio, Posicion posicionInicial, Type tipoDeParte)
		{
			var partesCreadas = new List<IParte>();

			Posicion posicionParaParteCreada = posicionInicial;

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

		private void InvertirPartes()
		{
			int indexDesdeFrente = 0; 
			int indexDesdeAtras = this.Partes.Count() - 1;
			for (; indexDesdeFrente < indexDesdeAtras; indexDesdeFrente++, indexDesdeAtras--) 
			{
				IParte parteFrente = this.Partes.ElementAt (indexDesdeFrente);
				IParte parteAtras = this.Partes.ElementAt (indexDesdeAtras);
				Posicion posicionAtras = parteAtras.Posicion;

				parteAtras.ActualizarPosicion (parteFrente.Posicion);
				parteFrente.ActualizarPosicion (posicionAtras);
			}
		}
	}
}

