﻿using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace OOpAdvancedShapeApp
{
	public class Point
	{
		private int x;
		private int y;

		public Point(int x , int y)
		{
			this.x = x;
			this.y = y;
		}
		public  int getX()
		{
			return x;
		}
		public  int getY()
		{
			return y;
		}


		public  void setX(int x)
		{
			this.x = x;
		}

		public  void setY(int y)
		{
			this.y = y;
		}
	}
}