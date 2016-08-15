using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Coldsteel.Input;

namespace Coldsteel
{
    public class GameStateManager
    {
        private GameState _state;

        private InputManager _input;

        private ContentManager _content;

        public GameStateManager(InputManager input, ContentManager content)
        {
            this._input = input;
            this._content = content;
        }

        public void Start<T>() where T : GameState, new()
        {
            _state = Activator.CreateInstance(typeof(T)) as GameState;
        }

        public void Exit()
        {
        }

        internal void Update(GameTime gameTime)
        {
            _state.Update(gameTime);
        }

        internal void Draw(GameTime gameTime)
        {
            _state.Render(gameTime);
        }
    }
}
