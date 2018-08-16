// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace Coldsteel.Rendering2D
{
    /// <summary>
    /// Responsible for rendering sprite components to the screen.
    /// </summary>
    internal class SpriteRenderingSystem : DrawableGameComponent
    {
        private static Dictionary<GameState, IEnumerable<Sprite>> _activeSpritesByGameState = new Dictionary<GameState, IEnumerable<Sprite>>();

        private SpriteBatch _spriteBatch;

        public SpriteRenderingSystem(Game game) : base(game) { }

        /// <summary>
        /// Initializes the SpriteRenderingSystem, at this point we'll create the SpriteBatch
        /// used to render the sprites.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);
        }

        /// <summary>
        /// Registers an active Sprite with this SpriteRenderingSystem. Registered sprites
        /// will be Drawn to the screen if the gameState they are registered with is active
        /// and they are active and visible.
        /// </summary>
        /// <param name="sprite"></param>
        internal static void RegisterSprite(GameState gameState, Sprite sprite)
        {
            if (!_activeSpritesByGameState.TryGetValue(gameState, out IEnumerable<Sprite> spritesThisGameState))
            {
                spritesThisGameState = Enumerable.Empty<Sprite>();
            }

            spritesThisGameState = spritesThisGameState.Append(sprite);

            _activeSpritesByGameState[gameState] = spritesThisGameState;
        }

        /// <summary>
        /// Removes this sprite so it may no longer be rendered.
        /// </summary>
        /// <param name="gameState"></param>
        /// <param name="sprite"></param>
        internal static void DeregisterSprite(GameState gameState, Sprite sprite)
        {
            if (!_activeSpritesByGameState.TryGetValue(gameState, out IEnumerable<Sprite> spritesThisGameState))
            {
                return;
            }

            spritesThisGameState = spritesThisGameState.Exclude(sprite);

            if (!spritesThisGameState.Any())
            {
                _activeSpritesByGameState.Remove(gameState);
            }
            else
            {
                _activeSpritesByGameState[gameState] = spritesThisGameState;
            }
        }
    }
}
