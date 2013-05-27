using System;
using NUnit.Framework;

namespace navalgo.model.test
{
	[TestFixture]
	public class TestBuque
	{
		[Test]
		public void DeberiaCrearLasPartesAlInicializar ()
		{
			var buque = new Buque (new Posicion ('a', 1));

			Assert.AreEqual (4, buque.Tamanio);
			Assert.IsFalse (buque.Destruida);
			Assert.AreEqual (4, buque.PartesSanas);
			Assert.AreEqual (0, buque.PartesDestruidas);
		}

		[Test]
		public void UnDisparoConvencionalDeberiaDestruirBuque()
		{
			var buque = new Buque (new Posicion ('a', 1));

			buque.DaniarConDisparoConvencional ();

			Assert.IsTrue (buque.Destruida);
			Assert.AreEqual (4, buque.PartesDestruidas);
			Assert.AreEqual (0, buque.PartesSanas);
		}

		[Test]
		public void UnaMinaDeberiaDestruirBuque()
		{
			var buque = new Buque (new Posicion ('a', 1));

			buque.DaniarConMina ();

			Assert.IsTrue (buque.Destruida);
			Assert.AreEqual (4, buque.PartesDestruidas);
			Assert.AreEqual (0, buque.PartesSanas);
		}
	}
}

