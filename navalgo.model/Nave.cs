using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace navalgo.model
{
	public abstract class Nave : INave
	{
		private AreaDePosicionesValidas areaDePosicionesValidas;

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

		protected Nave(int tamanio, Posicion posicion, Direccion direccion, Type tipoDeParte, AreaDePosicionesValidas areaDePosicionesValidas)
		{
			if (tamanio <= 0) {
				throw new TamanioInvalidoDeNaveException (tamanio);
			}

			if (posicion == null) {
				throw new ArgumentNullException ("posicion");
			}

			this.areaDePosicionesValidas = areaDePosicionesValidas;
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
			if (!this.IntentarAvanzar ()) 
			{
				this.Direccion = this.Direccion.DireccionOpuesta ();
				Debug.Assert(this.IntentarAvanzar ());
			}
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

		private bool IntentarAvanzar()
		{
			var diccionarioActualizacionDePosicionesDePartes = new Dictionary<IParte, Posicion> ();

			try
			{
				foreach (IParte parte in this.Partes) 
				{
					Posicion posicionSiguiente = parte.Posicion.ObtenerSiguientePosicion(this.Direccion);
					if (this.areaDePosicionesValidas.PosicionEsValida(posicionSiguiente))
					{
						diccionarioActualizacionDePosicionesDePartes.Add (parte, posicionSiguiente);
					}
					else
					{
						return false;
					}
				}
			}
			catch(PosicionInvalidaException) 
			{
				return false;
			}

			foreach (IParte parteAActualizar in diccionarioActualizacionDePosicionesDePartes.Keys) 
			{
				parteAActualizar.ActualizarPosicion (diccionarioActualizacionDePosicionesDePartes[parteAActualizar]);
			}

			return true;
		}
	}
}

