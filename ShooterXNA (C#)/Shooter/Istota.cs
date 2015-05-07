using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shooter
{
    abstract class Istota : ObjektRuch
    {
        public float podporaY;
        public int HP;
        public string Zwrot;

        public Istota(Texture2D Textura, Vector2 pozycja, Vector2 predkosc)
            :base(Textura, pozycja, predkosc)
        {
            this.Zwrot = "";
        }

    }
}
