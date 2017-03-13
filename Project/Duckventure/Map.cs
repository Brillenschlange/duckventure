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
							map.Cells[x, y] = CellType.Air;
							break;
						case '1':
							map.Cells[x, y] = CellType.Platform1;
							break;
                        case '2':
                            map.Cells[x, y] = CellType.Platform2;
                            break;
                        case '3':
                            map.Cells[x, y] = CellType.Platform3;
                            break;
                        case '!':
                            map.Cells[x, y] = CellType.Water1;
                            break;
                        case '?':
                            map.Cells[x, y] = CellType.Water2;
                            break;
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
			Air, Platform1, Platform2, Platform3, Water1, Water2
		}
	
}

