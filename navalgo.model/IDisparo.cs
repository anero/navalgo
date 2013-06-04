using System;

namespace navalgo.model
{
	public interface IDisparo
	{
		Posicion PosicionObjetivo { get; }

		int VidaUtilRestante { get; }

		bool Destruida { get; }

		void ImpactarNave(INave nave);

		void DecrementarVidaUtil ();
	}
}

