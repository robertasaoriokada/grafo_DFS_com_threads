using Microsoft.Msagl.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoDFS
{
    public class Grafo
    {
        public Grafo() { }
        public List<Node> Nodes { get; set; } = new List<Node>();
        public List<Aresta> Arestas { get; set; } = new List<Aresta>();
        
        public List<Node> DFS(Grafo grafo, Node nodeInicial, Node nodeFinal)
        {
            List<Node> visited = new List<Node>();
            if (grafo == null) throw new Exception("Grafo é nulo");

            bool encontrado = DFSRecursivo(grafo, nodeInicial, nodeFinal, visited);

            if (!encontrado) throw new Exception("Não há caminho entre os nós solicitados");

            return visited;
        }

        public bool DFSRecursivo(Grafo grafo, Node nodeAtual, Node nodeDestino, List<Node> visited)
        {
            visited.Add(nodeAtual);

            if (nodeAtual.Id == nodeDestino.Id)
                return true;

            foreach (var aresta in grafo.Arestas)
            {
                Node proximo = null;
                if (aresta.Node1.Id == nodeAtual.Id)
                {
                    proximo = aresta.Node2;
                } else if(aresta.Node2.Id == nodeAtual.Id)
                {
                    proximo = aresta.Node1;
                }

                if (proximo != null && !visited.Contains(proximo))
                {
                    bool encontrado = DFSRecursivo(grafo, proximo, nodeDestino, visited);
                    if (encontrado) return true;
                }

            }
            visited.Remove(nodeAtual);
            return false;
        }


        public Graph DesenharGrafo(Grafo g, List<Node> caminho = null)
        {
            var graph = new Graph("meuGrafo");

            foreach (var aresta in g.Arestas)
            {
                var edge = graph.AddEdge(aresta.Node1.LetterTitle, aresta.Node2.LetterTitle);
                edge.Attr.ArrowheadAtTarget = ArrowStyle.None;
                edge.Attr.ArrowheadAtSource = ArrowStyle.None;

                // Se fornecido um caminho, pinta as arestas correspondentes de vermelho
                if (caminho != null)
                {
                    for (int i = 0; i < caminho.Count - 1; i++)
                    {
                        if ((aresta.Node1 == caminho[i] && aresta.Node2 == caminho[i + 1]) ||
                            (aresta.Node2 == caminho[i] && aresta.Node1 == caminho[i + 1]))
                        {
                            edge.Attr.Color = Color.Red;
                            edge.Attr.LineWidth = 3;
                        }
                    }
                }
            }

            return graph;
        }

    }
}
