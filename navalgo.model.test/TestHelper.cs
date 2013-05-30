using System;

namespace navalgo.model.test
{
	public static class TestHelper
	{
		public static AreaDePosicionesValidas AreaDePosicionesValidasDefault = 
			new AreaDePosicionesValidas(
				verticeNorOeste: new Posicion ('a', 1),
				verticeNorEste: new Posicion ('j', 1),
				verticeSurOeste: new Posicion ('a', 10),
				verticeSurEste: new Posicion ('j', 10));
	}
}

