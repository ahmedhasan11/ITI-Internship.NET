using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOpAdvancedShapeApp
{
	public class Line:Shape
	{
		Point start = new Point(0, 0);
		Point End = new Point(0, 0);
		Color CO;

		public Line()
		{
			Point start = new Point(0, 0);
			Point End = new Point(0, 0);
			CO = Raylib_cs.Color.Black;
		}
		public Line(Point start, Point end, Color cO)
		{
			this.start = start;
			End = end;
			CO = cO;
		}
		public Line(int x1, int y1 ,int x2, int y2, Color co)
		{
			start.setX(x1);
			start.setY(y1);
			End.setX(x2);
			End.setY(y2);
			CO = co;
		}
		public override void Draw()
		{
			Raylib.DrawLine(start.getX(), start.getY(), End.getX(), End.getY(),CO);
		}
	}
}