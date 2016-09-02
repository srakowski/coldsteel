using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Coldsteel.Rendering
{
    public class SpriteSheetRenderer : SpriteRenderer
    {
        private SpriteSheet _spriteSheet;

        public AnimationManager Animations { get; private set; }

        public SpriteSheetRenderer(SpriteSheet spriteSheet)
            : base(spriteSheet.Image)
        {
            _spriteSheet = spriteSheet;
            this.Origin = spriteSheet.Origin;
            this.SourceRectangle = spriteSheet[0];
            this.Animations = new AnimationManager();
        }

        public override void Update()
        {
            this.Animations.Update(GameTime);
            this.SourceRectangle = _spriteSheet[this.Animations.CurrentFrame];
        }
    }
}
