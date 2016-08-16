using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Coldsteel.Input;

namespace Coldsteel
{
    public class GameStateManager
    {
        private GameState _state;

        private GameState _pendingState;

        private InputManager _input;

        private ContentManager _content;

        private GameStage _stage;

        public GameStateManager(InputManager input, 
            ContentManager content, GameStage stage)
        {
            this._input = input;
            this._content = content;
            this._stage = stage;
        }

        internal void Initialize(GraphicsDevice graphicsDevice)
        {
            _stage.Initialize(graphicsDevice);
            SwapState();
        }

        public void Start<T>() where T : GameState, new()
        {
            _pendingState = Activator.CreateInstance(typeof(T)) as GameState;
        }

        public void Exit()
        {
        }

        internal void Update(GameTime gameTime)
        {
            InputDevices.Update();
            _state?.Update(gameTime);
            SwapState();
        }

        private void SwapState()
        {
            if (_pendingState == null)
                return;

            _content.Reset();
            _pendingState.State = this;
            _pendingState.Input = this._input;
            _pendingState.Load = this._content;
            _pendingState.Stage = this._stage;            
            _pendingState.Layers = new LayerManager();
            _pendingState.World = new World(_pendingState);
            _pendingState.Preload();
            _state = _pendingState;
            _pendingState = null;
            _state.Create();
        }

        internal void Draw(GameTime gameTime)
        {
            _state?.Render(gameTime);
        }
    }
}
