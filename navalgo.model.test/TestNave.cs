using System;
using NUnit.Framework;
using System.Linq;

namespace navalgo.model.test
{
	[TestFixture]
	public class TestNave
	{
		[Test]
		public void DeberiaSetearTamanioAlConstruir ()
		{
			var mockNave = new MockNave (10, new Posicion ('a', 1), Direccion.Norte);

			Assert.AreEqual (10, mockNave.Tamanio);
		}

		[Test]
		public void DeberiaSetearPosicionAlConstruir()
		{
			var posicion = new Posicion ('a', 1);
			var mockNave = new MockNave (1, posicion, Direccion.Norte);

			Assert.IsTrue (posicion.Equals(mockNave.Posicion));
		}

		[Test]
		public void DeberiaSetearDireccionAlConstruir()
		{
			var mockNave = new MockNave (1, new Posicion ('a', 1), Direccion.Sur);

			Assert.AreEqual(Direccion.Sur, mockNave.Direccion);
		}

		[Test]
		[ExpectedException(typeof(TamanioInvalidoDeNaveException))]
		public void DeberiaLanzarExcepcionAlSetearTamanioInvalido()
		{
			new MockNave (0, new Posicion ('a', 1), Direccion.Norte);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void DeberiaLanzarExcepcionAlSetearPosicionInvalida()
		{
			new MockNave (6, null, Direccion.Norte);
		}

		[Test]
		public void DisparoDeberiaDaniarNave()
		{
			var posicion = new Posicion ('a', 1);
			var mockNave = new MockNave (3, posicion, Direccion.Norte);

			Assert.AreEqual (3, mockNave.PartesSanas);
			Assert.AreEqual (0, mockNave.PartesDestruidas);

			mockNave.DaniarConDisparoConvencional (posicion);

			Assert.AreEqual (2, mockNave.PartesSanas);
			Assert.AreEqual (1, mockNave.PartesDestruidas);
		}

		[Test]
		public void MinaDeberiaDaniarNave()
		{
			var posicion = new Posicion ('a', 1);
			var mockNave = new MockNave (3, posicion, Direccion.Norte);

			Assert.AreEqual (3, mockNave.PartesSanas);
			Assert.AreEqual (0, mockNave.PartesDestruidas);

			mockNave.DaniarConMina (new[] { posicion });

			Assert.AreEqual (2, mockNave.PartesSanas);
			Assert.AreEqual (1, mockNave.PartesDestruidas);
		}

		[Test]
		[ExpectedException(typeof(NaveYaDestruidaException))]
		public void DaniarSobreNaveDestruidaDeberiaArrojarExcepcion()
		{
			var posicion = new Posicion ('a', 1);
			var mockNave = new MockNave (1, posicion, Direccion.Norte);
			mockNave.DaniarConDisparoConvencional (posicion);

			mockNave.DaniarConDisparoConvencional (posicion);
		}

		[Test]
		public void DeberiaDevolverPosicionesOcupadasHorizontalmente()
		{
			var posicionInicial = new Posicion ('d', 5);

			var mockNave = new MockNave (3, posicionInicial, Direccion.Este);

			Assert.AreEqual (3, mockNave.PosicionesOcupadas.Count ());
			Assert.IsTrue (mockNave.PosicionesOcupadas.Any(po => po.Equals(new Posicion('d', 5))));
			Assert.IsTrue (mockNave.PosicionesOcupadas.Any(po => po.Equals(new Posicion('e', 5))));
			Assert.IsTrue (mockNave.PosicionesOcupadas.Any(po => po.Equals(new Posicion('f', 5))));
		}

		class MockNave : Nave
		{
			public MockNave(int tamanio, Posicion posicion, Direccion direccion)
				: base(tamanio, posicion, direccion)
			{
			}
		}
	}
}

