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
        public GameStage ActiveGameStage { get; private set; }

        private IGameResourceFactory _resourceFactory;

        private Input _input;

        /// <summary>
        /// Gets the Registry where GameStages are configured.
        /// </summary>
        public GameStageRegistry GameStageRegistry { get; private set; }

        internal bool FirstUpdate { get; set; } = false;

        /// <summary>
        /// Construct a new GameStageManager
        /// </summary>
        /// <param name="input"></param>
        /// <param name="stages"></param>
        public GameStageManager(Input input, GameStageRegistry stages)
        {
            _input = input;
            GameStageRegistry = stages;
        }

        /// <summary>
        /// Invoke when the initial Stage should be loaded.
        /// </summary>
        public void Initialize(IGameResourceFactory resourceFactory)
        {
            _resourceFactory = resourceFactory;
            LoadStage(resourceFactory, GameStageRegistry.Default);
        }

        /// <summary>
        /// Update portions of the game loop done here.
        /// </summary>
        /// <param name="gameTime"></param>
        internal void Update(IGameTime gameTime)
        {
            if (FirstUpdate)
                FirstUpdate = false;

            _input.Update(gameTime);
            ActiveGameStage.Input = _input;
            ActiveGameStage.Update(gameTime);
        }

        /// <summary>
        /// Render portions of the game loop here.
        /// </summary>
        /// <param name="gameTime"></param>
        internal void Render(IGameTime gameTime)
        {
            ActiveGameStage?.Render(gameTime);
        }

        /// <summary>
        /// Swaps the CurrentGameStage for the one provided.
        /// </summary>
        /// <param name="name"></param>
        public void LoadStage(string name, object param = null)
        {
            this.LoadStage(_resourceFactory, GameStageRegistry[name], param);
        }

        /// <summary>
        /// Actually performs the stage loading.
        /// </summary>
        /// <param name="resourceFactory"></param>
        /// <param name="stageType"></param>
        private void LoadStage(IGameResourceFactory resourceFactory, Type stageType, object param = null)
        {
            if (this.ActiveGameStage != null)
            {
                this.ActiveGameStage.Exit(() =>
                {
                    this.ActiveGameStage = Activator.CreateInstance(stageType) as GameStage;
                    this.ActiveGameStage.GameStageManager = this;
                    this.ActiveGameStage.GameResourceFactory = resourceFactory;
                    this.ActiveGameStage.Load(param);
                    FirstUpdate = true;
                });
            }
            else
            {
                this.ActiveGameStage = Activator.CreateInstance(stageType) as GameStage;
                this.ActiveGameStage.GameStageManager = this;
                this.ActiveGameStage.GameResourceFactory = resourceFactory;
                this.ActiveGameStage.Load(param);
                FirstUpdate = true;
            }
        }
    }
}
