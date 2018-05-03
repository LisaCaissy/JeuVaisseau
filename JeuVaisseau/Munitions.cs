using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JeuVaisseau
{
    public class Munitions : GameObject
    {

        public Munitions( Rectangle position): base(position)
        {
            estVisible = false;
            vitesse.Y = 70;
            this.position.X = position.X;
            this.position.Y = position.Y;
            sprite = Content.Load<Texture2D>("laser");

        }

        public void Tirer()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                position.Y -= (int)vitesse.Y;
            }
            
        }

        public override void Actualiser()
        {
            Tirer();
        }

    }
}
