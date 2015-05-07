using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shooter
{
    class Chodzacy : Istota
    {
        public bool Aktywny;
        public bool isRage;
        public Texture2D Rage;
        public Texture2D HP3;
        public Texture2D HP2;
        public Texture2D HP1;


        public Chodzacy(Texture2D Textura, Texture2D rage, Texture2D hp3, Texture2D hp2, Texture2D hp1, Vector2 pozycja, Vector2 predkosc, bool aktywny)
            :base(Textura, pozycja, predkosc)
        {
            this.HP = 3;
            this.Aktywny = aktywny;
            this.isRage = false;
            this.Rage = rage;
            this.HP1 = hp1;
            this.HP2 = hp2;
            this.HP3 = hp3;
        }

        public override void Ruch()
        {
            var predkosc = this.Predkosc;
            if (Pozycja.Y != podporaY)
                predkosc.Y++;

            this.Predkosc = predkosc;
            base.Ruch();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(!isRage)
                spriteBatch.Draw(this.textura, this.Pozycja, new Rectangle(0, 0, this.textura.Width, this.textura.Height), Color.White);
            else
                spriteBatch.Draw(this.Rage, this.Pozycja, new Rectangle(0, 0, this.Rage.Width, this.Rage.Height), Color.White);
            
            if(HP==3)
                spriteBatch.Draw(this.HP3, new Vector2(this.Pozycja.X, this.Pozycja.Y - 2 * this.HP3.Height), new Rectangle(0, 0, this.textura.Width, this.HP3.Height), Color.White);
            else if (HP == 2)
                spriteBatch.Draw(this.HP2, new Vector2(this.Pozycja.X, this.Pozycja.Y - 2 * this.HP2.Height), new Rectangle(0, 0, this.textura.Width, this.HP2.Height), Color.White);
            else
                spriteBatch.Draw(this.HP1, new Vector2(this.Pozycja.X, this.Pozycja.Y - 2 * this.HP1.Height), new Rectangle(0, 0, this.textura.Width, this.HP1.Height), Color.White);
        }       
    }
}
