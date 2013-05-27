using System;
using NUnit.Framework;

namespace navalgo.model.test
{
	[TestFixture]
	public class TestDestructor
	{
		[Test]
		public void DeberiaInicializarCorrectamenteLosAtributos ()
		{
			var posicion = new Posicion ('a', 1);
			var destructor = new Destructor (posicion, Direccion.Este);

			Assert.AreEqual (3, destructor.Tamanio);
			Assert.AreEqual (posicion, destructor.Posicion);
			Assert.AreEqual (Direccion.Este, destructor.Direccion);
			Assert.IsFalse (destructor.Destruida);
			Assert.AreEqual (3, destructor.PartesSanas);
			Assert.AreEqual (0, destructor.PartesDestruidas);
		}

		[Test]
		public void DisparoDirectoDeberiaDestruirParte()
		{
			var destructor = new Destructor (new Posicion ('a', 1), Direccion.Norte);
			Assert.AreEqual (0, destructor.PartesDestruidas);

			destructor.DaniarConDisparoConvencional ();

			Assert.AreEqual (1, destructor.PartesDestruidas);
		}

		[Test]
		public void MinaNoDeberiaDestruirParte()
		{
			var destructor = new Destructor (new Posicion ('a', 1), Direccion.Norte);
			Assert.AreEqual (0, destructor.PartesDestruidas);

			destructor.DaniarConMina ();

			Assert.AreEqual (0, destructor.PartesDestruidas);
		}

		[Test]
		public void TresDisparosConvencionalesDeberianDestruirDestructor()
		{
			var destructor = new Destructor (new Posicion ('a', 1), Direccion.Norte);
			Assert.AreEqual (0, destructor.PartesDestruidas);

			destructor.DaniarConDisparoConvencional ();
			destructor.DaniarConDisparoConvencional ();
			destructor.DaniarConDisparoConvencional ();

			Assert.IsTrue (destructor.Destruida);
			Assert.AreEqual (3, destructor.PartesDestruidas);
			Assert.AreEqual (0, destructor.PartesSanas);
		}
	}
}

