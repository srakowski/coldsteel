using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class ColdsteelComponent : DrawableGameComponent
    {
        private IColdsteelInitializer _initializer;

        private Input _input;

        /// <summary>
        /// Construct a new ColdsteelComponent with the provided game and IColdsteelInitializer.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="initializer"></param>
        public ColdsteelComponent(Game game, IColdsteelInitializer initializer) 
            : base(game)
        {
            _initializer = initializer;
            _input = new Input();
        }

        /// <summary>
        /// Should be invoked by MonoGame during its intialization/gameloop.
        /// </summary>
        public override void Initialize()
        {
            _initializer.InitializeControls(_input);
            _initializer.RegisterStages(new GameStageCollection());
            base.Initialize();
        }

        /// <summary>
        /// Should be invoked by MonoGame during its intialization/gameloop.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
        }

        /// <summary>
        /// Should be invoked by MonoGame during its intialization/gameloop.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
        }
    }
}
