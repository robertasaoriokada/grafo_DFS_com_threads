using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using System;
using System.Windows.Forms;

namespace GrafoDFS.Program
{
    class Program
    {
        public static void Main(string[] args)
        {
            Grafo grafo = new Grafo();

            Node A = new Node { Id = 0, LetterTitle = "A" };
            Node B = new Node { Id = 1, LetterTitle = "B" };
            Node C = new Node { Id = 2, LetterTitle = "C" };
            Node D = new Node { Id = 3, LetterTitle = "D" };
            Node E = new Node { Id = 4, LetterTitle = "E" };
            Node F = new Node { Id = 5, LetterTitle = "F" };
            Node G = new Node { Id = 6, LetterTitle = "G" };
            Node H = new Node { Id = 7, LetterTitle = "H" };

            grafo.Nodes.Add(A);
            grafo.Nodes.Add(B);
            grafo.Nodes.Add(C);
            grafo.Nodes.Add(D);
            grafo.Nodes.Add(E);
            grafo.Nodes.Add(F);
    
            Aresta AB = new Aresta(A, B);
            Aresta AC = new Aresta(A, C);
            Aresta AD = new Aresta(A, D);
            Aresta BE = new Aresta(B, E);
            Aresta BF = new Aresta(B, F);
            Aresta DG = new Aresta(D, G);
            Aresta DH = new Aresta(D, H);

            grafo.Arestas.Add(AB);
            grafo.Arestas.Add(AC);
            grafo.Arestas.Add(AD);
            grafo.Arestas.Add(BE);
            grafo.Arestas.Add(BF);
            grafo.Arestas.Add(DG);
            grafo.Arestas.Add(DH);

            var listaDeNos = grafo.DFS(grafo, E, H);

            Console.WriteLine("Caminho DFS:");
            foreach (var no in listaDeNos)
            {
                Console.Write(no.LetterTitle + " ");
            }
            Console.WriteLine();
            Console.WriteLine(grafo.ThreadsAtivadas);



            var viewerOriginal = new GViewer
            {
                Graph = grafo.DesenharGrafo(grafo),
                Dock = DockStyle.Top,
                Height = 300
            };

            // === Grafo com caminho DFS destacado ===
            var viewerCaminho = new GViewer
            {
                Graph = grafo.DesenharGrafo(grafo, listaDeNos),
                Dock = DockStyle.Bottom,
                Height = 300
            };

            // Formulário
            var form = new Form();
            form.Text = "Visualização do Grafo";
            form.Width = 800;
            form.Height = 700; // altura maior para os dois viewers
            form.Controls.Add(viewerOriginal);
            form.Controls.Add(viewerCaminho);

            Application.Run(form);



        }
    }
}