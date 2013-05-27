using System;
using NUnit.Framework;

namespace navalgo.model.test
{
	[TestFixture]
	public class TestBuque
	{
		[Test]
		public void DeberiaInicializarCorrectamenteLosAtributos ()
		{
			var posicion = new Posicion ('a', 1);
			var buque = new Buque (posicion, Direccion.Oeste);

			Assert.AreEqual (4, buque.Tamanio);
			Assert.AreEqual (posicion, buque.Posicion);
			Assert.AreEqual (Direccion.Oeste, buque.Direccion);
			Assert.IsFalse (buque.Destruida);
			Assert.AreEqual (4, buque.PartesSanas);
			Assert.AreEqual (0, buque.PartesDestruidas);
		}

		[Test]
		public void UnDisparoConvencionalDeberiaDestruirBuque()
		{
			var buque = new Buque (new Posicion ('a', 1), Direccion.Norte);

			buque.DaniarConDisparoConvencional ();

			Assert.IsTrue (buque.Destruida);
			Assert.AreEqual (4, buque.PartesDestruidas);
			Assert.AreEqual (0, buque.PartesSanas);
		}

		[Test]
		public void UnaMinaDeberiaDestruirBuque()
		{
			var buque = new Buque (new Posicion ('a', 1), Direccion.Norte);

			buque.DaniarConMina ();

			Assert.IsTrue (buque.Destruida);
			Assert.AreEqual (4, buque.PartesDestruidas);
			Assert.AreEqual (0, buque.PartesSanas);
		}
	}
}

