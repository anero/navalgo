using System;

namespace navalgo.model
{
	public class Destructor  :	Nave
	{
		private const int TamanioInicial = 3;

		public Destructor ()
			:base(TamanioInicial)
		{
		}

		public override void DaniarConMina ()
		{
			// Las minas no danian a los destructores
		}
	}
}

