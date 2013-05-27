using System;

namespace navalgo.model
{
	public class DisparoConvencional : IDisparo
	{
		public DisparoConvencional ()
		{
		}

		public void ImpactarNave(INave nave)
		{
			nave.DaniarConDisparoConvencional ();
		}
	}
}

