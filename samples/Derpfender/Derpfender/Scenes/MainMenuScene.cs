using Coldsteel.Composition;
using Coldsteel;
using Coldsteel.Fluent;
using Coldsteel.Components;
using Derpfender.Behaviors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Derpfender.Scenes
{
    public class MainMenuScene : SpaceSceneBase
    {
        private const string MenuFontAssetName = "fonts/menu";

        public override Color BackgroundColor => Color.Black;

        public GameObject MainMenu { get; } = new GameObject()
            .SetName("mainMenu")
            .SetPosition(200, 200)
            .Add(new TextRenderer(MenuFontAssetName, "Derpfender"));

        public GameObject PlayOption { get; } = new GameObject()
            .SetPosition(40, 40)
            .Add(new TextRenderer(MenuFontAssetName, "Play"));

        public GameObject ExitOption { get; } = new GameObject()
            .SetPosition(40, 80)
            .Add(new TextRenderer(MenuFontAssetName, "Exit"));

        public GameObject ShipSelector { get; } = new GameObject()
            .SetRotationInDegrees(90)
            .Add(new SpriteRenderer("sprites/ship"))
            .Add(new MainMenuBehavior());

        protected override void Compose()
        {
            PlayOption.SetParent(MainMenu);
            ExitOption.SetParent(MainMenu);
            ShipSelector.SetParent(MainMenu);
        }
    }
}
