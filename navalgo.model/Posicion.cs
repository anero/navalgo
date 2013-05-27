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
	}
}

