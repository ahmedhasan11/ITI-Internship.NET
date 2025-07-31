using Raylib_cs;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOpAdvancedShapeApp
{
	public class Shape
	{
		private Color CO;
		//public Shape()
		//{
		//	CO=Raylib_cs.Color.BLACK;
		//}
		public virtual void Draw()
		{

		}

		public Shape()
		{
			CO = Raylib_cs.Color.Black;
		}
	}
}