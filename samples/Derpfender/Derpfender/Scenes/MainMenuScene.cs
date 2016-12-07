using Coldsteel.Composition;
using Coldsteel;
using Coldsteel.Fluent;
using Coldsteel.Components;
using Derpfender.Behaviors;

namespace Derpfender.Scenes
{
    public class MainMenuScene : ReflectiveSceneBuilder
    {
        private const string MenuFontAssetName = "fonts/menu";

        public Layer StarField = new Layer("starfield", -1);

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
            .Add(new MenuSelectBehavior());

        protected override void Compose()
        {
            PlayOption.SetParent(MainMenu);
            ExitOption.SetParent(MainMenu);
            ShipSelector.SetParent(MainMenu);
        }
    }
}
