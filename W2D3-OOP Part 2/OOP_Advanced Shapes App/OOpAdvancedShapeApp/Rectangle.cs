using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOpAdvancedShapeApp
{
	public class Rectangle:Shape
	{
		Point LR=new Point(0,0) ;
		Point UL=new Point(0,0) ;
		Color CO;
		public Rectangle()
		{
			Point LR = new Point(0, 0);
			Point UL = new Point(0, 0);
			CO = Raylib_cs.Color.Black;
		}
		public Rectangle(int x1 , int y1 , int x2 , int y2, Color color)
		{
			LR = new Point(x1, y1);
			UL = new Point(x2, y2);
			CO = color;
		}
		public override void Draw()
		{
			int width = LR.getX() - UL.getX();
			int height = LR.getY() - UL.getY();
			Raylib.DrawRectangle(UL.getX(), UL.getY(), width, height, CO);
		}



	}
}