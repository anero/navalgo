using System;

namespace navalgo.model
{
	public enum Direccion
	{
		Norte = 1,
		NorEste = 2,
		Este = 3,
		SurEste = 4,
		Sur = 5,
		SurOeste = 6,
		Oeste = 7,
		NorOeste = 8
	}

	public static class ExtensionesDireccion
	{
		public static Direccion DireccionOpuesta(this Direccion direccion)
		{
			switch (direccion) 
			{
			case Direccion.Norte:
				return Direccion.Sur;
			case Direccion.NorEste:
				return Direccion.SurOeste;
			case Direccion.Este:
				return Direccion.Oeste;
			case Direccion.SurEste:
			 	return Direccion.NorOeste;
			case Direccion.Sur:
				return Direccion.Norte;
			case Direccion.SurOeste:
				return Direccion.NorEste;
			case Direccion.Oeste:
				return Direccion.Este;
			case Direccion.NorOeste:
				return Direccion.SurEste;
			default:
				throw new InvalidOperationException ("La direccion no es valida");
			}
		}
	}
}

