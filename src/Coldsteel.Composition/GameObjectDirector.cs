using Coldsteel.Core;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Composition
{
    internal class GameObjectDirector
    {
        private Configuration.GameObject _gameObjectConfig;

        private GameObjectBuilder _gameObjectBuilder;

        public GameObjectDirector(Configuration.GameObject gameObjectConfig, GameObjectBuilder gameObjectBuilder)
        {
            this._gameObjectConfig = gameObjectConfig;
            this._gameObjectBuilder = gameObjectBuilder;
        }

        public void Construct(Dictionary<string, object> objectDirectory,
            List<Action<Dictionary<string, object>>> compositionTasks)
        {
            _gameObjectBuilder.Begin(_gameObjectConfig.Name);

            foreach (var componentConfig in _gameObjectConfig.Components)
            {
                if (componentConfig is Configuration.Components.Transform)
                {
                    var transformConfig = componentConfig as Configuration.Components.Transform;
                    var transform = new Core.Components.Transform();
                    if (transformConfig.Parent != null)
                    {
                        compositionTasks.Add((od) =>
                        {
                            var parent = od[transformConfig.Parent.Id] as Core.Components.Transform;
                            transform.SetParent(parent);
                        });
                    }
                    transform.Position = transformConfig.Position;
                    transform.Rotation = transformConfig.Rotation;
                    transform.Scale = transformConfig.Scale;
                    _gameObjectBuilder.AddComponent(transform);
                    objectDirectory[transformConfig.Id] = transform;
                }

                if (componentConfig is Configuration.Components.TextRenderer)
                {
                    var textRendererConfig = componentConfig as Configuration.Components.TextRenderer;
                    var textRenderer = new Core.Components.TextRenderer();
                    compositionTasks.Add((od) =>
                    {
                        var spriteFont = od[textRendererConfig.SpriteFont.Id];
                        textRenderer.SpriteFont = spriteFont as SpriteFont;
                    });
                    textRenderer.Text = textRendererConfig.Text;
                    _gameObjectBuilder.AddComponent(textRenderer);
                    objectDirectory[componentConfig.Id] = textRenderer;
                }

                if (componentConfig is Configuration.Components.SpriteRenderer)
                {
                    var config = componentConfig as Configuration.Components.SpriteRenderer;
                    var component = new Core.Components.SpriteRenderer();
                    compositionTasks.Add((od) =>
                    {
                        var importObject = od[config.Texture2D.Id];
                        component.Texture2D = importObject as Texture2D;
                    });
                    _gameObjectBuilder.AddComponent(component);
                    objectDirectory[componentConfig.Id] = component;
                }


            }
            _gameObjectBuilder.End();
        }
    }
}
