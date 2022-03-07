namespace Graph
{
    class Edge
    {
        public Vertex From { get; set; }
        public Vertex To { get; set; }

        public int Weight { get; private set; }


        public Edge(Vertex from,Vertex to,int weight=1)
        {
            From = from;
            To = to;
            Weight = weight;
        }



        public override string ToString()
        {
            return "From " + From + " to " + To+" Weight "+Weight+"\n";
        }
    }
}
