using System;
using NUnit.Framework;

namespace navalgo.model.test
{
	[TestFixture]
	public class TestTablero
	{
		[Test]
		public void DeberiaDevolverAreaDePosicionesValidasParaTableroDe10x10()
		{
			var tablero = new Tablero ();

			AreaDePosicionesValidas areaDePosicionesValidas = tablero.GetAreaDePosicionesValidas ();

			Assert.IsNotNull (areaDePosicionesValidas);
			Assert.IsTrue (areaDePosicionesValidas.PosicionEsValida(new Posicion('a', 1)));
			Assert.IsTrue (areaDePosicionesValidas.PosicionEsValida(new Posicion('a', 10)));
			Assert.IsTrue (areaDePosicionesValidas.PosicionEsValida(new Posicion('j', 1)));
			Assert.IsTrue (areaDePosicionesValidas.PosicionEsValida(new Posicion('j', 10)));
		}

		[Test]
		public void DeberiaColocarNave()
		{
			var tablero = new Tablero ();
			var lancha = new Lancha (new Posicion('d', 5), Direccion.Este, tablero.GetAreaDePosicionesValidas ());

			tablero.ColocarNave (lancha);

			Assert.AreSame(lancha, tablero.GetNaveEn(new Posicion('d', 5)));
			Assert.AreSame(lancha, tablero.GetNaveEn(new Posicion('e', 5)));
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void DeberiaArrojarExcepcionSiNaveAColocarEsNull()
		{
			var tablero = new Tablero ();

			tablero.ColocarNave (null);
		}

		[Test]
		[ExpectedException(typeof(NaveYaEstaEnTableroException))]
		public void DeberiaArrojarExcepcionSiLaNaveYaExisteEnElTablero()
		{
			var tablero = new Tablero ();
			var lancha = new Lancha (new Posicion('d', 5), Direccion.Este, tablero.GetAreaDePosicionesValidas ());

			tablero.ColocarNave (lancha);

			tablero.ColocarNave (lancha);
		}

		[Test]
		[ExpectedException(typeof(PosicionFueraDeAreaDePosicionesValidasException))]
		public void DeberiaArrojarExcepcionSiPosicionNoEstaDentroDeAreaValidaEnGetNaveEn()
		{
			var tablero = new Tablero ();

			tablero.GetNaveEn (new Posicion('k', 1));
		}
	}
}

