//-----------------------------------------------------------------------
// <copyright file="IHeadAccept.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

/// <summary>
/// Interface for objects that can accept a HeadVisitor.
/// </summary>
public interface IHeadAccept
{
  /// <summary>
  /// Accepts a visitor to process the head object.
  /// </summary>
  /// <typeparam name="T">The type of the result produced by the visitor.</typeparam>
  /// <param name="visitor">The visitor to accept.</param>
  /// <returns>The result produced by the visitor.</returns>
  public T? Accept<T>(HeadVisitor<T> visitor);
}