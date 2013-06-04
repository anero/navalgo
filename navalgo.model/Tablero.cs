using System;
using System.Collections.Generic;
using System.Linq;

namespace navalgo.model
{
	public class Tablero
	{
		private readonly AreaDePosicionesValidas areaDePosicionesValidas;
		private readonly IList<INave> naves;

		public Tablero ()
		{
			this.areaDePosicionesValidas = new AreaDePosicionesValidas (
				verticeNorOeste: new Posicion('a', 1),
				verticeNorEste: new Posicion('j', 1),
				verticeSurOeste: new Posicion('a', 10),
				verticeSurEste: new Posicion('j', 10)
			);

			this.naves = new List<INave> ();
		}

		public AreaDePosicionesValidas GetAreaDePosicionesValidas()
		{
			return this.areaDePosicionesValidas;
		}

		public void ColocarNave(INave nave)
		{
			if (nave == null)
				throw new ArgumentNullException ("nave");

			if (this.naves.Any (n => n == nave))
				throw new NaveYaEstaEnTableroException ();

			this.naves.Add (nave);
		}

		public INave GetNaveEn(Posicion posicion)
		{
			if (!this.areaDePosicionesValidas.PosicionEsValida (posicion)) {
				throw new PosicionFueraDeAreaDePosicionesValidasException ();
			}

			foreach (INave nave in this.naves) {
				if (nave.PosicionesOcupadas.Any (p => p.Equals(posicion))) {
					return nave;
				}
			}

			return default(INave);
		}
	}
}

