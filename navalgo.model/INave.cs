using System;

namespace navalgo.model
{
	public interface INave
	{
		Posicion Posicion { get; }

		void DaniarConDisparoConvencional();

		void DaniarConMina();
	}
}

