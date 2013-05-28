using System;

namespace navalgo.model
{
	public interface IParte
	{
		Posicion Posicion { get; }

		bool Destruida();

		void RecibirImpacto ();
	}
}

