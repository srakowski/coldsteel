using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private string ContentPipelineFilePath => Path.Combine(_projectPath, "content", "Content.mgcb");

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
            BuildContent();
            StartGame();
        }

        private void StartGame()
        {
            Process.Start(Path.Combine(_projectPath, "bin", "Coldsteel.exe"));
        }

        private void BuildContent()
        {
            // build content
            var procStartInfo = new ProcessStartInfo(@"C:\Program Files (x86)\MSBuild\MonoGame\v3.0\MGCB\MGCB.exe");
            procStartInfo.Arguments = $"/@:\"{ContentPipelineFilePath}\"";
            procStartInfo.WorkingDirectory = Path.Combine(_projectPath, "content");
            procStartInfo.UseShellExecute = false;
            procStartInfo.RedirectStandardOutput = true;
            var proc = Process.Start(procStartInfo);
            Console.WriteLine(proc.StandardOutput.ReadToEnd());
            proc.WaitForExit();
        }

        private void Initialize()
        {
            Directory.CreateDirectory(Path.Combine(_projectPath, "bin"));
            Directory.CreateDirectory(Path.Combine(_projectPath, "bin", "Content"));
            Directory.CreateDirectory(Path.Combine(_projectPath, "content"));
            // TODO: make this configurable list
            CopyColdsteelFileToBin("Coldsteel.exe");
            CopyColdsteelFileToBin("SharpDX.XInput.dll");
            CopyColdsteelFileToBin("Coldsteel.Composition.dll");
            CopyColdsteelFileToBin("Coldsteel.Configuration.dll");
            CopyColdsteelFileToBin("Coldsteel.Core.dll");
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

            var contentPipelineFile = ContentPipelineFilePath;
            if (!File.Exists(contentPipelineFile))

                File.WriteAllText(contentPipelineFile, @"
#----------------------------- Global Properties ----------------------------#

/outputDir:..\bin\Content
/intermediateDir:obj
/platform:Windows
/config:
/profile:Reach
#/compress:False

#-------------------------------- References --------------------------------#

/reference:..\bin\Coldsteel.Configuration.dll

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
