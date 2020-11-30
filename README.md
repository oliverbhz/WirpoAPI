README.md
WiproAPIFinal
Desafio 1 - C#
Criar um serviço REST (Web API) contenha 2 métodos expostos.

AddItemFila
O objetivo do método AddItemFila é adicionar um objeto json com o formato abaixo em uma fila de processamento (utilizar o objeto que desejar para o armazenamento). **Criar as validações de entrada que achar necessário Formato objeto Json de entrada: [ { "moeda": "USD", "data_inicio": "2010-01-01", "data_fim": "2010-12-01" }, { "moeda": "EUR", "data_inicio": "2020-01-01", "data_fim": "2010-12-01" }, { "moeda": "JPY", "data_inicio": "2000-03-11", "data_fim": "2000-03-30" } ]

GetItemFila
O objetivo do método GetItemFila é retornar o último objeto json adicionado na fila pelo método AddItemFila. o Caso exista o objeto a ser retornado, retorná-lo e retirá-lo da fila. o Caso não exista, retornar algo sinalize que não existe objeto a ser retornado.

Desafio 2 - C#
 Pré-requisitos Arquivo de entrada: DadosMoeda.csv (Será enviado junto com este documento) Arquivo de entrada: DadosCotacao.csv (Será enviado junto com este documento) Sensitivity: Internal & Restricted  Descrição Criar uma rotina que rode a cada 2 minutos (Console ou Windows Service) que realize os seguintes passos:

Acesse o método GetItemFila da api desenvolvida no Item anterior. Caso o método retorne um objeto, obter todas as moedas e períodos correspondentes. 1.1. Para cada moeda/período retornada da api, acessar o arquivo DadosMoeda.csv (mesmo diretório de execução) e trazer todas as moedas/datas que estejam dentro do período (Inclusive) da moeda que está sendo tratada. 1.2. Com a lista de moedas/datas, buscar todos os valores de cotação (vlr_cotacao) no arquivo DadosCotacao.csv utilizando o de-para descrito no item 4 (Tabela de de-para) para obter as cotações. 1.3. Gerar um arquivo de resultado (apenas com as moedas/datas consultadas) com o nome Resultado_aaaammdd_HHmmss.csv no mesmo formato do arquivo DadosMoeda.csv. Porém com uma coluna a mais (VL_COTACAO) contendo o valor de cotação correspondente (obtido do arquivo DadosCotacao.csv) para cada moeda/data consultada. 1.4. Encerrar o processamento e aguardar o próximo ciclo de verificação (2 minutos).
Caso o método GetItemFila da api desenvolvida no item anterior não retorne valor. Encerrar o processamento e aguardar o próximo ciclo de verificação (2 minutos).
Observações  Caso julgue necessário, pode ser gerado um log de processamento da rotina.  Enquanto o processamento ocorre, o próximo ciclo de processamento (2 minutos) deverá ficar aguardando. **Não pode haver processamento paralelo.  Utilizar tipos de objetos e lógica de processamento que julguem ser mais performáticas.  Ao final do processamento (do ciclo) o tempo total de processamento do ciclo deverá ser registrado.  A prova deverá ser realizada 100% na linguagem C#, sem restrição de versão do .net framework.  Enviar o link do repositório do teste no github.  Formato de data do arquivo DadosMoeda.csv: (yyyy-mm-dd)  Formato de data do arquivo DadosCotacao.csv: (dd/mm/yyyy)

Desafio 3 - SQL
--1. Com base no modelo acima, escreva um comando SQL que liste a quantidade de processos por Status com sua descrição.

Select count(p.idProcesso) 'QtdProcesso', s.dsStatus 'Descricao' From tb_Processo p inner join tb_Status s on p.idStatus = s.idStatus Group By s.dsStatus

--2. Com base no modelo acima, construa um comando SQL que liste a maior data de andamento por número de processo, com processos encerrados no ano de 2013.

Select max(a.dtAndamento) 'dtAndamento', p.dtEncerramento, p.nroProcesso From tb_Andamento a inner join tb_Processo p on p.idProcesso = a.idProcesso Where YEAR(p.dtEncerramento) = 2013 and dtAndamento IS NOT NULL Group By p.nroProcesso, p.dtEncerramento

--3. Com base no modelo acima, construa um comando SQL que liste a quantidade de Data de Encerramento agrupada por ela mesma onde a quantidade da contagem seja maior que 5.

Select count (dtEncerramento) 'QtdDtEncerramento', dtEncerramento From tb_Processo Group By dtEncerramento Having count (dtEncerramento) > 5

--4. Possuímos um número de identificação do processo, onde o mesmo contém 12 caracteres com zero à esquerda, contudo nosso modelo e dados ele é apresentado como bigint. Como fazer para apresenta-lo com 12 caracteres considerando os zeros a esquerda?

Select idProcesso, RIGHT('000000000000'+CAST(nroProcesso AS VARCHAR(12)),12) 'nroProcesso', autor, dtEntrada, dtEncerramento, idStatus From tb_Processo
