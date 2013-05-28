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
	}
}

