using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Coldsteel
{
    public abstract class Behavior : GameObjectComponent
    {
        public virtual void Update() { }

        public void StartCoroutine(IEnumerator coroutine)
        {
        }
    }
}
