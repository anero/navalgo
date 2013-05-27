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
			var mockNave = new MockNave (10, new Posicion ('a', 1));

			Assert.AreEqual (10, mockNave.Tamanio);
		}

		[Test]
		public void DeberiaSetearPosicionAlConstruir()
		{
			var posicion = new Posicion ('a', 1);
			var mockNave = new MockNave (1, posicion);

			Assert.IsTrue (posicion.Equals(mockNave.Posicion));
		}

		[Test]
		[ExpectedException(typeof(TamanioInvalidoDeNaveException))]
		public void DeberiaLanzarExcepcionAlSetearTamanioInvalido()
		{
			new MockNave (0, new Posicion ('a', 1));
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void DeberiaLanzarExcepcionAlSetearPosicionInvalida()
		{
			new MockNave (6, null);
		}

		[Test]
		public void DisparoDeberiaDaniarNave()
		{
			var mockNave = new MockNave (3, new Posicion ('a', 1));

			Assert.AreEqual (3, mockNave.PartesSanas);
			Assert.AreEqual (0, mockNave.PartesDestruidas);

			mockNave.DaniarConDisparoConvencional ();

			Assert.AreEqual (2, mockNave.PartesSanas);
			Assert.AreEqual (1, mockNave.PartesDestruidas);
		}

		[Test]
		public void MinaDeberiaDaniarNave()
		{
			var mockNave = new MockNave (3, new Posicion ('a', 1));

			Assert.AreEqual (3, mockNave.PartesSanas);
			Assert.AreEqual (0, mockNave.PartesDestruidas);

			mockNave.DaniarConMina ();

			Assert.AreEqual (2, mockNave.PartesSanas);
			Assert.AreEqual (1, mockNave.PartesDestruidas);
		}

		[Test]
		[ExpectedException(typeof(NaveYaDestruidaException))]
		public void DaniarSobreNaveDestruidaDeberiaArrojarExcepcion()
		{
			var mockNave = new MockNave (1, new Posicion ('a', 1));
			mockNave.DaniarConDisparoConvencional ();

			mockNave.DaniarConDisparoConvencional ();
		}

		class MockNave : Nave
		{
			public MockNave(int tamanio, Posicion posicion)
				: base(tamanio, posicion)
			{
			}
		}
	}
}

