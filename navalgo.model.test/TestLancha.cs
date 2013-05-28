using System;
using NUnit.Framework;

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
			Assert.AreEqual (posicion, lancha.Posicion);
			Assert.AreEqual (Direccion.Norte, lancha.Direccion);
			Assert.IsFalse (lancha.Destruida);
			Assert.AreEqual (2, lancha.PartesSanas);
			Assert.AreEqual (0, lancha.PartesDestruidas);
		}

		[Test]
		public void DosDisparosDeCualquierTipoDeberianDestruirLaLancha()
		{
			var posicion = new Posicion ('e', 5);
			var lancha = new Lancha (posicion, Direccion.Norte);

			Assert.AreEqual (2, lancha.PartesSanas);
			Assert.AreEqual (0, lancha.PartesDestruidas);

			lancha.DaniarConDisparoConvencional (new Posicion ('e', 5));
			lancha.DaniarConMina (new[] { new Posicion ('e', 4) });

			Assert.IsTrue (lancha.Destruida);
			Assert.AreEqual (0, lancha.PartesSanas);
			Assert.AreEqual (2, lancha.PartesDestruidas);
		}
	}
}

