// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel;
using Derpfender.Behaviors;
using Microsoft.Xna.Framework;
using Coldsteel.Rendering;

namespace Derpfender.Scenes
{
    public class MainMenu
    {
        private const string MenuFontAssetName = "fonts/menu";

        private Entity Title { get; } = new Entity()
            .SetName("mainMenu")
            .SetPosition(200, 200)
            .AddComponent(new TextRenderer(MenuFontAssetName, "Derpfender"));

        private Entity PlayOption { get; } = new Entity()
            .SetPosition(40, 40)
            .AddComponent(new TextRenderer(MenuFontAssetName, "Play"));

        private Entity ExitOption { get; } = new Entity()
            .SetPosition(40, 80)
            .AddComponent(new TextRenderer(MenuFontAssetName, "Exit"));

        public Entity ShipSelector { get; } = new Entity()
            .SetRotationInDegrees(90)
            .AddComponent(new SpriteRenderer("sprites/ship"))
            .AddComponent(new MainMenuBehavior());

        public static Scene Scene()
        {
            var menu = new MainMenu();
            menu.PlayOption.SetParent(menu.Title);
            menu.ExitOption.SetParent(menu.Title);
            menu.ShipSelector.SetParent(menu.Title);

            return new Scene()
            {
                BackgroundColor = Color.Black
            }
            .AddElement(menu.Title)
            .AddElement(menu.PlayOption)
            .AddElement(menu.ExitOption)
            .AddElement(menu.ShipSelector);
        }
    }
}
