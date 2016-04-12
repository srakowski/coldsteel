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
        public SpriteSortMode SpriteSortMode { get; set; } = SpriteSortMode.Deferred;

        public BlendState BlendState { get; set; } = null;

        public SamplerState SamplerState { get; set; } = null;

        private SpriteBatch _spriteBatch;

        /// <summary>
        /// Create a Layer with the provided SpriteBatch.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public Layer(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }

        /// <summary>
        /// Begins the rendering of a layer.
        /// </summary>
        public void Begin()
        {
            _spriteBatch.Begin(SpriteSortMode, BlendState, SamplerState);
        }

        /// <summary>
        /// Renders a Texture at the provided position with the given color.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        /// <param name="color"></param>
        public void Render(
            Texture2D texture, 
            Vector2 position,
            Rectangle? destinationRectangle,
            Color color,
            float rotation,            
            Vector2 origin,
            float scale,
            SpriteEffects spriteEffects,
            float layerDepth)
        {
            _spriteBatch.Draw(texture, 
                position, 
                destinationRectangle, 
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
