using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace Coldsteel.DeveloperTools
{
    internal class ColdsteelDeveloperToolsGameComponent : DrawableGameComponent
    {
        private DevToolsWindow _devToolsWindow;

        private ColdsteelGameComponent _coldsteel;

        private KeyboardState _currentKeyboardState;

        private KeyboardState _previousKeyboardState = new KeyboardState();

        public ColdsteelDeveloperToolsGameComponent(ColdsteelGameComponent coldsteel)
            : base(coldsteel.Game)
        {
            _coldsteel = coldsteel;
            _devToolsWindow = new DevToolsWindow(_coldsteel);
        }

        public override void Initialize()
        {
            base.Initialize();
            var gameWindow = (Form)Form.FromHandle(Game.Window.Handle);
            gameWindow.FormClosed += GameWindow_FormClosed;
        }

        private void GameWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            _devToolsWindow.HideOnClose = false;
            _devToolsWindow.Close();
            System.Windows.Forms.Application.Exit();
        }

        public override void Update(GameTime gameTime)
        {
            _previousKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Keyboard.GetState();
            if (_currentKeyboardState.IsKeyDown(Keys.F12) &&
                _previousKeyboardState.IsKeyUp(Keys.F12))
            {
                if (_devToolsWindow.IsVisible)
                    _devToolsWindow.Hide();
                else
                    _devToolsWindow.Show();
            }
        }
    }
}
