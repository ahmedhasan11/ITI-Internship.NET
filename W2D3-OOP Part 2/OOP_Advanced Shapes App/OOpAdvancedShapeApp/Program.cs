using Raylib_cs;
using OOpAdvancedShapeApp;
using System.Drawing;

namespace OOpAdvancedShapeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
			Raylib.InitWindow(800, 600, "Hello World");

			while (!Raylib.WindowShouldClose())
			{
				Raylib.BeginDrawing();
				Raylib.ClearBackground(Raylib_cs.Color.White);
				Circle c = new Circle(70, 70, 100, Raylib_cs.Color.Red);
				Circle c2 = new Circle(200, 200, 100, Raylib_cs.Color.Blue);
				Line l = new Line(500, 500, 240, 240, Raylib_cs.Color.Magenta);
				Rectangle r = new Rectangle(10, 10, 150, 100, Raylib_cs.Color.Yellow);
				Shape[] shapes = new Shape[4];
				shapes[0] = c;
				shapes[1] = l;
				shapes[2] = r;
				shapes[3] = c2;
				DrawShapes(shapes);
				Raylib.EndDrawing();
			}

			Raylib.CloseWindow();
		}

		public static void DrawShapes(Shape[] shapes)
		{
			foreach (Shape c in shapes)
			{
				c.Draw();
			}
		}
	}
}

