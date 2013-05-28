using System;
using NUnit.Framework;

namespace navalgo.model.test
{
	[TestFixture]
	public class TestParteDobleDuracion
	{
		[Test]
		public void ParteDeberiaEstarIntactaAlInicializar()
		{
			var posicion = new Posicion ('a', 1);
			var parte = new ParteDobleDuracion (posicion);

			Assert.IsFalse (parte.Destruida());
		}

		[Test]
		public void ParteNoDeberiaDestruirseAlPrimerImpacto ()
		{
			var posicion = new Posicion ('a', 1);
			var parte = new ParteDobleDuracion (posicion);

			parte.RecibirImpacto ();

			Assert.IsFalse (parte.Destruida());
		}

		[Test]
		public void ParteDeberiaDestruirseAlSegundoImpacto ()
		{
			var posicion = new Posicion ('a', 1);
			var parte = new ParteDobleDuracion (posicion);

			parte.RecibirImpacto ();
			parte.RecibirImpacto ();

			Assert.IsTrue (parte.Destruida());
		}

		[Test]
		[ExpectedException(typeof(ParteDestruidaException))]
		public void ParteDeberiaLanzarExcepcionSiRecibeImpactoLuegoDeDestruida()
		{
			var posicion = new Posicion ('a', 1);
			var parte = new ParteDobleDuracion (posicion);
			parte.RecibirImpacto ();
			parte.RecibirImpacto ();

			parte.RecibirImpacto ();
		}
	}
}

