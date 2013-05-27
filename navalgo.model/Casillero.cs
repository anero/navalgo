using System;

namespace navalgo.model
{
	public class Casillero
	{
		private INave nave;

		public char Columna 
		{
			get;
			private set;
		}

		public int Fila 
		{
			get;
			private set;
		}

		public INave Nave 
		{
			get 
			{
				return this.nave;
			}

			set 
			{
				if (value == null) {
					throw new NaveInvalidaException ();
				}

				this.nave = value;
			}
		}

		public Casillero (char columna, int fila)
		{
			this.Columna = columna;
			this.Fila = fila;
		}
	}
}

