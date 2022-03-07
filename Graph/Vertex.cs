namespace Graph
{
    //объявление вершины графа
    class Vertex
    {
        public char VertexLetter { get; set; }

        public Vertex MinWayVertex { get; set; }

        int wayCount = int.MaxValue;

        public Vertex(char vertexLetter)
        {
            VertexLetter=vertexLetter;
        }

        public int MinWayCount
        {
            get
            {
                return wayCount;
            }
            set
            {
                wayCount = value;
            }
        }

        public override string ToString()
        {
            return VertexLetter.ToString();
        }
    }
}
