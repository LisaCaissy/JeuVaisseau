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
        protected int munitions;

        /// <summary>
        /// Constructeur.
        /// </summary>
        public Vaisseau(int vie, int munitions, Rectangle position) : base(position)
        {
            this.vie = vie;
            this.munitions = munitions;
            sprite = Content.Load<Texture2D>("vaisseau");           
           //this.position = position;
            position = sprite.Bounds;
            vitesse = new Vector2(10,10);
            Debug.WriteLine(position);
        }

        public void Deplacements()
        {

            //droite
            if (Keyboard.GetState().IsKeyDown(Keys.D) && position.X <= fenetre.Width - sprite.Width)
            {
                
                position.X += (int)vitesse.X;
            }
            //gauche
            if (Keyboard.GetState().IsKeyDown(Keys.A) && position.X >= 0)
            {
                position.X -= (int)vitesse.X;
            }
            //haut
            if (Keyboard.GetState().IsKeyDown(Keys.W) && position.Y >= 0)
            {
                position.Y -= (int)vitesse.Y;
            }
            //bas
            if (Keyboard.GetState().IsKeyDown(Keys.S) && position.Y <= fenetre.Height - sprite.Height)
            {
                position.Y += (int)vitesse.Y;
            }
        }

        public override void Actualiser()
        {
            Deplacements();
            //LimiterMouvements();
        }

        /// <summary>
        /// Limite les mouvements du vaisseau pour ne pas quitter l'écran.
        /// </summary>

        


    }
}
