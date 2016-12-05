using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.Studio.Core
{
    public class Project
    {
        private string _projectPath;

        public string Name => Path.GetFileName(_projectPath);

        public Project(string projectPath)
        {
            this._projectPath = projectPath;
        }

        public static Project Create(string directoryPath, string projectName)
        {
            var projectPath = Path.Combine(directoryPath, projectName);
            Directory.CreateDirectory(projectPath);
            return Open(projectPath);
        }

        public static Project Open(string projectPath)
        {
            var project = new Project(projectPath);
            project.Initialize();
            return project;
        }

        public void Run()
        {

        }

        private void Initialize()
        {
            Directory.CreateDirectory(Path.Combine(_projectPath, "bin"));
            Directory.CreateDirectory(Path.Combine(_projectPath, "bin", "Content"));
            Directory.CreateDirectory(Path.Combine(_projectPath, "content"));
            // TODO: make this configurable list
            CopyColdsteelFileToBin("Coldsteel.WindowsDX.exe");
            CopyColdsteelFileToBin("SharpDX.XInput.dll");
            CopyColdsteelFileToBin("Coldsteel.Composition.WindowsDX.dll");
            CopyColdsteelFileToBin("Coldsteel.Configuration.WindowsDX.dll");
            CopyColdsteelFileToBin("Coldsteel.Core.WindowsDX.dll");
            CopyColdsteelFileToBin("MonoGame.Framework.dll");
            CopyColdsteelFileToBin("SharpDX.Direct2D1.dll");
            CopyColdsteelFileToBin("SharpDX.Direct3D9.dll");
            CopyColdsteelFileToBin("SharpDX.Direct3D11.dll");
            CopyColdsteelFileToBin("SharpDX.dll");
            CopyColdsteelFileToBin("SharpDX.DXGI.dll");
            CopyColdsteelFileToBin("SharpDX.MediaFoundation.dll");
            CopyColdsteelFileToBin("SharpDX.RawInput.dll");
            CopyColdsteelFileToBin("SharpDX.XAudio2.dll");

            Directory.CreateDirectory(Path.Combine(_projectPath, "content"));
            CopyColdsteelFileToContent("gameLogo.png");

            var contentPipelineFile = Path.Combine(_projectPath, "content", "Content.mgcb");
            if (!File.Exists(contentPipelineFile))

                File.WriteAllText(contentPipelineFile, @"
#----------------------------- Global Properties ----------------------------#

/outputDir:..\bin\Content
/intermediateDir:obj
/platform:Windows
/config:
/profile:Reach
/compress:False

#-------------------------------- References --------------------------------#

/reference:..\bin\Coldsteel.Configuration.WindowsDX.dll

#---------------------------------- Content ---------------------------------#

#begin gameLogo.png
/importer:TextureImporter
/processor:TextureProcessor
/processorParam:ColorKeyColor=255,0,255,255
/processorParam:ColorKeyEnabled=True
/processorParam:GenerateMipmaps=False
/processorParam:PremultiplyAlpha=True
/processorParam:ResizeToPowerOfTwo=False
/processorParam:MakeSquare=False
/processorParam:TextureFormat=Color
/build:gameLogo.png

");
            Directory.CreateDirectory(Path.Combine(_projectPath, "code"));
        }

        private void CopyColdsteelFileToBin(string fileName)
        {
            File.Copy(Path.Combine(Directory.GetCurrentDirectory(), fileName),
                Path.Combine(_projectPath, "bin", fileName));
        }

        private void CopyColdsteelFileToContent(string fileName)
        {
            File.Copy(Path.Combine(Directory.GetCurrentDirectory(), fileName),
                Path.Combine(_projectPath, "content", fileName));
        }
    }
}
