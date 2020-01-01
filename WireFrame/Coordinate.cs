using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WireFrame
{
    public class Coordinate
    {
        public Vector3 Basic { get; set; }
        public Vector2 Projected { get; set; }

        public Coordinate(float x, float y, float z)
        {
            Basic = new Vector3(x, y, z);
        }

        public Coordinate(Vector3 point)
        {
            Basic = point;
        }

        public void ProjectIso(Vector2 ofset, int scale)
        {
            double u = Basic.X * Math.Cos(45 * Math.PI / 180) + Basic.Y * Math.Cos((45 + 120) * Math.PI / 180) + Basic.Z * Math.Cos((45 - 120) * Math.PI / 180);
            double v = Basic.X * Math.Sin(45 * Math.PI / 180) + Basic.Y * Math.Sin((45 + 120) * Math.PI / 180) + Basic.Z * Math.Sin((45 - 120) * Math.PI / 180);
            u = u * scale + ofset.X;
            v = v * scale + ofset.Y;
            Projected = new Vector2((float)u, (float)v);
        }
    }
}
