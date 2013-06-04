using System;
using NUnit.Framework;

namespace navalgo.model.test
{
	[TestFixture]
	public class TestDisparo
	{
		[Test]
		public void DeberiaSetearPosicionAlInicializar()
		{
			var posicion = new Posicion ('c', 10);

			var disparo = new MockDisparo (posicion);

			Assert.AreEqual (posicion, disparo.PosicionObjetivo);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void DeberiaArrojarExcepcionSiPosicionEsNull()
		{
			new MockDisparo (null);
		}

		class MockDisparo : Disparo
		{
			public MockDisparo (Posicion posicionObjetivo)
				: base(posicionObjetivo)
			{				
			}

			public override void ImpactarNave (INave nave)
			{
				throw new NotImplementedException ();
			}

			public override void DecrementarVidaUtil ()
			{
				throw new NotImplementedException ();
			}
		}
	}
}

