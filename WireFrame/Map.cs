using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;

namespace WireFrame
{
    public class Map
    {
        public Coordinate[,] Grid { get; set; }
        public Vector2 Ofset { get; set; }
        public int Scale { get; set; }

        private bool change = false;

        public Map(int x = 5, int y = 5, float xOfset = 400, float yOfset = 200, int scale = 20)
        {
            Ofset = new Vector2(xOfset, xOfset);
            Scale = scale;
            GenerateGrid(x, y);
            foreach(var point in Grid)
            {
                point.ProjectIso(Ofset, scale);
            }
        }

        public void Update()
        {
            if (change)
            {
                foreach(var point in Grid)
                {
                    point.ProjectIso(Ofset, Scale);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            float tx = 0;
            float ty = 0;
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {

                    if (j != 0)
                    {
                        spriteBatch.DrawLine(tx, ty, Grid[i, j].Projected.X, Grid[i, j].Projected.Y, Color.White);
                    }
                    tx = Grid[i, j].Projected.X;
                    ty = Grid[i, j].Projected.Y;
                }
                tx = 0;
            }

            tx = 0;
            ty = 0;

            for (int j = 0; j < Grid.GetLength(0); j++)
            {
                for (int i = 0; i < Grid.GetLength(1); i++)
                {

                    if (i != 0)
                    {
                        spriteBatch.DrawLine(tx, ty, Grid[i, j].Projected.X, Grid[i, j].Projected.Y, Color.Purple);
                    }
                    tx = Grid[i, j].Projected.X;
                    ty = Grid[i, j].Projected.Y;
                }
                tx = 0;
            }
        }

        public void Left()
        {
            var tmp = Ofset;
            tmp.X -= 10;
            Ofset = tmp;
            change = true;
        }

        public void Right()
        {
            var tmp = Ofset;
            tmp.X += 10;
            Ofset = tmp;
            change = true;
        }

        public void Up()
        {
            var tmp = Ofset;
            tmp.Y += 10;
            Ofset = tmp;
            change = true;
        }

        public void Down()
        {
            var tmp = Ofset;
            tmp.Y -= 10;
            Ofset = tmp;
            change = true;
        }

        private void GenerateGrid(int x, int y)
        {
            Grid = new Coordinate[x, y];
            Random rand = new Random();

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    float z = rand.Next(0, 100) / 100f;
                    Grid[i, j] = new Coordinate(i, j, z);
                    Console.Write(z + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
