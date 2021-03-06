//-----------------------------------------------------------------------
// <copyright file="AssemblyTypeToSwaggerGeneratorSettings.cs" company="NSwag">
//     Copyright (c) Rico Suter. All rights reserved.
// </copyright>
// <license>https://github.com/NSwag/NSwag/blob/master/LICENSE.md</license>
// <author>Rico Suter, mail@rsuter.com</author>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Linq;
using NJsonSchema.Generation;
using NSwag.CodeGeneration.Utilities;

namespace NSwag.CodeGeneration.SwaggerGenerators
{
    /// <summary>Settings for the <see cref="AssemblyTypeToSwaggerGenerator"/>.</summary>
    public class AssemblyTypeToSwaggerGeneratorSettings : JsonSchemaGeneratorSettings
    {
        /// <summary>Initializes a new instance of the <see cref="AssemblyTypeToSwaggerGeneratorSettings"/> class.</summary>
        public AssemblyTypeToSwaggerGeneratorSettings()
        {
            ReferencePaths = new string[] { };
        }

        /// <summary>Gets or sets the assembly path.</summary>
        public string AssemblyPath { get; set; }

        /// <summary>Gets or sets the path to the assembly App.config or Web.config (optional).</summary>
        public string AssemblyConfig { get; set; }

        /// <summary>Gets ot sets the paths where to search for referenced assemblies</summary>
        public string[] ReferencePaths { get; set; }

        /// <summary>Gets all reference paths.</summary>
        public IEnumerable<string> AllReferencePaths
        {
            get
            {
                return new[] { Path.GetDirectoryName(PathUtilities.MakeAbsolutePath(AssemblyPath, Directory.GetCurrentDirectory())) }
                    .Concat(ReferencePaths)
                    .Distinct()
                    .ToArray();
            }
        }
    }
}