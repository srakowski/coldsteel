using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Coldsteel
{
    /// <summary>
    /// Responsible for Loading and Swapping GameStage objects
    /// </summary>
    public class GameStageManager
    {
        /// <summary>
        /// Gets the GameStage currently loaded (i.e. what the user is seeing).
        /// </summary>
        public GameStage CurrentGameStage { get; private set; }

        private Input _input;

        private GameStageCollection _stages;

        public GameStageManager(Input input, GameStageCollection stages)
        {
            _input = input;
            _stages = stages;
        }

        /// <summary>
        /// Invoke when the initial Stage should be loaded.
        /// </summary>
        public void Initialize()
        {
            this.CurrentGameStage = Activator.CreateInstance(_stages.Default) as GameStage;
            this.CurrentGameStage.GameStageManager = this;
            this.CurrentGameStage.LoadContent();
            this.CurrentGameStage.Initialize();
        }

        /// <summary>
        /// Update portions of the game loop done here.
        /// </summary>
        /// <param name="gameTime"></param>
        internal void Update(IGameTime gameTime)
        {
            _input.Update(gameTime);
            CurrentGameStage?.HandleInput(gameTime, _input);
            CurrentGameStage?.Update(gameTime);
        }

        /// <summary>
        /// Render portions of the game loop here.
        /// </summary>
        /// <param name="gameTime"></param>
        internal void Render(IGameTime gameTime)
        {
            CurrentGameStage?.Render(gameTime);
        }
    }
}
