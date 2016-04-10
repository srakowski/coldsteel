using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public interface IContentManager
    {
        T Load<T>(string path) where T : class;
    }
}
