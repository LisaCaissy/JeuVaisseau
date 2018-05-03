using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace JeuVaisseau
{
    /// <summary>
    /// Caractéristiques du vaisseau.
    /// </summary>
    public class Vaisseau : GameObject
    {

        protected int vie;
        protected Munitions[] munitions;

        public int Vie
        {
            get
            { 
                return vie;
            }
            set
            {
                vie = value;
            }
        }

        /// <summary>
        /// Constructeur.
        /// </summary>
        public Vaisseau(int vie, Rectangle position, int nombre) : base(position)
        {
            this.vie = vie;
            sprite = Content.Load<Texture2D>("vaisseau");           
            position = sprite.Bounds;
            vitesse = new Vector2(10,10);
            munitions = new Munitions[nombre];
            for (int i = 0; i < munitions.Length; i++)
            {
                munitions[i] = new Munitions(position);
            }

        }

        public void Deplacements()
        {

            //droite
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && position.X <= fenetre.Width - sprite.Width)
            {
                
                position.X += (int)vitesse.X;
            }
            //gauche
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && position.X >= 0)
            {
                position.X -= (int)vitesse.X;
            }
            //haut
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && position.Y >= 0)
            {
                position.Y -= (int)vitesse.Y;
            }
            //bas
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && position.Y <= fenetre.Height - sprite.Height)
            {
                position.Y += (int)vitesse.Y;
            }
        }

        public override void Actualiser()
        {
            Deplacements();

            for (int i = 0; i < munitions.Length; i++)
            {
                munitions[i].Actualiser();
            }  
        }
    }
}
