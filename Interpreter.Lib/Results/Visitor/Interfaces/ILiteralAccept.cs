//-----------------------------------------------------------------------
// <copyright file="ILiteralAccept.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

/// <summary>
/// Interface for objects that can accept a LiteralVisitor.
/// </summary>
public interface ILiteralAccept
{
  /// <summary>
  /// Accepts a visitor to process the Literal object.
  /// </summary>
  /// <typeparam name="T">The type of the result produced by the visitor.</typeparam>
  /// <param name="visitor">The visitor to accept.</param>
  /// <returns>The result produced by the visitor.</returns>
  public T? Accept<T>(LiteralVisitor<T> visitor);
}