using System;

namespace navalgo.model
{
	public interface INave
	{
		Posicion Posicion { get; }

		Direccion Direccion { get; }

		void DaniarConDisparoConvencional();

		void DaniarConMina();
	}
}

