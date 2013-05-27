using System;
using NUnit.Framework;

namespace navalgo.model.test
{
	[TestFixture]
	public class TestNave
	{
		[Test]
		public void DeberiaSetearTamanioAlConstruir ()
		{
			var mockNave = new MockNave (10);

			Assert.AreEqual (10, mockNave.Tamanio);
		}

		[Test]
		[ExpectedException(typeof(TamanioInvalidoDeNaveException))]
		public void DeberiaLanzarExcepcionAlSetearTamanioInvalido()
		{
			new MockNave (0);
		}

		class MockNave : Nave
		{
			public MockNave(int tamanio)
				: base(tamanio)
			{
			}
		}
	}
}

