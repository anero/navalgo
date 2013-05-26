using System;
using NUnit.Framework;

namespace navalgo.model.test
{
	[TestFixture()]
	public class TestCasillero
	{
		[Test()]
		public void DeberiaInicializarsePosicionAlConstruir()
		{
			var casillero = new Casillero ('a', 1);

			Assert.AreEqual ('a', casillero.Columna);
			Assert.AreEqual (1, casillero.Fila);
		}
	}
}

