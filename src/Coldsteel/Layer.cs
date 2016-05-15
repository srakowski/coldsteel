using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    /// <summary>
    /// Represents a layer where things are rendered. Anything belonging to layer should be rendered in that layer.
    /// </summary>
    public class Layer
    {
        public string Name { get; private set; }

        public SpriteSortMode SpriteSortMode { get; set; } = SpriteSortMode.Deferred;

        public BlendState BlendState { get; set; } = null;

        public SamplerState SamplerState { get; set; } = null;

        internal Matrix TransformMatrix { get; set; } = Matrix.Identity;       

        internal Rectangle Bounds { get; set; }

        private SpriteBatch _spriteBatch;

        /// <summary>
        /// Create a Layer with the provided SpriteBatch.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public Layer(string name, SpriteBatch spriteBatch)
        {
            Name = name;
            _spriteBatch = spriteBatch;
        }

        /// <summary>
        /// Begins the rendering of a layer.
        /// </summary>
        public void Begin()
        {
            _spriteBatch.Begin(SpriteSortMode, BlendState, SamplerState, null, null, null, TransformMatrix);
        }

        /// <summary>
        /// Renders a Texture with the provided attributes
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        /// <param name="sourceRectangle"></param>
        /// <param name="color"></param>
        /// <param name="rotation"></param>
        /// <param name="origin"></param>
        /// <param name="scale"></param>
        /// <param name="spriteEffects"></param>
        /// <param name="layerDepth"></param>
        public void Render(
            Texture2D texture, 
            Vector2 position,
            Rectangle? sourceRectangle,
            Color color,
            float rotation,            
            Vector2 origin,
            float scale,
            SpriteEffects spriteEffects,
            float layerDepth)
        {
            _spriteBatch.Draw(texture, 
                position, 
                sourceRectangle, 
                color, 
                rotation, 
                origin, 
                scale, 
                spriteEffects,
                layerDepth);
        }

        /// <summary>
        /// Renders the text with the provided attributes
        /// </summary>
        /// <param name="spriteFont"></param>
        /// <param name="text"></param>
        /// <param name="position"></param>
        /// <param name="color"></param>
        /// <param name="rotation"></param>
        /// <param name="origin"></param>
        /// <param name="scale"></param>
        /// <param name="spriteEffects"></param>
        /// <param name="layerDepth"></param>
        public void RenderText(
            SpriteFont spriteFont,
            string text,
            Vector2 position,
            Color color,
            float rotation,
            Vector2 origin,
            float scale,
            SpriteEffects spriteEffects,
            float layerDepth)
        {
            _spriteBatch.DrawString(
                spriteFont,
                text,
                position,
                color,
                rotation,
                origin,
                scale,
                spriteEffects,
                layerDepth);
        }

        /// <summary>
        /// Actually renders the layer.
        /// </summary>
        public void End()
        {
            _spriteBatch.End();
        }
    }
}
