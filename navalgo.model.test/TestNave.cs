using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace navalgo.model.test
{
	[TestFixture]
	public class TestNave
	{
		[SetUp]
		public void SetUp()
		{
			MockParte.InstanciasConstruidas = null;
		}

		[Test]
		public void DeberiaSetearTamanioAlConstruir ()
		{
			var mockNave = new MockNave (4, new Posicion ('e', 5), Direccion.Norte);

			Assert.AreEqual (4, mockNave.Tamanio);
		}

		[Test]
		public void DeberiaSetearDireccionAlConstruir()
		{
			var mockNave = new MockNave (1, new Posicion ('e', 5), Direccion.Sur);

			Assert.AreEqual(Direccion.Sur, mockNave.Direccion);
		}

		[Test]
		public void DeberiaCrearPartesAlConstruir()
		{
			new MockNave (3, new Posicion ('a', 1), Direccion.Este, typeof(MockParte), TestHelper.AreaDePosicionesValidasDefault);
		
			Assert.AreEqual(3, MockParte.InstanciasConstruidas.Count);
			Assert.IsTrue(MockParte.InstanciasConstruidas.Any(p => p.Posicion.Equals(new Posicion('a', 1))));
			Assert.IsTrue(MockParte.InstanciasConstruidas.Any(p => p.Posicion.Equals(new Posicion('b', 1))));
			Assert.IsTrue(MockParte.InstanciasConstruidas.Any(p => p.Posicion.Equals(new Posicion('c', 1))));
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
			var posicion = new Posicion ('e', 5);
			var mockNave = new MockNave (3, posicion, Direccion.Norte);

			Assert.AreEqual (3, mockNave.PosicionesDePartesSanas.Count ());
			Assert.AreEqual (0, mockNave.PosicionesDePartesDestruidas.Count ());

			mockNave.DaniarConDisparoConvencional (posicion);

			Assert.AreEqual (2, mockNave.PosicionesDePartesSanas.Count ());
			Assert.AreEqual (1, mockNave.PosicionesDePartesDestruidas.Count ());
			Assert.IsTrue (mockNave.PosicionesDePartesDestruidas.ElementAt(0).Equals(posicion));
		}

		[Test]
		public void MinaDeberiaDaniarNave()
		{
			var posicion = new Posicion ('e', 5);
			var mockNave = new MockNave (3, posicion, Direccion.Norte);

			Assert.AreEqual (3, mockNave.PosicionesDePartesSanas.Count ());
			Assert.AreEqual (0, mockNave.PosicionesDePartesDestruidas.Count ());

			mockNave.DaniarConMina (new[] { posicion });

			Assert.AreEqual (2, mockNave.PosicionesDePartesSanas.Count ());
			Assert.AreEqual (1, mockNave.PosicionesDePartesDestruidas.Count ());
		}

		[Test]
		[ExpectedException(typeof(NaveYaDestruidaException))]
		public void DaniarSobreNaveDestruidaDeberiaArrojarExcepcion()
		{
			var posicion = new Posicion ('e', 5);
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

		[Test]
		public void DeberiaDevolverPosicionesOcupadasVerticalmente()
		{
			var posicionInicial = new Posicion ('d', 5);

			var mockNave = new MockNave (3, posicionInicial, Direccion.Sur);

			Assert.AreEqual (3, mockNave.PosicionesOcupadas.Count ());
			Assert.IsTrue (mockNave.PosicionesOcupadas.Any(po => po.Equals(new Posicion('d', 5))));
			Assert.IsTrue (mockNave.PosicionesOcupadas.Any(po => po.Equals(new Posicion('d', 6))));
			Assert.IsTrue (mockNave.PosicionesOcupadas.Any(po => po.Equals(new Posicion('d', 7))));
		}

		[Test]
		public void DeberiaDevolverPosicionesOcupadasDiagonalmente()
		{
			var posicionInicial = new Posicion ('d', 5);

			var mockNave = new MockNave (3, posicionInicial, Direccion.SurEste);

			Assert.AreEqual (3, mockNave.PosicionesOcupadas.Count ());
			Assert.IsTrue (mockNave.PosicionesOcupadas.Any(po => po.Equals(new Posicion('d', 5))));
			Assert.IsTrue (mockNave.PosicionesOcupadas.Any(po => po.Equals(new Posicion('e', 6))));
			Assert.IsTrue (mockNave.PosicionesOcupadas.Any(po => po.Equals(new Posicion('f', 7))));
		}

		[Test]
		[ExpectedException(typeof(NaveFueraDeRangoException))]
		public void DeberiaArrojarExcepcionSiInicializaConPosicionConFilaFueraDeRango()
		{
			var posicionInicial = new Posicion ('a', 1);

			new MockNave (3, posicionInicial, Direccion.Norte);
		}

		[Test]
		public void NoDeberiaDevolverPartesDestruidasDeLasPuntasAlDevolverPosicionesDePartesSanas()
		{
			var posicionInicial = new Posicion ('d', 5);

			var mockNave = new MockNave (3, posicionInicial, Direccion.Este);

			mockNave.DaniarConDisparoConvencional (new Posicion('d', 5));

			Assert.AreEqual (2, mockNave.PosicionesDePartesSanas.Count ());
			Assert.IsTrue (mockNave.PosicionesDePartesSanas.Any(po => po.Equals(new Posicion('e', 5))));
			Assert.IsTrue (mockNave.PosicionesDePartesSanas.Any(po => po.Equals(new Posicion('f', 5))));

			mockNave.DaniarConDisparoConvencional (new Posicion('f', 5));

			Assert.AreEqual (1, mockNave.PosicionesDePartesSanas.Count ());
			Assert.IsTrue (mockNave.PosicionesDePartesSanas.Any(po => po.Equals(new Posicion('e', 5))));
		}

		[Test]
		public void NoDeberiaDevolverPartesDestruidasDelMedioAlDevolverPosicionesDePartesSanas()
		{
			var posicionInicial = new Posicion ('a', 5);

			var mockNave = new MockNave (4, posicionInicial, Direccion.Este);

			mockNave.DaniarConDisparoConvencional (new Posicion('b', 5));

			Assert.AreEqual (3, mockNave.PosicionesDePartesSanas.Count ());
			Assert.IsTrue (mockNave.PosicionesDePartesSanas.Any(po => po.Equals(new Posicion('a', 5))));
			Assert.IsTrue (mockNave.PosicionesDePartesSanas.Any(po => po.Equals(new Posicion('c', 5))));
			Assert.IsTrue (mockNave.PosicionesDePartesSanas.Any(po => po.Equals(new Posicion('d', 5))));

			mockNave.DaniarConDisparoConvencional (new Posicion('c', 5));

			Assert.AreEqual (2, mockNave.PosicionesDePartesSanas.Count ());
			Assert.IsTrue (mockNave.PosicionesDePartesSanas.Any(po => po.Equals(new Posicion('a', 5))));
			Assert.IsTrue (mockNave.PosicionesDePartesSanas.Any(po => po.Equals(new Posicion('d', 5))));
		}

		[Test]
		public void DeberiaAvanzarUnaPosicionHaciaElFrente()
		{
			var mockNave = new MockNave (3, new Posicion ('d', 1), Direccion.Este);

			Assert.IsTrue (mockNave.PosicionesOcupadas.Any(po => po.Equals(new Posicion('d', 1))));
			Assert.IsTrue (mockNave.PosicionesOcupadas.Any(po => po.Equals(new Posicion('e', 1))));
			Assert.IsTrue (mockNave.PosicionesOcupadas.Any(po => po.Equals(new Posicion('f', 1))));

			mockNave.AvanzarPosicion ();

			Assert.IsTrue (mockNave.PosicionesOcupadas.Any(po => po.Equals(new Posicion('e', 1))));
			Assert.IsTrue (mockNave.PosicionesOcupadas.Any(po => po.Equals(new Posicion('f', 1))));
			Assert.IsTrue (mockNave.PosicionesOcupadas.Any(po => po.Equals(new Posicion('g', 1))));
		}

		[Test]
		public void DeberiaAvanzarUnaPosicionEnDiagonalHaciaElFrente()
		{
			var mockNave = new MockNave (3, new Posicion ('d', 1), Direccion.SurEste);

			Assert.IsTrue (mockNave.PosicionesOcupadas.Any(po => po.Equals(new Posicion('d', 1))));
			Assert.IsTrue (mockNave.PosicionesOcupadas.Any(po => po.Equals(new Posicion('e', 2))));
			Assert.IsTrue (mockNave.PosicionesOcupadas.Any(po => po.Equals(new Posicion('f', 3))));

			mockNave.AvanzarPosicion ();

			Assert.IsTrue (mockNave.PosicionesOcupadas.Any(po => po.Equals(new Posicion('e', 2))));
			Assert.IsTrue (mockNave.PosicionesOcupadas.Any(po => po.Equals(new Posicion('f', 3))));
			Assert.IsTrue (mockNave.PosicionesOcupadas.Any(po => po.Equals(new Posicion('g', 4))));
		}

		[Test]
		public void DeberiaRevertirDireccionHorizontalAlIntentarAvanzarPasandoUltimaPosicion()
		{
			var mockNave = new MockNave (3, new Posicion ('h', 4), Direccion.Este);

			mockNave.AvanzarPosicion ();

			Assert.IsTrue (mockNave.PosicionesOcupadas.Any(po => po.Equals(new Posicion('g', 4))));
			Assert.IsTrue (mockNave.PosicionesOcupadas.Any(po => po.Equals(new Posicion('h', 4))));
			Assert.IsTrue (mockNave.PosicionesOcupadas.Any(po => po.Equals(new Posicion('i', 4))));
		}

		class MockNave : Nave
		{
			public MockNave(int tamanio, Posicion posicion, Direccion direccion)
				: base(tamanio, posicion, direccion, typeof(Parte), TestHelper.AreaDePosicionesValidasDefault)
			{
			}

			public MockNave(int tamanio, Posicion posicion, Direccion direccion, Type tipoDeParte, AreaDePosicionesValidas areaDePosicionesValidas)
				: base(tamanio, posicion, direccion, tipoDeParte, areaDePosicionesValidas)
			{
			}
		}

		class MockParte : IParte
		{
			public static List<MockParte> InstanciasConstruidas {
				get; set;
			}

			public Posicion Posicion {
				get; set;
			}

			public MockParte (Posicion posicion)
			{
				this.Posicion = posicion;
				if (MockParte.InstanciasConstruidas == null) {
					MockParte.InstanciasConstruidas = new List<MockParte>();
				}

				MockParte.InstanciasConstruidas.Add(this);
			}

			public bool Destruida ()
			{
				throw new NotImplementedException ();
			}

			public void RecibirImpacto ()
			{
				throw new NotImplementedException ();
			}

			public void ActualizarPosicion (Posicion nuevaPosicion)
			{
				throw new NotImplementedException ();
			}
		}
	}
}

