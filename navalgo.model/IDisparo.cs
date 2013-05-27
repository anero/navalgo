using System;

namespace navalgo.model
{
	public interface IDisparo
	{
		Posicion PosicionObjetivo { get; }

		void ImpactarNave(INave nave);
	}
}

