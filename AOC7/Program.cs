using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using QuikGraph;
using QuikGraph.Algorithms;
using QuikGraph.Algorithms.Search;
using QuikGraph.Algorithms.ShortestPath;

namespace AOC7
{
    class Program
    {
        static void Main(string[] args)
        {
            var allLines = File.ReadAllLines("/home/michiel/dev/AOC/AOC7/input.txt").ToList();

            var edges = new List<(string vertex, List<string> edges)>();

            foreach (var line in allLines)
            {
                var splittedLine = line.Split(' ')
                                       .Where(x => !x.Contains("bag") && x != "contain" && x != "," &&
                                           x != "." &&
                                           Regex.IsMatch(x, "[^0-9]")).ToList();

                edges.Add((string.Concat(splittedLine[0], " ", splittedLine[1]),
                    splittedLine.Skip(2).SelectTwo((a, b) => string.Concat(a, " ", b)).ToList()));
            }

            var bagGraph = new AdjacencyGraph<string, Edge<string>>();

            foreach (var edge in edges)
            {
                if (!bagGraph.ContainsVertex(edge.vertex))
                {
                    bagGraph.AddVertex(edge.vertex);
                }

                foreach (var bagEdge in edge.edges)
                {
                    if (!bagGraph.ContainsVertex(bagEdge))
                    {
                        bagGraph.AddVertex(bagEdge);
                    }

                    bagGraph.AddEdge(new Edge<string>(bagEdge, edge.vertex));
                }
            }

            var root = "shiny gold";
            
            var pathsFound = PathsFound(bagGraph, root);

            Console.WriteLine($"PATHS FOUND:   {pathsFound}");
             TestExample();
        }

        private static int PathsFound(AdjacencyGraph<string, Edge<string>> bagGraph, string root)
        {
            var pathsFound = 0;

            Func<Edge<string>, double> edgeCost = edge => 1; // Constant cost

            TryFunc<string, IEnumerable<Edge<string>>> tryGetPaths = bagGraph.ShortestPathsDijkstra(edgeCost, root);

            foreach (var bagGraphVertex in bagGraph.Vertices)
            {
                if (bagGraphVertex != root)
                {
                    if (tryGetPaths(bagGraphVertex, out IEnumerable<Edge<string>> path))
                    {
                        if (path.Any())
                        {
                            pathsFound++;
                        }
                    }
                }
            }

            return pathsFound;
        }

        private static void TestExample()
        {
            var graph = new AdjacencyGraph<string, Edge<string>>();

            graph.AddVertex("light red");
            graph.AddVertex("bright white");
            graph.AddVertex("muted yellow");
            graph.AddVertex("dark orange");
            graph.AddVertex("shiny gold");
            graph.AddVertex("faded blue");
            graph.AddVertex("vibrant plum");
            graph.AddVertex("dotted black");
            graph.AddVertex("dark olive");

            graph.AddEdge(new Edge<string>("bright white", "light red"));
            graph.AddEdge(new Edge<string>("muted yellow", "light red"));
            graph.AddEdge(new Edge<string>("bright white", "dark orange"));
            graph.AddEdge(new Edge<string>("muted yellow", "dark orange"));
            graph.AddEdge(new Edge<string>("shiny gold", "bright white"));
            graph.AddEdge(new Edge<string>("shiny gold", "muted yellow"));
            graph.AddEdge(new Edge<string>("faded blue", "muted yellow"));
            graph.AddEdge(new Edge<string>("dark olive", "shiny gold"));
            graph.AddEdge(new Edge<string>("vibrant plum", "shiny gold"));
            graph.AddEdge(new Edge<string>("faded blue", "dark olive"));
            graph.AddEdge(new Edge<string>("dotted black", "dark olive"));
            graph.AddEdge(new Edge<string>("faded blue", "vibrant plum"));
            graph.AddEdge(new Edge<string>("dotted black", "vibrant plum"));

            var root = "shiny gold";
            
            var pathsFound = PathsFound(graph, root);

            Console.WriteLine($"PATHS FOUND:   {pathsFound}");
        }
    }

    public static class ExtensionMethods
    {
        public static IEnumerable<TResult> SelectTwo<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TSource, TResult> selector)
        {
            return source.Select((item, index) => new {item, index})
                         .GroupBy(x => x.index / 2)
                         .Select(g => g.Select(i => i.item).ToArray())
                         .Select(x => selector(x[0], x[1]));
        }
    }
}