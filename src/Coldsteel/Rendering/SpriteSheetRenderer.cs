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

        public int Frame { get; set; } = 0;

        public SpriteSheetRenderer(SpriteSheet spriteSheet)
            : base(spriteSheet.Image)
        {
            _spriteSheet = spriteSheet;
            this.Origin = spriteSheet.Origin;
            this.SourceRectangle = spriteSheet[0];
        }

        public override void Update()
        {
            this.SourceRectangle = _spriteSheet[this.Frame];
        }
    }
}
