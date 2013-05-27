using System;

namespace navalgo.model
{
	public class Posicion
	{
		public char Columna {
			get;
			private set;
		}

		public int Fila {
			get;
			private set;
		}

		public Posicion (char columna, int fila)
		{
			columna = Char.ToLower (columna);
			if (columna < 'a' || columna > 'z') {
				throw new ColumnaInvalidaException (columna);
			}

			if (fila < 0) {
				throw new FilaInvalidaException (fila);
			}

			this.Columna = columna;
			this.Fila = fila;
		}

		public Posicion ObtenerSiguientePosicion(Direccion direccion)
		{
			switch (direccion) {
			case Direccion.Norte:
				return new Posicion (this.Columna, this.Fila - 1);
			case Direccion.Sur:
				return new Posicion (this.Columna, this.Fila + 1);
			case Direccion.Este:
				return new Posicion (this.ObtenerColumnaSiguiente(Direccion.Este), this.Fila);
			case Direccion.Oeste:
				return new Posicion (this.ObtenerColumnaSiguiente(Direccion.Oeste), this.Fila);
			case Direccion.NorEste:
				return new Posicion (this.ObtenerColumnaSiguiente(Direccion.NorEste), this.Fila - 1);
			case Direccion.SurEste:
				return new Posicion (this.ObtenerColumnaSiguiente(Direccion.SurEste), this.Fila + 1);
			case Direccion.NorOeste:
				return new Posicion (this.ObtenerColumnaSiguiente(Direccion.NorOeste), this.Fila - 1);
			case Direccion.SurOeste:
				return new Posicion (this.ObtenerColumnaSiguiente(Direccion.SurOeste), this.Fila + 1);
			default:
				throw new NotImplementedException();
			}
		}

		public override bool Equals (object obj)
		{
			var otraPosicion = obj as Posicion;
			if (otraPosicion == null)
				return false;


			return Char.ToLowerInvariant(this.Columna) == Char.ToLowerInvariant(otraPosicion.Columna) && this.Fila == otraPosicion.Fila;
		}

		public override int GetHashCode ()
		{
			return Char.ToLowerInvariant(this.Columna).GetHashCode () + this.Fila.GetHashCode ();
		}

		private char ObtenerColumnaSiguiente(Direccion direccion)
		{
			int offset = 0;
			switch (direccion) {
			case Direccion.Este:
			case Direccion.NorEste:
			case Direccion.SurEste:
				offset = 1;
				break;
			case Direccion.Oeste:
			case Direccion.NorOeste:
			case Direccion.SurOeste:
				offset = -1;
				break;
			default:
				throw new ArgumentException (string.Format ("No se puede obtener siguiente columna para la direccion '{0}'", direccion));
			}

			char siguienteColumna = (char) (this.Columna + (char)offset);
			this.ValidarColumna(siguienteColumna);

            return siguienteColumna;
		}

		private void ValidarColumna(char columna)
		{
			columna = Char.ToLower (columna);
			if (columna < 'a' || columna > 'z') {
				throw new ColumnaInvalidaException (columna);
			}
		}
	}
}

