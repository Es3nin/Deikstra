using System;

namespace Graph
{
    class Program
    {

        private static void Deikstra(Vertex a, Vertex g, Graph graph)
        {
            var result = graph.Deikstra(a, g);
            Console.Write("Minimal way from {0} to {1}: ", a.VertexLetter, g.VertexLetter);
            for (int i = result.Count - 1; i >= 0; i--)
            {
                Console.Write(result[i]);
            }
            Console.WriteLine();
            Console.Write("Minimal way weight: " + g.MinWayCount);
        }

        private static void GetMatrix(Graph graph)
        {
            var matrix = graph.graphMatrix();
            Console.Write("  ");
            for (int i = 0; i < graph.Vertexes.Count; i++)
            {
                Console.Write(graph.Vertexes[i].ToString() + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write(graph.Vertexes[i] + " ");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void GetVertexList(Vertex a, Graph graph)
        {
            var getList = graph.GetVertexLists(a);

            Console.Write(a.VertexLetter + ": ");
            for (int i = 0; i < getList.Count; i++)
            {
                Console.Write(getList[i] + ",");
            }
            Console.WriteLine();
        }   

        static void Main(string[] args)
        {
            Vertex a = new Vertex('A');
            Vertex b = new Vertex('B');
            Vertex c = new Vertex('C');
            Vertex d = new Vertex('D');
            Vertex e = new Vertex('E');
            Vertex f = new Vertex('F');
            Vertex g = new Vertex('G');


            Graph graph = new Graph();

            //добавление вершин матрицы

            graph.VertexAdd(a);
            graph.VertexAdd(b);
            graph.VertexAdd(c);
            graph.VertexAdd(d);
            graph.VertexAdd(e);
            graph.VertexAdd(f);
            graph.VertexAdd(g);

            //добавление ребер и весов

            graph.EdgeAdd(a, b, 2);
            graph.EdgeAdd(a, c, 3);
            graph.EdgeAdd(a, d, 6);
            graph.EdgeAdd(b, a, 2);
            graph.EdgeAdd(b, c, 4);
            graph.EdgeAdd(b, e, 9);
            graph.EdgeAdd(c, a, 3);
            graph.EdgeAdd(c, b, 4);
            graph.EdgeAdd(c, d, 1);
            graph.EdgeAdd(c, e, 7);
            graph.EdgeAdd(c, f, 6);
            graph.EdgeAdd(d, a, 6);
            graph.EdgeAdd(d, f, 4);
            graph.EdgeAdd(e, b, 9);
            graph.EdgeAdd(e, c, 7);
            graph.EdgeAdd(e, f, 1);
            graph.EdgeAdd(e, g, 5);
            graph.EdgeAdd(f, c, 6);
            graph.EdgeAdd(f, d, 7);
            graph.EdgeAdd(f, e, 1);
            graph.EdgeAdd(f, g, 8);
            graph.EdgeAdd(g, f, 8);
            graph.EdgeAdd(g, e, 5);

            GetVertexList(a, graph);
            GetVertexList(b, graph);
            GetVertexList(c, graph);
            GetVertexList(d, graph);
            GetVertexList(e, graph);
            GetVertexList(f, graph);
            GetVertexList(g, graph);

            GetMatrix(graph);
            Console.WriteLine();
            Deikstra(a, g, graph);
        }
    }
}
