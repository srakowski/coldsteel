using Coldsteel;
using Derpfender.Scenes;
//using Derpfender.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Derpfender
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class DerpfenderGame : Game
    {
        GraphicsDeviceManager _graphics;

        public DerpfenderGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            var coldsteel = new ColdsteelGameComponent(this);
            Components.Add(coldsteel);
            coldsteel.Start<MainMenuScene>();
        }
    }
}
