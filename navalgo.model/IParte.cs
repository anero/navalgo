using System;

namespace navalgo.model
{
	public interface IParte
	{
		bool Destruida { get; }

		void RecibirImpacto ();
	}
}

