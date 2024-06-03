//-----------------------------------------------------------------------
// <copyright file="Store.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.CLI;

using Interpreter.Lib.Results.Objects.Atoms;

/// <summary>
/// Basic wrapper class that stores the found answerr sets.
/// </summary>
public class Store
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Store"/> class.
    /// </summary>
    public Store()
    {
        this.AnswerSets = [];
    }

    /// <summary>
    /// Gets or sets the list of atoms to store.
    /// </summary>
    public List<List<Atom>> AnswerSets
    {
        get;
        set;
    }
}