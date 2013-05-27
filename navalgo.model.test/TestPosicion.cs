using System;
using NUnit.Framework;

namespace navalgo.model.test
{
	[TestFixture]
	public class TestPosicion
	{
		[Test]
		public void DeberiaSetearColumnaYFilaEnInicializacion()
		{
			var posicion = new Posicion ('a', 1);

			Assert.AreEqual ('a', posicion.Columna);
			Assert.AreEqual (1, posicion.Fila);
		}

		[Test]
		[ExpectedException(typeof(ColumnaInvalidaException))]
		public void DeberiaArrojarExcepcionSiColumnaEsInvalida()
		{
			new Posicion ('@', 1);
		}

		[Test]
		public void ColumnaDeberiaSerCaseInsensitive()
		{
			var posicion = new Posicion ('A', 10);

			Assert.AreEqual ('a', posicion.Columna);
		}

		[Test]
		[ExpectedException(typeof(FilaInvalidaException))]
		public void DeberiaArrojarExcepcionSiFilaEsInvalida()
		{
			new Posicion ('b', -10);
		}

		[Test]
		public void DeberiaCompararCorrectamentePosicionesIguales()
		{
			var posicion1 = new Posicion ('a', 5);
			var posicion2 = new Posicion ('a', 5);

			Assert.IsTrue (posicion1.Equals(posicion2));
		}

		[Test]
		public void DeberiaCompararCorrectamentePosicionesIgualesConColumnasEnDiferenteCase()
		{
			var posicion1 = new Posicion ('a', 5);
			var posicion2 = new Posicion ('A', 5);

			Assert.IsTrue (posicion1.Equals(posicion2));
		}

		[Test]
		public void DeberiaCompararCorrectametnePosicionesConDistintaColumna()
		{
			var posicion1 = new Posicion ('a', 5);
			var posicion2 = new Posicion ('b', 5);

			Assert.IsFalse (posicion1.Equals(posicion2));
		}

		[Test]
		public void DeberiaCompararCorrectametnePosicionesConDistintaFila()
		{
			var posicion1 = new Posicion ('a', 5);
			var posicion2 = new Posicion ('a', 10);

			Assert.IsFalse (posicion1.Equals(posicion2));
		}
	}
}

