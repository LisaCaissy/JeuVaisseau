using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JeuVaisseau
{
    public class Background : GameObject
    {
        public Background(Rectangle position) : base(position)
        {
            this.position = position;
            sprite = Content.Load<Texture2D>("background");
            vitesse = new Vector2(5, 5);
        }

        public void Deplacements()
        {
            

        }

        public override void Actualiser()
        {
            Deplacements();
        }
    }
}
