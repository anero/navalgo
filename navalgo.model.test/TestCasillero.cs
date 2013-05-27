using System;
using NUnit.Framework;

namespace navalgo.model.test
{
	[TestFixture]
	public class TestCasillero
	{
		[Test]
		public void DeberiaInicializarsePosicionAlConstruir()
		{
			var casillero = new Casillero ('a', 1);

			Assert.AreEqual ('a', casillero.Columna);
			Assert.AreEqual (1, casillero.Fila);
		}

		[Test]
		public void DeberiaSetearNave()
		{
			var casillero = new Casillero ('a', 1);
			var mockNave = new MockNave ();

			casillero.Nave = mockNave;

			Assert.AreSame (mockNave, casillero.Nave);
		}

		[Test]
		[ExpectedException(typeof(NaveInvalidaException))]
		public void DeberiaArrojarExcepcionAlSetearNullANave()
		{
			var casillero = new Casillero ('a', 1);

			casillero.Nave = null;
		}

		class MockNave : INave
		{
		}
	}
}

