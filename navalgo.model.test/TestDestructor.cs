using System;
using NUnit.Framework;
using System.Linq;

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
			Assert.IsTrue (destructor.PosicionesOcupadas.Any(p => p.Equals(new Posicion('e', 5))));
			Assert.IsTrue (destructor.PosicionesOcupadas.Any(p => p.Equals(new Posicion('f', 5))));
			Assert.IsTrue (destructor.PosicionesOcupadas.Any(p => p.Equals(new Posicion('g', 5))));
			Assert.AreEqual (Direccion.Este, destructor.Direccion);
			Assert.IsFalse (destructor.Destruida);
			Assert.AreEqual (3, destructor.PosicionesDePartesSanas.Count());
			Assert.AreEqual (0, destructor.PosicionesDePartesDestruidas.Count());
		}

		[Test]
		public void DisparoDirectoDeberiaDestruirParte()
		{
			var posicion = new Posicion ('e', 5);
			var destructor = new Destructor (posicion, Direccion.Norte);
			Assert.AreEqual (0, destructor.PosicionesDePartesDestruidas.Count());

			destructor.DaniarConDisparoConvencional (posicion);

			Assert.AreEqual (1, destructor.PosicionesDePartesDestruidas.Count());
		}

		[Test]
		public void MinaNoDeberiaDestruirParte()
		{
			var posicion = new Posicion ('e', 5);
			var destructor = new Destructor (posicion, Direccion.Norte);
			Assert.AreEqual (0, destructor.PosicionesDePartesDestruidas.Count());

			destructor.DaniarConMina (new[] { posicion });

			Assert.AreEqual (0, destructor.PosicionesDePartesDestruidas.Count());
		}

		[Test]
		public void TresDisparosConvencionalesDeberianDestruirDestructor()
		{
			var posicion = new Posicion ('e', 5);
			var destructor = new Destructor (posicion, Direccion.Norte);
			Assert.AreEqual (0, destructor.PosicionesDePartesDestruidas.Count());

			destructor.DaniarConDisparoConvencional (new Posicion('e', 5));
			destructor.DaniarConDisparoConvencional (new Posicion('e', 4));
			destructor.DaniarConDisparoConvencional (new Posicion('e', 3));

			Assert.IsTrue (destructor.Destruida);
			Assert.AreEqual (3, destructor.PosicionesDePartesDestruidas.Count());
			Assert.AreEqual (0, destructor.PosicionesDePartesSanas.Count());
		}
	}
}

