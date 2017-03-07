using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Duckventure
{
	internal sealed class Map
	{
		public static int MAPWIDTH = 138;
		public static int MAPHEIGHT = 36;

		public CellType [,] Cells { get; set; }

		public Map ()
		{
			Cells = new CellType[MAPWIDTH, MAPHEIGHT];
		}
		public static Map Load(string filename)
		{
			using (StreamReader sr = new StreamReader(filename))
			{
				Map map = new Map ();
				for (int y = 0; y < MAPHEIGHT; y++) 
				{
					string line = sr.ReadLine ();
					for (int x = 0; x < MAPWIDTH; x++) 
					{
						switch (line[x])
						{
						case '.':
							map.Cells [x, y] = CellType.Air;
							break;
						case '#':
							map.Cells [x, y] = CellType.Platform;
							break;
                        case '+':
                            map.Cells[x, y] = CellType.HitboxPlatform;
                            break;
						default:
							throw new NotSupportedException ();
						}

					}
				}
				return map;
			}
		}
	}
	public enum CellType
		{
			Air, Platform, HitboxPlatform
		}
	
}

