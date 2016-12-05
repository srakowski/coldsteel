using Coldsteel.Studio.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.Studio.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!args.Any())
            {
                var end = false;
                while (!end)
                {
                    Console.Write("coldsteel> ");
                    var command = Console.ReadLine();
                    if (command == "exit")
                    {
                        end = true;
                    }
                    else
                    {
                        var commmandArgs = command.Split().Where(s => !string.IsNullOrWhiteSpace(s));
                        if (commmandArgs.Any())
                            Execute(commmandArgs, shell: true);
                    }
                }
            }
            else
            {
                Execute(args, shell: false);
            }
        }

        private static void Execute(IEnumerable<string> commandArgs, bool shell)
        {
            var commandEnumerator = commandArgs.GetEnumerator();
            commandEnumerator.MoveNext();
            var command = commandEnumerator.Current;
            switch (command.ToLower())
            {
                case "init":
                    Console.Write("name: ");
                    var name = Console.ReadLine().Trim();
                    var project = Project.Create(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), name);
                    if (shell)
                        ProjectShell(project);
                    break;
            }
        }

        private static void ProjectShell(Project project)
        {
            var end = false;
            while (!end)
            {
                Console.Write($"{project.Name}> ");
                var command = Console.ReadLine();
                if (command == "exit")
                {
                    end = true;
                }
                else
                {
                    var commandArgs = command.Split().Where(s => !string.IsNullOrWhiteSpace(s));
                    if (commandArgs.Any())
                    {
                        ExecuteProject(project, commandArgs);
                    }
                }
            }
        }

        private static void ExecuteProject(Project project, IEnumerable<string> commandArgs)
        {
            var commandEnumerator = commandArgs.GetEnumerator();
            commandEnumerator.MoveNext();
            var command = commandEnumerator.Current;
            switch (command.ToLower())
            {
                case "run":
                    project.Run();
                    break;
            }
        }
    }
}
