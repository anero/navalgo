using System;
using System.Collections.Generic;

namespace navalgo.model
{
	public interface INave
	{
		IEnumerable<Posicion> PosicionesOcupadas { get; }

		Direccion Direccion { get; }

		void DaniarConDisparoConvencional(Posicion posicionImpactada);

		void DaniarConMina(IEnumerable<Posicion> posicionesImpactadas);

		void AvanzarPosicion();

		void RevertirDireccion ();
	}
}

