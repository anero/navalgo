using System;
using System.Collections.Generic;

namespace navalgo.model
{
	public interface INave
	{
		Posicion Posicion { get; }

		Direccion Direccion { get; }

		void DaniarConDisparoConvencional(Posicion posicionImpactada);

		void DaniarConMina(IEnumerable<Posicion> posicionesImpactadas);
	}
}

