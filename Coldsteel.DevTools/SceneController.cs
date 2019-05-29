// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.AspNetCore.Mvc;

namespace Coldsteel.DevTools
{
    [Route("api/[controller]")]
    [ApiController]
    public class SceneController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Scene> Get([FromServices] Engine engine)
        {
            var scene = engine?.SceneManager?.ActiveScene;
            if (scene == null) return NotFound();
            return Ok(scene);
        }
    }
}
