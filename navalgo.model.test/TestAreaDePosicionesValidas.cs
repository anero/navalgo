using System;
using NUnit.Framework;

namespace navalgo.model.test
{
	[TestFixture]
	public class TestAreaDePosicionesValidas
	{
		[Test]
		[ExpectedException(typeof(CoordenadasInvalidasParaAreaDePosicionesValidasException))]
		public void DeberiaValidarQueLadoNO_SOEsteALaDerechaDelLadoNE_SE()
		{
			var verticeNorOeste = new Posicion ('k', 1);
			var verticeNorEste = new Posicion ('a', 1);
			var verticeSurOeste = new Posicion ('k', 10);
			var verticeSurEste = new Posicion ('a', 10);

			new AreaDePosicionesValidas (
				verticeNorOeste: verticeNorOeste,
				verticeNorEste: verticeNorEste,
				verticeSurOeste: verticeSurOeste,
				verticeSurEste: verticeSurEste);
		}

		[Test]
		[ExpectedException(typeof(CoordenadasInvalidasParaAreaDePosicionesValidasException))]
		public void DeberiaValidarQueLadoNO_NEEsteArribaDelSO_SE()
		{
			var verticeNorOeste = new Posicion ('a', 5);
			var verticeNorEste = new Posicion ('j', 5);
			var verticeSurOeste = new Posicion ('a', 1);
			var verticeSurEste = new Posicion ('j', 1);

			new AreaDePosicionesValidas (
				verticeNorOeste: verticeNorOeste,
				verticeNorEste: verticeNorEste,
				verticeSurOeste: verticeSurOeste,
				verticeSurEste: verticeSurEste);
		}

		[Test]
		[ExpectedException(typeof(CoordenadasInvalidasParaAreaDePosicionesValidasException))]
		public void DeberiaValidarQueVerticeSEEsteEnMismaFilaQueSO()
		{
			var verticeNorOeste = new Posicion ('a', 1);
			var verticeNorEste = new Posicion ('j', 1);
			var verticeSurOeste = new Posicion ('a', 12);
			var verticeSurEste = new Posicion ('j', 10);

			new AreaDePosicionesValidas (
				verticeNorOeste: verticeNorOeste,
				verticeNorEste: verticeNorEste,
				verticeSurOeste: verticeSurOeste,
				verticeSurEste: verticeSurEste);
		}

		[Test]
		[ExpectedException(typeof(CoordenadasInvalidasParaAreaDePosicionesValidasException))]
		public void DeberiaValidarQueVerticeSEEsteEnMismaColumnaQueNE()
		{
			var verticeNorOeste = new Posicion ('b', 1);
			var verticeNorEste = new Posicion ('j', 1);
			var verticeSurOeste = new Posicion ('a', 10);
			var verticeSurEste = new Posicion ('j', 10);

			new AreaDePosicionesValidas (
				verticeNorOeste: verticeNorOeste,
				verticeNorEste: verticeNorEste,
				verticeSurOeste: verticeSurOeste,
				verticeSurEste: verticeSurEste);
		}

		[Test]
		[ExpectedException(typeof(CoordenadasInvalidasParaAreaDePosicionesValidasException))]
		public void DeberiaValidarQueVerticeNEEsteEnMismaFilaQueNO()
		{
			var verticeNorOeste = new Posicion ('a', 1);
			var verticeNorEste = new Posicion ('j', 3);
			var verticeSurOeste = new Posicion ('a', 10);
			var verticeSurEste = new Posicion ('j', 10);

			new AreaDePosicionesValidas (
				verticeNorOeste: verticeNorOeste,
				verticeNorEste: verticeNorEste,
				verticeSurOeste: verticeSurOeste,
				verticeSurEste: verticeSurEste);
		}

		[Test]
		[ExpectedException(typeof(CoordenadasInvalidasParaAreaDePosicionesValidasException))]
		public void DeberiaValidarQueVerticeNOEsteEnMismaColumnaQueSO()
		{
			var verticeNorOeste = new Posicion ('a', 1);
			var verticeNorEste = new Posicion ('j', 1);
			var verticeSurOeste = new Posicion ('b', 10);
			var verticeSurEste = new Posicion ('j', 10);

			new AreaDePosicionesValidas (
				verticeNorOeste: verticeNorOeste,
				verticeNorEste: verticeNorEste,
				verticeSurOeste: verticeSurOeste,
				verticeSurEste: verticeSurEste);
		}

		[Test]
		public void DeberiaDevolverTrueSiPosicionEsInternaAArea()
		{
			var areaDePosicionesValidas = new AreaDePosicionesValidas (
				verticeNorOeste: new Posicion ('a', 1),
				verticeNorEste: new Posicion ('j', 1),
				verticeSurOeste: new Posicion ('a', 10),
				verticeSurEste: new Posicion ('j', 10));

			Assert.IsTrue (areaDePosicionesValidas.PosicionEsValida(new Posicion('d', 5)));
		}

		[Test]
		public void DeberiaDevolverTrueSiPosicionEsVerticeDeArea()
		{
			var areaDePosicionesValidas = new AreaDePosicionesValidas (
				verticeNorOeste: new Posicion ('a', 1),
				verticeNorEste: new Posicion ('j', 1),
				verticeSurOeste: new Posicion ('a', 10),
				verticeSurEste: new Posicion ('j', 10));

			Assert.IsTrue (areaDePosicionesValidas.PosicionEsValida(new Posicion('j', 1)));
        }

		[Test]
		public void DeberiaDevolverTrueSiPosicionEsLimiteDeArea()
		{
			var areaDePosicionesValidas = new AreaDePosicionesValidas (
				verticeNorOeste: new Posicion ('a', 1),
				verticeNorEste: new Posicion ('j', 1),
				verticeSurOeste: new Posicion ('a', 10),
				verticeSurEste: new Posicion ('j', 10));

			Assert.IsTrue (areaDePosicionesValidas.PosicionEsValida(new Posicion('c', 1)));
		}

		[Test]
		public void DeberiaDevolverFalseSiPosicionEstaFueraDeAreaPorLongitud()
		{
			var areaDePosicionesValidas = new AreaDePosicionesValidas (
				verticeNorOeste: new Posicion ('a', 1),
				verticeNorEste: new Posicion ('j', 1),
				verticeSurOeste: new Posicion ('a', 10),
				verticeSurEste: new Posicion ('j', 10));

			Assert.IsFalse (areaDePosicionesValidas.PosicionEsValida(new Posicion('a', 12)));
		}

		[Test]
		public void DeberiaDevolverFalseSiPosicionEstaFueraDeAreaPorLatitud()
		{
			var areaDePosicionesValidas = new AreaDePosicionesValidas (
				verticeNorOeste: new Posicion ('a', 1),
				verticeNorEste: new Posicion ('j', 1),
				verticeSurOeste: new Posicion ('a', 10),
				verticeSurEste: new Posicion ('j', 10));

			Assert.IsFalse (areaDePosicionesValidas.PosicionEsValida(new Posicion('h', 5)));
		}
	}
}

