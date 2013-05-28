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
			var posicion = new Posicion ('e', 5);
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
			var posicion = new Posicion ('e', 5);
			var destructor = new Destructor (posicion, Direccion.Norte);
			Assert.AreEqual (0, destructor.PartesDestruidas);

			destructor.DaniarConDisparoConvencional (posicion);

			Assert.AreEqual (1, destructor.PartesDestruidas);
		}

		[Test]
		public void MinaNoDeberiaDestruirParte()
		{
			var posicion = new Posicion ('e', 5);
			var destructor = new Destructor (posicion, Direccion.Norte);
			Assert.AreEqual (0, destructor.PartesDestruidas);

			destructor.DaniarConMina (new[] { posicion });

			Assert.AreEqual (0, destructor.PartesDestruidas);
		}

		[Test]
		public void TresDisparosConvencionalesDeberianDestruirDestructor()
		{
			var posicion = new Posicion ('e', 5);
			var destructor = new Destructor (posicion, Direccion.Norte);
			Assert.AreEqual (0, destructor.PartesDestruidas);

			destructor.DaniarConDisparoConvencional (new Posicion('e', 5));
			destructor.DaniarConDisparoConvencional (new Posicion('e', 4));
			destructor.DaniarConDisparoConvencional (new Posicion('e', 3));

			Assert.IsTrue (destructor.Destruida);
			Assert.AreEqual (3, destructor.PartesDestruidas);
			Assert.AreEqual (0, destructor.PartesSanas);
		}
	}
}

