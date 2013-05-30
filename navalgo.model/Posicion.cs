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
			this.ValidarColumna (columna);

			if (fila < 0) {
				throw new FilaInvalidaException (fila);
			}

			this.Columna = columna;
			this.Fila = fila;
		}

		public Posicion ObtenerSiguientePosicion(Direccion direccion)
		{
			return new Posicion (this.ObtenerColumnaSiguiente(direccion), this.ObtenerFilaSiguiente (direccion));
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
			int offset;
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
			case Direccion.Norte:
			case Direccion.Sur:
				offset = 0;
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

		private int ObtenerFilaSiguiente(Direccion direccion)
		{
			int offset;
			switch (direccion) {
			case Direccion.Norte:
			case Direccion.NorEste:
			case Direccion.NorOeste:
				offset = -1;
				break;
			case Direccion.SurEste:
			case Direccion.Sur:
			case Direccion.SurOeste:
				offset = 1;
				break;
			case Direccion.Este:
			case Direccion.Oeste:
				offset = 0;
				break;
			default:
				throw new ArgumentException (string.Format ("No se puede obtener siguiente fila para la direccion '{0}'", direccion));
			}

			int filaSiguiente = this.Fila + offset;
			this.ValidarFila (filaSiguiente);

			return filaSiguiente;
		}

		private void ValidarFila(int fila)
		{
			if (fila <= 0)
				throw new FilaInvalidaException (fila);
		}
	}
}

