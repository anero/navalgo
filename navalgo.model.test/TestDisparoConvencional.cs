using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace navalgo.model.test
{
	[TestFixture]
	public class TestDisparoConvencional
	{
		[Test]
		public void DeberiaDaniarNaveConDisparoConvencionalPasandoleLasPosiciones()
		{
			var posicion = new Posicion ('a', 5); 
			var disparoConvencional = new DisparoConvencional (posicion);
			var mockNave = new MockNave ();

			Assert.IsFalse (mockNave.DaniarConDisparoConvencionalInvocado);
			Assert.IsNull (mockNave.ArgumentoPosicionParaDaniarConDisparoConvencional);

			disparoConvencional.ImpactarNave (mockNave);

			Assert.IsTrue (mockNave.DaniarConDisparoConvencionalInvocado);
			Assert.AreEqual (posicion, mockNave.ArgumentoPosicionParaDaniarConDisparoConvencional);
		}

		class MockNave : INave
		{
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

			public bool DaniarConDisparoConvencionalInvocado {
				get;
				private set;
			}

			public Posicion ArgumentoPosicionParaDaniarConDisparoConvencional {
				get;
				private set;
			}

			public void DaniarConDisparoConvencional (Posicion posicionImpactada)
			{
				this.DaniarConDisparoConvencionalInvocado = true;
				this.ArgumentoPosicionParaDaniarConDisparoConvencional = posicionImpactada;
			}

			public void DaniarConMina (IEnumerable<Posicion> posicionesImpactadas)
			{
				throw new NotImplementedException ();
			}

			public void AvanzarPosicion ()
			{
				throw new NotImplementedException ();
			}

			public void RevertirDireccion ()
			{
				throw new NotImplementedException ();
			}
		}
	}
}

