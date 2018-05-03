using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JeuVaisseau
{
    /// <summary>
    /// Caractéristiques d'un projectile.
    /// </summary>
    public class Projectile : GameObject
    {
        protected Rectangle rectangleProjectile;

        /// <summary>
        /// Constructeur.
        /// </summary>
        public Projectile(Rectangle position) : base(position)
        {
            this.position = position;
            estVisible = true;
            sprite = Content.Load<Texture2D>("asteroids");
            vitesse = new Vector2(1, 30);
        }

        public void Deplacements()
        {

            position.Y += (int)vitesse.Y;

        }

        public override void Actualiser()
        {
            Deplacements();
        }
    }
}
