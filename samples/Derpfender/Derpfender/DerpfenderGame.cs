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
            input.AddControl(new KeyboardButtonControl("MenuUp", Keys.W));
            input.AddControl(new GamePadButtonControl("AltMenuUp", GamePadButton.DPadUp));
            input.AddControl(new KeyboardButtonControl("MenuDown", Keys.S));
            input.AddControl(new GamePadButtonControl("AltMenuDown", GamePadButton.DPadDown));
            input.AddControl(new KeyboardButtonControl("MenuSelect", Keys.Space));
            input.AddControl(new GamePadButtonControl("AltMenuSelect", GamePadButton.A));

            input.AddControl(new KeyboardButtonControl("MoveUp", Keys.W));
            input.AddControl(new GamePadButtonControl("AltMoveUp", GamePadButton.DPadUp));
            input.AddControl(new KeyboardButtonControl("MoveDown", Keys.S));
            input.AddControl(new GamePadButtonControl("AltMoveDown", GamePadButton.DPadDown));
            input.AddControl(new KeyboardButtonControl("Fire", Keys.Space));
            input.AddControl(new GamePadButtonControl("AltFire", GamePadButton.A));
        }

        public void RegisterStages(GameStageCollection stages)
        {
            stages.RegisterStage<MainMenuStage>();
            stages.RegisterStage<GameplayStage>();            
        }
    }
}
