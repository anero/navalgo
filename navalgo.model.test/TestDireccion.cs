using System;
using NUnit.Framework;

namespace navalgo.model.test
{
	[TestFixture]
	public class TestDireccion
	{
		[Test]
		public void DeberiaResolverDireccionOpuestaANorte()
		{
			Assert.AreEqual(Direccion.Sur, Direccion.Norte.DireccionOpuesta());
		}

		[Test]
		public void DeberiaResolverDireccionOpuestaASur()
		{
			Assert.AreEqual(Direccion.Norte, Direccion.Sur.DireccionOpuesta());
		}

		[Test]
		public void DeberiaResolverDireccionOpuestaAEste()
		{
			Assert.AreEqual(Direccion.Oeste, Direccion.Este.DireccionOpuesta());
		}

		[Test]
		public void DeberiaResolverDireccionOpuestaAOeste()
		{
			Assert.AreEqual(Direccion.Este, Direccion.Oeste.DireccionOpuesta());
		}

		[Test]
		public void DeberiaResolverDireccionOpuestaANorOeste()
		{
			Assert.AreEqual(Direccion.SurEste, Direccion.NorOeste.DireccionOpuesta());
		}

		[Test]
		public void DeberiaResolverDireccionOpuestaASurOeste()
		{
			Assert.AreEqual(Direccion.NorEste, Direccion.SurOeste.DireccionOpuesta());
		}

		[Test]
		public void DeberiaResolverDireccionOpuestaANorEste()
		{
			Assert.AreEqual(Direccion.SurOeste, Direccion.NorEste.DireccionOpuesta());
		}

		[Test]
		public void DeberiaResolverDireccionOpuestaASurEste()
		{
			Assert.AreEqual(Direccion.NorOeste, Direccion.SurEste.DireccionOpuesta());
		}
	}
}

