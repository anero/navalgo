using System;
using NUnit.Framework;

namespace navalgo.model.test
{
	[TestFixture]
	public class TestParte
	{
		[Test]
		public void DeberiaEstarIntactaAlInicializar()
		{
			var posicion = new Posicion ('a', 1);
			var parte = new Parte (posicion);

			Assert.IsFalse (parte.Destruida());
		}

		[Test]
		public void DeberiaInicializarPosicion()
		{
			var posicion = new Posicion ('a', 1);
			var parte = new Parte (posicion);

			Assert.AreEqual (posicion, parte.Posicion);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void DeberiaLanzarExcepcionSiPosicionEsNull()
		{
			new Parte (null);
		}

		[Test]
		public void DeberiaDestruirse ()
		{
			var posicion = new Posicion ('a', 1);
			var parte = new Parte (posicion);

			parte.RecibirImpacto ();

			Assert.IsTrue (parte.Destruida());
		}

		[Test]
		[ExpectedException(typeof(ParteDestruidaException))]
		public void DeberiaLanzarExcepcionSiRecibeImpactoLuegoDeDestruida()
		{
			var posicion = new Posicion ('a', 1);
			var parte = new Parte (posicion);
			parte.RecibirImpacto ();

			parte.RecibirImpacto ();
		}

		[Test]
		public void DeberiaActualizarLaPosicion()
		{
			var posicionInicial = new Posicion ('a', 1);
			var parte = new Parte (posicionInicial);

			Assert.AreEqual (posicionInicial, parte.Posicion);

			var posicionNueva = new Posicion ('z', 100);
			parte.ActualizarPosicion(posicionNueva);

			Assert.AreEqual (posicionNueva, parte.Posicion);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void DeberiaLanzarExcepcionSiNuevaPosicionEsNullAlActualizarPosicion()
		{
			var parte = new Parte (new Posicion ('a', 1));

			parte.ActualizarPosicion(null);
		}
	}
}

