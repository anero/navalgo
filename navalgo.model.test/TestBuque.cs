using System;
using NUnit.Framework;
using System.Linq;

namespace navalgo.model.test
{
	[TestFixture]
	public class TestBuque
	{
		[Test]
		public void DeberiaInicializarCorrectamenteLosAtributos ()
		{
			var posicion = new Posicion ('e', 5);
			var buque = new Buque (posicion, Direccion.Oeste, TestHelper.AreaDePosicionesValidasDefault);

			Assert.AreEqual (4, buque.Tamanio);
			Assert.IsTrue (buque.PosicionesOcupadas.Any(p => p.Equals(new Posicion('e', 5))));
			Assert.IsTrue (buque.PosicionesOcupadas.Any(p => p.Equals(new Posicion('d', 5))));
			Assert.IsTrue (buque.PosicionesOcupadas.Any(p => p.Equals(new Posicion('c', 5))));
			Assert.IsTrue (buque.PosicionesOcupadas.Any(p => p.Equals(new Posicion('b', 5))));
			Assert.AreEqual (Direccion.Oeste, buque.Direccion);
			Assert.IsFalse (buque.Destruida);
			Assert.AreEqual (4, buque.PosicionesDePartesSanas.Count());
			Assert.AreEqual (0, buque.PosicionesDePartesDestruidas.Count());
		}

		[Test]
		public void UnDisparoConvencionalDeberiaDestruirBuque()
		{
			var posicion = new Posicion ('e', 5);
			var buque = new Buque (posicion, Direccion.Norte, TestHelper.AreaDePosicionesValidasDefault);

			buque.DaniarConDisparoConvencional (posicion);

			Assert.IsTrue (buque.Destruida);
			Assert.AreEqual (4, buque.PosicionesDePartesDestruidas.Count());
			Assert.AreEqual (0, buque.PosicionesDePartesSanas.Count());
		}

		[Test]
		public void UnaMinaDeberiaDestruirBuque()
		{
			var posicion = new Posicion ('e', 5);
			var buque = new Buque (posicion, Direccion.Norte, TestHelper.AreaDePosicionesValidasDefault);

			buque.DaniarConMina (new[] { posicion });

			Assert.IsTrue (buque.Destruida);
			Assert.AreEqual (4, buque.PosicionesDePartesDestruidas.Count());
			Assert.AreEqual (0, buque.PosicionesDePartesSanas.Count());
		}
	}
}

