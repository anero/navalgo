using System;
using NUnit.Framework;

namespace navalgo.model.test
{
	[TestFixture]
	public class TestRompehielos
	{
		[Test]
		public void DeberiaCrearLasPartesAlInicializar ()
		{
			var posicion = new Posicion ('e', 5);
			var rompehielos = new Rompehielos (posicion, Direccion.NorOeste);

			Assert.AreEqual (3, rompehielos.Tamanio);
			Assert.AreEqual (posicion, rompehielos.Posicion);
			Assert.AreEqual (Direccion.NorOeste, rompehielos.Direccion);
			Assert.IsFalse (rompehielos.Destruida);
			Assert.AreEqual (3, rompehielos.PartesSanas);
			Assert.AreEqual (0, rompehielos.PartesDestruidas);
		}
	}
}

