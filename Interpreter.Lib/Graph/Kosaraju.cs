using QuickGraph;

namespace Interpreter.Lib.Graph;

// This alogrithm is to find the strongly connected components within a directed graph
public class Kosaraju<T>(AdjacencyGraph<T, Edge<T>> graph)
{
  public AdjacencyGraph<T, Edge<T>> Graph { get; } = graph;

  public List<List<T>> CreateKosaraju()
  {
    var stack = new Stack<T>();
    var visited = new HashSet<T>();
    var sccs = new List<List<T>>();

    foreach (var vertex in Graph.Vertices)
    {
      if (!visited.Contains(vertex))
      {
        FillOrder(vertex, visited, stack);
      }
    }

    var transposedGraph = TransposeGraph();
    visited.Clear();

    while (stack.Count != 0)
    {
      var vertex = stack.Pop();
      if (!visited.Contains(vertex))
      {
        var component = new List<T>();
        DFSUtil(vertex, visited, component, transposedGraph);
        sccs.Add(component);
      }
    }

    return sccs;
  }

  private void FillOrder(T v, HashSet<T> visited, Stack<T> stack)
  {
    visited.Add(v);
    foreach (var edge in Graph.OutEdges(v))
    {
      if (!visited.Contains(edge.Target))
      {
        FillOrder(edge.Target, visited, stack);
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

      DFSUtil(edge.Target, visited, component, transpose);
    }
  }

  private AdjacencyGraph<T, Edge<T>> TransposeGraph()
  {
    var transposed = new AdjacencyGraph<T, Edge<T>>();
    foreach (var vertex in Graph.Vertices)
    {
      transposed.AddVertex(vertex);
    }

    foreach (var edge in Graph.Edges)
    {
      transposed.AddEdge(new Edge<T>(edge.Target, edge.Source));
    }

    return transposed;
  }
}