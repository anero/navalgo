using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace navalgo.model.test
{
	[TestFixture]
	public class TestMinaPorContacto
	{
		[Test]
		public void DeberiaInicializarPosicionObjetivoAlConstruir()
		{
			var minaPorContacto = new MinaPorContacto (new Posicion('a', 1));

			Assert.IsTrue (minaPorContacto.PosicionObjetivo.Equals (new Posicion('a', 1)));
		}

		[Test]
		public void DeberiaImpactarNave()
		{
			var minaPorContacto = new MinaPorContacto (new Posicion('a', 1));
			var mockNave = new MockNave ();

			minaPorContacto.ImpactarNave (mockNave);

			Assert.IsTrue (mockNave.DaniarConMinaInvocado);
			Assert.IsFalse (mockNave.DaniarConDisparoConvencionalInvocado);
			Assert.AreEqual (1, mockNave.ArgumentoPosicionesImpactadasRecibidoEnDaniarConMina.Count ());
			Assert.IsTrue (mockNave.ArgumentoPosicionesImpactadasRecibidoEnDaniarConMina.ElementAt(0).Equals(new Posicion('a', 1)));
		}

		class MockNave : INave
		{
			public bool DaniarConDisparoConvencionalInvocado {
				get;
				set;
			}

			public bool DaniarConMinaInvocado {
				get;
				set;
			}

			public IEnumerable<Posicion> ArgumentoPosicionesImpactadasRecibidoEnDaniarConMina {
				get;
				set;
			}

			public IEnumerable<Posicion> PosicionesOcupadas {
				get {
					throw new NotImplementedException ();
				}
			}

			public Direccion Direccion {
				get {
					throw new NotImplementedException ();
				}
			}

			public void DaniarConDisparoConvencional (Posicion posicionImpactada)
			{
				this.DaniarConDisparoConvencionalInvocado = true;
			}

			public void DaniarConMina (IEnumerable<Posicion> posicionesImpactadas)
			{
				this.DaniarConMinaInvocado = true;
				this.ArgumentoPosicionesImpactadasRecibidoEnDaniarConMina = posicionesImpactadas;
			}

			public void AvanzarPosicion ()
			{
				throw new NotImplementedException ();
			}
		}
	}
}

