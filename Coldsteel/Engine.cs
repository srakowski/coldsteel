using Microsoft.Xna.Framework;

namespace Coldsteel
{
    public class Engine : GameComponent
    {
        public Engine(Game game, ISceneFactory sceneFactory) : base(game)
        {
            SceneManager = new SceneManager(game, this, sceneFactory);
            SpriteSystem = new SpriteSystem(game, this);
        }

        internal SceneManager SceneManager;

        internal SpriteSystem SpriteSystem;

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
