using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace JeuVaisseau
{
    /// <summary>
    /// Caractéristiques d'un GameObject.
    /// </summary>
    public abstract class GameObject
    {

        protected Rectangle position;
        protected Vector2 vitesse;
        protected bool estVisible;
        protected Texture2D sprite;
        protected Random random;
        protected static Rectangle fenetre;
        protected static SpriteBatch spritebatch;
        protected static ContentManager content;

        public static ContentManager Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }

        public static Rectangle Fenetre
        {
            get
            {
                return fenetre;
            }
            set
            {
                fenetre = value;
            }
        }

        public static SpriteBatch Spritebatch
        {
            get
            {
                return spritebatch;
            }
            set
            {
                spritebatch = value;
            }
        }
        /// <summary>
        /// Propriété Position.
        /// </summary>
        public Rectangle Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        /// <summary>
        /// Propriété Sprite.
        /// </summary>
        public Texture2D Sprite
        {
            get
            {
                return sprite;
            }
            set
            {
                sprite = value;
            }
        }

        public bool EstVisible
        {
            get
            {
                return estVisible;
            }
            set
            {
                estVisible = value;
            }
        }

        /// <summary>
        /// Constructeur.
        /// </summary>
        public GameObject(Rectangle position)
        {
            this.position = position;
        }

        /// <summary>
        /// Actualise les GameObjects.
        /// </summary>
        public abstract void Actualiser();

        public bool DetecterCollision(GameObject element)
        {
            bool collision = false;

            if (Position.Intersects(element.Position))
            {
                collision = true;          
            }
            return collision;
        }

        /// <summary>
        /// Dessine les GameObjects.
        /// </summary>
        public void Dessiner()
        {
            spritebatch.Draw(sprite, position, Color.White);

        }


    }
}
