using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    /// <summary>
    /// Responsible for Loading and Swapping GameStage objects
    /// </summary>
    public class GameStageManager
    {
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
            this.CurrentGameStage.LoadContent();
            this.CurrentGameStage.Initialize();
        }
    }
}
