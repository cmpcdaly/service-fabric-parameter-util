using ParameterAdder.Models;
using ParameterAdder.Models.Manifest;
using ParameterAdder.Models.Parameters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ParameterAdder
{
    class Program
    {
        private static readonly List<Tuple<string, object>> SaveBuffer = new List<Tuple<string, object>>();

        static void Main(string[] arguments)
        {
            // Parse the params
            var args = ArgUtils.ParseArgs(arguments);

            // Process all Service Settings.xml files
            ProcessSettingsFiles(args);

            // Process all Parameter Files
            ProcessParamsFiles(args);

            // Process ApplicationManifest.xml
            ProcessAppManifest(args);

            // Save all files
            foreach (var file in SaveBuffer)
            {
                XmlUtils.WriteXml(file.Item1, file.Item2);
            }
        }

        static void ProcessAppManifest(Args args)
        {
            var appManifestFile = Directory
                .GetFiles(args.ApplicationRoot, "ApplicationManifest.xml", SearchOption.AllDirectories)
                .Single();

            var appManifest = XmlUtils.ReadXml<ApplicationManifest>(appManifestFile);

            // Add the default parameter value
            appManifest.Parameters.Add(new DefaultParameter
            {
                Name = args.ParameterName,
                DefaultValue = args.DefaultParameterValue
            });

            // Add the parameter to each of the services
            foreach(var manifestImport in appManifest.ServiceManifestImports)
            {
                // Find the section
                var cfgOverride = manifestImport
                    .ConfigOverrides
                    .First(co => co.Name == "Config");

                var section = cfgOverride
                    .Settings
                    .FirstOrDefault(s => s.Name == args.SectionName);

                if (section == null)
                {
                    // If the section doesn't exist, create it and add it to the settings
                    section = new Section
                    {
                        Name = args.SectionName,
                        Parameters = new List<Parameter>()
                    };

                    cfgOverride.Settings.Add(section);
                }

                if (section.Parameters.Any(p => p.Name.Equals(args.ParameterName)))
                {
                    throw new Exception($"Unable to add parameter '{args.ParameterName}' as it already exists in '{appManifestFile}");
                }
                // Add a reference to the application parameters value
                section.Parameters.Add(new Parameter
                {
                    Name = args.ParameterName,
                    Value = $"[{args.ParameterName}]"
                });
            }

            SaveBuffer.Add(new Tuple<string, object>(appManifestFile, appManifest));
        }

        private static readonly Regex ParamsRegex = new Regex(@".*ApplicationParameters\" + Path.DirectorySeparatorChar + @".*\.xml");

        static void ProcessParamsFiles(Args args)
        {
            // Parse all Settings.xml files in the directory
            var parameterFiles = Directory
                .GetFiles(args.ApplicationRoot, "*.xml", SearchOption.AllDirectories)
                .Where(path => ParamsRegex.IsMatch(path));

            foreach (var paramFile in parameterFiles)
            {
                var application = XmlUtils.ReadXml<Application>(paramFile);

                if (application.Parameters.Any(p => p.Name.Equals(args.ParameterName)))
                {
                    throw new Exception($"Unable to add parameter '{args.ParameterName}' as it already exists in '{paramFile}'");
                }

                application.Parameters.Add(new Parameter
                {
                    Name = args.ParameterName,
                    Value = args.DefaultParameterValue
                });

                // Add the result to save queue
                SaveBuffer.Add(new Tuple<string, object>(paramFile, application));
            }
        }

        static void ProcessSettingsFiles(Args args)
        {
            // Parse all Settings.xml files in the directory
            // Apparently the search pattern is just for the file name and not the path :(
            var settingsFiles = Directory
                .GetFiles(args.ApplicationRoot, @"Settings.xml", SearchOption.AllDirectories)
                .Where(path => path.EndsWith(Path.Combine("PackageRoot", "Config", "Settings.xml")));

            foreach (var settingsFile in settingsFiles)
            {
                var settings = XmlUtils.ReadXml<Settings>(settingsFile);

                // Find the section
                var section = settings
                    .Sections
                    .FirstOrDefault(s => s.Name.Equals(args.SectionName));

                if (section == null)
                {
                    // If the section doesn't exist, create it and add it to the settings
                    section = new Section
                    {
                        Name = args.SectionName,
                        Parameters = new List<Parameter>()
                    };

                    settings.Sections.Add(section);
                }

                // Ensure that the Parameter doesn't already exist
                if (section.Parameters.Any(p => p.Name.Equals(args.ParameterName)))
                {
                    throw new Exception($"Unable to add parameter '{args.ParameterName}' as it already exists in '{settingsFile}'");
                }

                // Add a new Parameter to the section
                section.Parameters.Add(new Parameter
                {
                    Name = args.ParameterName,
                    Value = string.Empty
                });

                // Add the result to save queue
                SaveBuffer.Add(new Tuple<string, object>(settingsFile, settings));
            }
        }
    }

}
