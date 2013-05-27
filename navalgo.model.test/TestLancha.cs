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
			var posicion = new Posicion ('a', 1);
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
			var lancha = new Lancha (new Posicion ('a', 1), Direccion.Norte);

			Assert.AreEqual (2, lancha.PartesSanas);
			Assert.AreEqual (0, lancha.PartesDestruidas);

			lancha.DaniarConDisparoConvencional ();
			lancha.DaniarConMina ();

			Assert.IsTrue (lancha.Destruida);
			Assert.AreEqual (0, lancha.PartesSanas);
			Assert.AreEqual (2, lancha.PartesDestruidas);
		}
	}
}

