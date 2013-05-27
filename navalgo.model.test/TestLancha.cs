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
		public void DisparoDeberiaDestruirParte()
		{
			var lancha = new Lancha ();
			var mockDisparo = new MockDisparo ();

			Assert.AreEqual (2, lancha.PartesSanas);
			Assert.AreEqual (0, lancha.PartesDestruidas);

			lancha.Impactar (mockDisparo);

			Assert.AreEqual (1, lancha.PartesSanas);
			Assert.AreEqual (1, lancha.PartesDestruidas);
		}

		[Test]
		public void DosDisparosDeberianDestruirLaLancha()
		{
			var lancha = new Lancha ();
			var mockDisparo = new MockDisparo ();

			Assert.AreEqual (2, lancha.PartesSanas);
			Assert.AreEqual (0, lancha.PartesDestruidas);

			lancha.Impactar (mockDisparo);
			lancha.Impactar (mockDisparo);

			Assert.IsTrue (lancha.Destruida);
			Assert.AreEqual (0, lancha.PartesSanas);
			Assert.AreEqual (2, lancha.PartesDestruidas);
		}

		[Test]
		[ExpectedException(typeof(NaveYaDestruidaException))]
		public void ImpactarSobreLanchaDestruidaDeberiaArrojarExcepcion()
		{
			var lancha = new Lancha ();
			var mockDisparo = new MockDisparo ();
			lancha.Impactar (mockDisparo);
			lancha.Impactar (mockDisparo);

			lancha.Impactar (mockDisparo);
		}

		class MockDisparo : IDisparo
		{
		}
	}
}

