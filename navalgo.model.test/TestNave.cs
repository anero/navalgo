using System;
using NUnit.Framework;

namespace navalgo.model.test
{
	[TestFixture]
	public class TestNave
	{
		[Test]
		public void DeberiaSetearTamanioAlConstruir ()
		{
			var mockNave = new MockNave (10);

			Assert.AreEqual (10, mockNave.Tamanio);
		}

		[Test]
		[ExpectedException(typeof(TamanioInvalidoDeNaveException))]
		public void DeberiaLanzarExcepcionAlSetearTamanioInvalido()
		{
			new MockNave (0);
		}

		[Test]
		public void DisparoDeberiaDestruirParte()
		{
			var mockNave = new MockNave (3);
			var mockDisparo = new MockDisparo ();

			Assert.AreEqual (3, mockNave.PartesSanas);
			Assert.AreEqual (0, mockNave.PartesDestruidas);

			mockNave.Impactar (mockDisparo);

			Assert.AreEqual (2, mockNave.PartesSanas);
			Assert.AreEqual (1, mockNave.PartesDestruidas);
		}

		[Test]
		[ExpectedException(typeof(NaveYaDestruidaException))]
		public void ImpactarSobreNaveDestruidaDeberiaArrojarExcepcion()
		{
			var mockNave = new MockNave (1);
			var mockDisparo = new MockDisparo ();
			mockNave.Impactar (mockDisparo);

			mockNave.Impactar (mockDisparo);
		}

		class MockNave : Nave
		{
			public MockNave(int tamanio)
				: base(tamanio)
			{
			}
		}

		class MockDisparo : IDisparo
		{
		}
	}
}

