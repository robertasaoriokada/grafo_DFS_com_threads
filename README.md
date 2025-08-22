O presente trabalho tem a finalidade de realizar um algoritmo de busca profunda (DFS) em um grafo bidirecional de forma cega utilizando threads.

As novas threads estão sendo criadas a partir das bifurcações de um nó até que todas as threads sejam interrompidas pela chegada ao nó de destino.

Conceitos técnicos utilizadas:
Algoritmo DFS:
Threads: As threads são as menores unidades básicas e lógicas de execução do sistema operacional. No C#, elas podem ser controladas via biblioteca do System.Threading.
Task: As tasks são unidades de abstração de trabalho assíncrono do .NET. Quando se trabalha com threads no C#, o ideal por ser mais performático, é utilizar as taskes, porém para efeitos de trabalho, utilizarei as theads puras.

