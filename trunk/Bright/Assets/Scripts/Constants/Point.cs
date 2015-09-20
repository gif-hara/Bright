using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	public class Point
	{
		public Point(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}

		public Point(Vector3 position)
		{
			this.X = (int)position.x;
			this.Y = (int)position.y;
		}

		public int X{ set; get; }

		public int Y{ set; get; }

		public override string ToString ()
		{
			return string.Format ("[Point: X={0}, Y={1}]", X, Y);
		}

		public static Point Left{ get{ return new Point(-1, 0); } }

		public static Point Right{ get{ return new Point(1, 0); } }

		public static Point Top{ get{ return new Point(0, 1); } }

		public static Point Bottom{ get{ return new Point(0, -1); } }

		public static Point Zero{ get{ return new Point(0, 0); } }

		public static Point One{ get{ return new Point(1, 1); } }

		public static Point operator +(Point a, Point b)
		{
			return new Point(a.X + b.X, a.Y + b.Y);
		}

		public static Vector3 operator +(Point a, Vector3 b)
		{
			return new Vector3(a.X + b.x, a.Y + b.y);
		}

		public static Point operator -(Point a, Point b)
		{
			return new Point(a.X - b.X, a.Y - b.Y);
		}

		public static Point operator *(Point a, int b)
		{
			return new Point(a.X * b, a.Y * b);
		}
	}
}
