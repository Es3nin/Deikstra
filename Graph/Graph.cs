using System;
using System.Collections.Generic;

namespace Graph
{
    class Graph
    {

        List<Vertex> vertexList = new List<Vertex>();
        List<Edge> edgeList = new List<Edge>();


        public List<Vertex> Vertexes
        {
            get
            {
                return vertexList;
            }
        }
        //add vertexes
        public void VertexAdd(Vertex a)
        {
            vertexList.Add(a);
        }

        // ребра с одинаковым весом
        public void EdgeAdd(Vertex from, Vertex to)
        {
            var edge = new Edge(from, to);
            edgeList.Add(edge);
        }
        // ребра с отличающимся весом
        public void EdgeAdd(Vertex from, Vertex to, int weight)
        {
            var edge = new Edge(from, to, weight);
            edgeList.Add(edge);
        }

        private int VertexCount => vertexList.Count;
        private int EdgeCount => edgeList.Count;

        public int[,] graphMatrix()
        {
            var matrix = new int[VertexCount, VertexCount];
            var weight = 0; // переменная для обозначения весa
            for (int i = 0; i < vertexList.Count; i++)
            {
                var vertexList = GetVertexLists(this.vertexList[i]);
                var k = 0;

                for (int j = 0; j < vertexList.Count;)
                {
                    try
                    {
                        if (this.vertexList[k] == vertexList[j] && k < this.vertexList.Count)
                        {
                            matrix[i, k] = edgeList[weight].Weight;
                            j++;
                            weight++;
                        }
                        k++;
                    }
                    catch
                    {
                        k = 0;
                    }
                }
            }
            return matrix;
        }

        public List<Vertex> GetVertexLists(Vertex vertex)
        {
            var result = new List<Vertex>();

            foreach (var edge in edgeList)
            {
                if (edge.From == vertex)
                {
                    result.Add(edge.To);
                }
            }
            return result;
        }

        public List<Vertex> Deikstra(Vertex start, Vertex finish)
        {
            var result = new List<Vertex>();

            start.MinWayCount = 0;

            foreach (var edges in edgeList)
            {
                if ((double)edges.Weight + edges.From.MinWayCount <= edges.To.MinWayCount)
                {
                    edges.To.MinWayCount = edges.Weight + edges.From.MinWayCount;
                    edges.To.MinWayVertex = edges.From;
                }
            }

            finish.MinWayCount = finish.MinWayVertex.MinWayCount + edgeList[edgeList.Count - 1].Weight;

            while (finish != start)
            {
                result.Add(finish);
                finish = finish.MinWayVertex;
            }
            result.Add(start);

            return result;
        }


        public override string ToString()
        {
            for (int i = 0; i < edgeList.Count; i++)
            {
                Console.Write(edgeList[i] + " ");
            }
            return "\n";
        }
    }
}
