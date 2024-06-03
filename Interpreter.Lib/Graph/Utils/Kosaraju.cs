//-----------------------------------------------------------------------
// <copyright file="Kosaraju.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Graph;

using QuickGraph;

/// <summary>
/// This alogrithm is to find the strongly connected components within a directed graph.
/// </summary>
/// <typeparam name="T">The type of the components of the adjacency graph.</typeparam>
/// <param name="graph">The graph represented by an adjacency list.</param>
public class Kosaraju<T>(AdjacencyGraph<T, Edge<T>> graph)
{
  /// <summary>
  /// Gets the graph represented by an adjacency list where each node is connected by edges.
  /// </summary>
  public AdjacencyGraph<T, Edge<T>> Graph { get; } = graph;

  /// <summary>
  /// Creates the Kosaraju's algorithm to find all strongly connected components in the graph.
  /// </summary>
  /// <returns>A list of strongly connected components.</returns>
  public List<List<T>> CreateKosaraju()
  {
    var stack = new Stack<T>();
    var visited = new HashSet<T>();
    var sccs = new List<List<T>>();

    foreach (var vertex in this.Graph.Vertices)
    {
      if (!visited.Contains(vertex))
      {
        this.FillOrder(vertex, visited, stack);
      }
    }

    var transposedGraph = this.TransposeGraph();
    visited.Clear();

    while (stack.Count != 0)
    {
      var vertex = stack.Pop();
      if (!visited.Contains(vertex))
      {
        var component = new List<T>();
        this.DFSUtil(vertex, visited, component, transposedGraph);
        sccs.Add(component);
      }
    }

    return sccs;
  }

  private void FillOrder(T v, HashSet<T> visited, Stack<T> stack)
  {
    visited.Add(v);
    foreach (var edge in this.Graph.OutEdges(v))
    {
      if (!visited.Contains(edge.Target))
      {
        this.FillOrder(edge.Target, visited, stack);
      }
    }

    stack.Push(v);
  }

  private void DFSUtil(T visitor, HashSet<T> visited, List<T> component, AdjacencyGraph<T, Edge<T>> transpose)
  {
    visited.Add(visitor);
    component.Add(visitor);

    foreach (var edge in transpose.OutEdges(visitor))
    {
      if (visited.Contains(edge.Target))
      {
        continue;
      }

      this.DFSUtil(edge.Target, visited, component, transpose);
    }
  }

  private AdjacencyGraph<T, Edge<T>> TransposeGraph()
  {
    var transposed = new AdjacencyGraph<T, Edge<T>>();
    foreach (var vertex in this.Graph.Vertices)
    {
      transposed.AddVertex(vertex);
    }

    foreach (var edge in this.Graph.Edges)
    {
      transposed.AddEdge(new Edge<T>(edge.Target, edge.Source));
    }

    return transposed;
  }
}