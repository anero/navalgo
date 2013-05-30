using System;
using NUnit.Framework;
using System.Linq;

namespace navalgo.model.test
{
	[TestFixture]
	public class TestRompehielos
	{
		[Test]
		public void DeberiaCrearLasPartesAlInicializar ()
		{
			var posicion = new Posicion ('e', 5);
			var rompehielos = new Rompehielos (posicion, Direccion.NorOeste, TestHelper.AreaDePosicionesValidasDefault);

			Assert.AreEqual (3, rompehielos.Tamanio);
			Assert.IsTrue (rompehielos.PosicionesOcupadas.Any(p => p.Equals(new Posicion('e', 5))));
			Assert.IsTrue (rompehielos.PosicionesOcupadas.Any(p => p.Equals(new Posicion('d', 4))));
			Assert.IsTrue (rompehielos.PosicionesOcupadas.Any(p => p.Equals(new Posicion('c', 3))));
			Assert.AreEqual (Direccion.NorOeste, rompehielos.Direccion);
			Assert.IsFalse (rompehielos.Destruida);
			Assert.AreEqual (3, rompehielos.PosicionesDePartesSanas.Count ());
			Assert.AreEqual (0, rompehielos.PosicionesDePartesDestruidas.Count ());
		}
	}
}

