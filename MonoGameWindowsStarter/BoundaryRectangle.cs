using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MonoGameWindowsStarter
{
    public struct BoundaryRectangle
    {
        public float X { get; set; }

        public float Y { get; set; }

        public float Height;

        public float Width;

        public BoundaryRectangle(float x, float y, float width, float height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public bool CollidesWith(BoundaryRectangle other)
        {
            return !(this.X > other.X + other.Width
                || this.X + this.Width < other.X
                || this.Y > other.Y + other.Height
                || this.Y + this.Height < other.Y);
        }

        //public bool IsOnTop(BoundaryRectangle other)
        //{
        //    return (this.Y + this.Height > other.Y + other.Height && this.X >);
        //}

    }
}
