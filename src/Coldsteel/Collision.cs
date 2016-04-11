using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class Collision
    {
        public GameObject GameObject { get; set; }

        public Collision(GameObject gameObject)
        {
            GameObject = gameObject;
        }        
    }
}
