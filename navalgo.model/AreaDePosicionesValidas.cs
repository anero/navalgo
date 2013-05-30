using System;
using System.Drawing;

namespace navalgo.model
{
	public class AreaDePosicionesValidas
	{
		private Rectangle rectangulo;

		public AreaDePosicionesValidas (Posicion verticeNorOeste, Posicion verticeNorEste, Posicion verticeSurOeste, Posicion verticeSurEste)
		{
			this.ValidarVertices (verticeNorOeste, verticeNorEste, verticeSurOeste, verticeSurEste);

			this.CrearRectangulo (verticeNorOeste, verticeNorEste, verticeSurOeste, verticeSurEste);
		}

		public bool PosicionEsValida(Posicion posicion)
		{
			return this.rectangulo.Contains(this.ConvertirPosicionAPoint(posicion));
		}

		private void CrearRectangulo(Posicion verticeNorOeste, Posicion verticeNorEste, Posicion verticeSurOeste, Posicion verticeSurEste)
		{
			Point origen = this.ConvertirPosicionAPoint (verticeNorOeste);
			int ancho = (int)(verticeNorEste.Columna - verticeNorOeste.Columna) + 1;
			int alto = verticeSurOeste.Fila - verticeNorOeste.Fila + 1;

			this.rectangulo = new Rectangle (origen, new Size(ancho, alto));
		}

		private Point ConvertirPosicionAPoint(Posicion posicion)
		{
			int x = (int)(posicion.Columna - 'a');
			int y = posicion.Fila;

			return new Point (x, y);
		}

		private void ValidarVertices (Posicion verticeNorOeste, Posicion verticeNorEste, Posicion verticeSurOeste, Posicion verticeSurEste)
		{
			if (verticeSurOeste.Columna > verticeSurEste.Columna)
				throw new CoordenadasInvalidasParaAreaDePosicionesValidasException (string.Format ("El vertice SO ({0},{1}) no puede estar al Este del vertice SE ({2},{3})", verticeSurOeste.Columna, verticeSurOeste.Fila, verticeSurEste.Columna, verticeSurEste.Fila));

			if (verticeSurOeste.Fila < verticeNorOeste.Fila)
				throw new CoordenadasInvalidasParaAreaDePosicionesValidasException (string.Format ("El vertice SO ({0},{1}) no puede estar al Norte del vertice NO ({2},{3})", verticeSurOeste.Columna, verticeSurOeste.Fila, verticeNorOeste.Columna, verticeNorOeste.Fila));
				
			if (verticeSurEste.Fila < verticeNorEste.Fila)
				throw new CoordenadasInvalidasParaAreaDePosicionesValidasException (string.Format ("El vertice SE ({0},{1}) no puede estar al Norte del vertice NE ({2},{3})", verticeSurEste.Columna, verticeSurEste.Fila, verticeNorEste.Columna, verticeNorEste.Fila));

			if (verticeNorEste.Columna < verticeNorOeste.Columna)
				throw new CoordenadasInvalidasParaAreaDePosicionesValidasException (string.Format ("El vertice NE ({0},{1}) no puede estar al Oeste del vertice NO ({2},{3})", verticeNorEste.Columna, verticeNorEste.Fila, verticeNorOeste.Columna, verticeNorOeste.Fila));

			if (verticeSurEste.Columna != verticeNorEste.Columna)
				throw new CoordenadasInvalidasParaAreaDePosicionesValidasException (string.Format ("El vertice SE ({0},{1}) debe estar en la misma latitud que el vertice NE ({2},{3})", verticeSurEste.Columna, verticeSurEste.Fila, verticeNorEste.Columna, verticeNorEste.Fila));

			if (verticeSurEste.Fila != verticeSurOeste.Fila)
				throw new CoordenadasInvalidasParaAreaDePosicionesValidasException (string.Format ("El vertice SE ({0},{1}) debe estar en la misma longitud que el vertice SO ({2},{3})", verticeSurEste.Columna, verticeSurEste.Fila, verticeSurOeste.Columna, verticeSurOeste.Fila));

			if (verticeNorEste.Fila != verticeNorOeste.Fila)
				throw new CoordenadasInvalidasParaAreaDePosicionesValidasException (string.Format ("El vertice NE ({0},{1}) debe estar en la misma longitud que el vertice NO ({2},{3})", verticeNorEste.Columna, verticeNorEste.Fila, verticeNorOeste.Columna, verticeNorOeste.Fila));

			if (verticeNorOeste.Columna != verticeSurOeste.Columna)
				throw new CoordenadasInvalidasParaAreaDePosicionesValidasException (string.Format ("El vertice NO ({0},{1}) debe estar en la misma latitud que el vertice SO ({2},{3})", verticeNorOeste.Columna, verticeNorOeste.Fila, verticeSurOeste.Columna, verticeSurOeste.Fila));
		}
	}
}

