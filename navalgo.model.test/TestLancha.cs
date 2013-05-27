using System;
using NUnit.Framework;

namespace navalgo.model.test
{
	[TestFixture]
	public class TestLancha
	{
		[Test]
		public void DeberiaCrearLasPartesAlInicializar ()
		{
			var lancha = new Lancha ();

			Assert.AreEqual (2, lancha.Tamanio);
			Assert.IsFalse (lancha.Destruida);
			Assert.AreEqual (2, lancha.PartesSanas);
			Assert.AreEqual (0, lancha.PartesDestruidas);
		}

		[Test]
		public void DosDisparosDeCualquierTipoDeberianDestruirLaLancha()
		{
			var lancha = new Lancha ();

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

