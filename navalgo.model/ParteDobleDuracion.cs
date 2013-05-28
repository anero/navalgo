using System;

namespace navalgo.model
{
	public class ParteDobleDuracion : Parte
	{
		private int impactosRecibidos;

		public ParteDobleDuracion (Posicion posicion)
			: base(posicion)
		{
			this.impactosRecibidos = 0;
		}

		public override void RecibirImpacto ()
		{
			if (this.Destruida())
				throw new ParteDestruidaException ();

			this.impactosRecibidos++;
		}

		public override bool Destruida()
		{
			return impactosRecibidos == 2;
		}
	}
}

