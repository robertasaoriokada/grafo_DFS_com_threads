using Microsoft.Msagl.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GrafoDFS
{
    public class Grafo
    {
        public Grafo() { }
        public List<Node> Nodes { get; set; } = new List<Node>();
        public List<Aresta> Arestas { get; set; } = new List<Aresta>();

        private List<Node> _caminhoFinal = new List<Node>();
        private volatile bool _caminhoEncontrado = false;
        private readonly object _locker = new object();
        public int ThreadsAtivadas = 0;
        
        public List<Node> DFS(Grafo grafo, Node nodeInicial, Node nodeFinal)
        {
            List<Node> visited = new List<Node>();
            if (grafo == null) throw new Exception("Grafo é nulo");
            if (nodeInicial == null || nodeFinal == null) throw new Exception("Nós inválidos");

            bool encontrado = DFSRecursivo(grafo, nodeInicial, nodeFinal, visited);

            if (!encontrado) throw new Exception("Não há caminho entre os nós solicitados");

            return _caminhoFinal;
        }

        public bool DFSRecursivo(Grafo grafo, Node nodeAtual, Node nodeDestino, List<Node> visited)
        {
            if (_caminhoEncontrado) return true;
            visited.Add(nodeAtual);

            //Lógica de nó destino encontrado, então cria-se lock para evitar condições de corrida e duas ou mais threads alterarem o caminhoFinal.
            if (nodeAtual.Id == nodeDestino.Id)
            {
                lock(_locker)
                {
                    _caminhoFinal = new List<Node>(visited);
                    _caminhoEncontrado = true;
                }
                return true;
            }

            //Threads locais
            List<Thread> threadsLocais = new List<Thread>();

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
                    var copia = new List<Node>(visited);
                    Thread t = new Thread(() =>
                    {
                        DFSRecursivo(grafo, proximo, nodeDestino, copia);
                    });
                    t.Start();
                    threadsLocais.Add(t);
                    ThreadsAtivadas++;

                }

            }

            foreach (var t in threadsLocais)
            {
                t.Join();
            }

            return _caminhoEncontrado;
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
