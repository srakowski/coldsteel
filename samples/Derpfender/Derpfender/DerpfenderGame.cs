using System;
using Coldsteel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Coldsteel.Controls;
using Derpfender.Stages;

namespace Derpfender
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class DerpfenderGame : Game, IColdsteelInitializer
    {
        private GraphicsDeviceManager _graphics;
        public DerpfenderGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";
            Components.Add(new ColdsteelComponent(this, this));
        }

        public void InitializeControls(Input input)
        {
            input.AddControl(new KeyboardButtonControl("MoveUp", Keys.W));
            input.AddControl(new KeyboardButtonControl("MoveDown", Keys.S));
            input.AddControl(new KeyboardButtonControl("Fire", Keys.Space));
        }

        public void RegisterStages(GameStageCollection stages)
        {
            stages.RegisterStage<GameplayStage>();
        }
    }
}
