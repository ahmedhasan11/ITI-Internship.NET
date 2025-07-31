using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOpAdvancedShapeApp
{
	public class Circle:Shape
	{
		Point Center ;
		float Radius;
		Color CO;
		public Circle()
		{
			Point Center = new Point(0, 0);
			Radius = 10;
			CO = Raylib_cs.Color.Black;
		}
		public Circle(Point center,float radius )
		{
			Center = center;
			Radius = radius;
		}

		public Circle(int x , int y , int R, Color color)
		{
			Center = new Point(x, y);
			Radius = R;
			CO = color;
		}
		public override void Draw()
		{
			Raylib.DrawCircle(Center.getX(), Center.getY(), Radius, CO);
		}
	}
}