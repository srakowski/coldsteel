using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

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

        private IGameResourceFactory _resourceFactory;

        private Input _input;

        private GameStageCollection _stages;

        /// <summary>
        /// Construct a new GameStageManager
        /// </summary>
        /// <param name="input"></param>
        /// <param name="stages"></param>
        public GameStageManager(Input input, GameStageCollection stages)
        {
            _input = input;
            _stages = stages;
        }

        /// <summary>
        /// Invoke when the initial Stage should be loaded.
        /// </summary>
        public void Initialize(IGameResourceFactory resourceFactory)
        {
            _resourceFactory = resourceFactory;
            LoadStage(resourceFactory, _stages.Default);
        }

        /// <summary>
        /// Update portions of the game loop done here.
        /// </summary>
        /// <param name="gameTime"></param>
        internal void Update(IGameTime gameTime)
        {
            _input.Update(gameTime);
            CurrentGameStage.Input = _input;
            CurrentGameStage.Update(gameTime);
        }

        /// <summary>
        /// Render portions of the game loop here.
        /// </summary>
        /// <param name="gameTime"></param>
        internal void Render(IGameTime gameTime)
        {
            CurrentGameStage?.Render(gameTime);
        }

        /// <summary>
        /// Swaps the CurrentGameStage for the one provided.
        /// </summary>
        /// <param name="name"></param>
        public void LoadStage(string name)
        {
            this.LoadStage(_resourceFactory, _stages[name]);
        }

        /// <summary>
        /// Actually performs the stage loading.
        /// </summary>
        /// <param name="resourceFactory"></param>
        /// <param name="stageType"></param>
        private void LoadStage(IGameResourceFactory resourceFactory, Type stageType)
        {
            this.CurrentGameStage?.Unload();
            this.CurrentGameStage = Activator.CreateInstance(stageType) as GameStage;
            this.CurrentGameStage.GameStageManager = this;
            this.CurrentGameStage.GameResourceFactory = resourceFactory;
            this.CurrentGameStage.Load();            
        }
    }
}
