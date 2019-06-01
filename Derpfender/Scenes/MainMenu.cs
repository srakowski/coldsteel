// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel;
using System;
//using System.Xml.Linq;

namespace Derpfender.Scenes
{
    static class MainMenu
    {
        public static Scene Create()
        {
            var scene = Scene.New();

            scene.AddEntity(
                Entity.New()
                    .AddComponent(UIHost.New(RootElement()))
            );

            return scene;
        }

        private static Element RootElement()
        {
            var el = Element.New("app");

            el.Template = @"
                <el>
                    <el>Derpfender</el>
                    <el on:click='OnClickPlay'>Play</el>
                    <el on:click='OnClickExit'>Exit</el>
                </el>
            ";

            //var o = XElement.Parse(el.Template);
            //foreach (var e in o.Elements())
            //    Debug.WriteLine(e);

            el.Handlers = new
            {
                OnClickPlay = new Action<ElementEvent>((ElementEvent e) =>
                {
                    Console.WriteLine("Play");
                }),
                OnClickExit = new Action<ElementEvent>((ElementEvent e) =>
                {
                    Console.WriteLine("Exit");
                }),
            };

            return el;
        }
    }
}
