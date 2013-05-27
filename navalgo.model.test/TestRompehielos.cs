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
			var rompehielos = new Rompehielos ();

			Assert.AreEqual (3, rompehielos.Tamanio);
			Assert.IsFalse (rompehielos.Destruida);
			Assert.AreEqual (3, rompehielos.PartesSanas);
			Assert.AreEqual (0, rompehielos.PartesDestruidas);
		}
	}
}

