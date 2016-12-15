using Coldsteel;
using Coldsteel.Fluent;
using Derpfender.Behaviors;
using Microsoft.Xna.Framework;
using Coldsteel.Rendering;
using Coldsteel.Composition;

namespace Derpfender.Scenes
{
    [StartupScene]
    public class MainMenuScene : SpaceSceneBase
    {
        private const string MenuFontAssetName = "fonts/menu";

        public override Color BackgroundColor => Color.Black;

        public GameObject MainMenu { get; } = new GameObject()
            .SetName("mainMenu")
            .SetPosition(200, 200)
            .Add(new TextRenderer(MenuFontAssetName, "Derpfender"));

        public GameObject[] Options { get; private set; }

        private GameObject PlayOption { get; } = new GameObject()
            .SetPosition(40, 40)
            .Add(new TextRenderer(MenuFontAssetName, "Play"));

        private GameObject ExitOption { get; } = new GameObject()
            .SetPosition(40, 80)
            .Add(new TextRenderer(MenuFontAssetName, "Exit"));

        public GameObject ShipSelector { get; } = new GameObject()
            .SetRotationInDegrees(90)
            .Add(new SpriteRenderer("sprites/ship"))
            .Add(new MainMenuBehavior());

        protected override void Compose()
        {
            Options = new[]
            {
                PlayOption,
                ExitOption
            };

            PlayOption.SetParent(MainMenu);
            ExitOption.SetParent(MainMenu);
            ShipSelector.SetParent(MainMenu);
        }
    }
}
