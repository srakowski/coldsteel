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
            input.AddControl("MenuUp", new KeyboardButtonControl(Keys.W));
            input.AddControl("AltMenuUp", new GamePadButtonControl(GamePadButton.DPadUp));
            input.AddControl("MenuDown", new KeyboardButtonControl(Keys.S));
            input.AddControl("AltMenuDown", new GamePadButtonControl(GamePadButton.DPadDown));
            input.AddControl("MenuSelect", new KeyboardButtonControl(Keys.Space));
            input.AddControl("AltMenuSelect", new GamePadButtonControl(GamePadButton.A));

            input.AddControl("MoveUp", new KeyboardButtonControl(Keys.W));
            input.AddControl("AltMoveUp", new GamePadButtonControl(GamePadButton.DPadUp));
            input.AddControl("MoveDown", new KeyboardButtonControl(Keys.S));
            input.AddControl("AltMoveDown", new GamePadButtonControl(GamePadButton.DPadDown));
            input.AddControl("Fire", new KeyboardButtonControl(Keys.Space));
            input.AddControl("AltFire", new GamePadButtonControl(GamePadButton.A));
        }

        public void RegisterStages(GameStageRegistry registry)
        {
            registry.RegisterStage<MainMenuStage>();
            registry.RegisterStage<GameplayStage>();            
        }
    }
}
