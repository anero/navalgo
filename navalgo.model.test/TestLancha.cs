using System;
using NUnit.Framework;
using System.Linq;

namespace navalgo.model.test
{
	[TestFixture]
	public class TestLancha
	{
		[Test]
		public void DeberiaInicializarCorrectamenteLosAtributos ()
		{
			var posicion = new Posicion ('e', 5);
			var lancha = new Lancha (posicion, Direccion.Norte);

			Assert.AreEqual (2, lancha.Tamanio);
			Assert.IsTrue (lancha.PosicionesOcupadas.Any(p => p.Equals(new Posicion('e', 5))));
			Assert.IsTrue (lancha.PosicionesOcupadas.Any(p => p.Equals(new Posicion('e', 4))));
			Assert.AreEqual (Direccion.Norte, lancha.Direccion);
			Assert.IsFalse (lancha.Destruida);
			Assert.AreEqual (2, lancha.PosicionesDePartesSanas.Count ());
			Assert.AreEqual (0, lancha.PosicionesDePartesDestruidas.Count ());
		}

		[Test]
		public void DosDisparosDeCualquierTipoDeberianDestruirLaLancha()
		{
			var posicion = new Posicion ('e', 5);
			var lancha = new Lancha (posicion, Direccion.Norte);

			Assert.AreEqual (2, lancha.PosicionesDePartesSanas.Count());
			Assert.AreEqual (0, lancha.PosicionesDePartesDestruidas.Count());

			lancha.DaniarConDisparoConvencional (new Posicion ('e', 5));
			lancha.DaniarConMina (new[] { new Posicion ('e', 4) });

			Assert.IsTrue (lancha.Destruida);
			Assert.AreEqual (0, lancha.PosicionesDePartesSanas.Count());
			Assert.AreEqual (2, lancha.PosicionesDePartesDestruidas.Count());
		}
	}
}

