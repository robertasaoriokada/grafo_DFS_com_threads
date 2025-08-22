O presente trabalho tem a finalidade de realizar um algoritmo de busca profunda (DFS) em um grafo bidirecional de forma cega utilizando threads.

As novas threads estão sendo criadas a partir das bifurcações de um nó até que todas as threads sejam interrompidas pela chegada ao nó de destino.

Conceitos técnicos utilizadas:
Algoritmo DFS: Depth-First Search é um algoritmo de busca profunda que explora um grafo ou árvore percorrendo o máximo possível ao longo dos nós antes de fazer o backtracking e explorar outros caminhos. 
Threads: As threads são as menores unidades básicas e lógicas de execução do sistema operacional. No C#, elas podem ser controladas via biblioteca do System.Threading. No código podemos ver as threads sendo geradas a partir de cada bifurcação e quando chegamos ao nó destino é preciso utilizar a ferramenta lock para evitar a condição de corrida e perder a integridade da variável desejada. As threads permitem um controle maior do desenvolvedor, pois ele que fornece os comandos como Start e Join, e deve ser utilizados oputros mecanismos de controle como Lock, Semaphore e etc.
Task: As tasks são unidades de abstração de alto nível de trabalho assíncrono do .NET sobre as threads. O programador não controla diretamente qual thread será usada, quem gerencia é o ThreadPool do .NET. Quando se trabalha com threads no C# é o ideal por ser mais performático, porém para efeitos desse trabalho e gerenciamento do código, utilizarei as theads puras com mecanismos mais a baixo nível para conhecer e exemplificar.

