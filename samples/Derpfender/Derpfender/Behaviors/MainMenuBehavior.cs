using Derpfender.Models;
using Derpfender.Scenes;
using Microsoft.Xna.Framework;

namespace Derpfender.Behaviors
{
    public class MainMenuBehavior : MenuBehavior
    {
        public MainMenuBehavior()
        {
            base.AddMenuOption(new MenuOption(new Vector2(15, 53), Play));
            base.AddMenuOption(new MenuOption(new Vector2(15, 93), Exit));
        }

        private void Play()
        {
            SceneManager.Start(nameof(GameplayScene));
        }

        private void Exit()
        {
        }
    }
}
