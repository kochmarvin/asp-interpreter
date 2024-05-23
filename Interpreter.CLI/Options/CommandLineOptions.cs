//-----------------------------------------------------------------------
// <copyright file="CommandLineOptions.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.CLI.Options;

using CommandLine;

/// <summary>
/// The available options of command line arguments.
/// </summary>
public class CommandLineOptions
{
    /// <summary>
    /// Gets or sets the file path option of the executable.
    /// </summary>
    [Option('f', "file", Required = false, HelpText = "Load a specific file with extension .lp")]
    public string? FilePath { get; set; }

    /// <summary>
    /// Gets or sets the query option of the executable.
    /// </summary>
    [Option('q', "query", Required = false, HelpText = "Execute a query on the loaded file")]
    public string? Query { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the the explain option of the executable.
    /// </summary>
    [Option('e', "explain", Required = false, HelpText = "Explain a programm with words")]
    public bool Explain { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the verbose option of the executable is set.
    /// </summary>
    [Option("verbose", Required = false, HelpText = "Enable debug output to be shown")]
    public bool Verbose { get; set; }
}