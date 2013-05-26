using System;

namespace navalgo.model
{
	public class Casillero
	{
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

		public Casillero (char columna, int fila)
		{
			this.Columna = columna;
			this.Fila = fila;
		}
	}
}

