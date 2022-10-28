using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Util;
using System.Collections;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

#region Primeiro Array
//testaArray();
//TestaBuscarPalavra();

void testaArray()
{

    int[] idades = new int[3];
    idades[0] = 30;
    idades[1] = 25;
    idades[2] = 18;

    Console.WriteLine("O tamanho do array é: " + idades.Length);

    
    int somadorDeIdade = 0;

    for (int i = 0; i < idades.Length; i++)
    {
        int idade = idades[i];
        Console.WriteLine($"A idade do indice [{i}] é: {idade}");
        somadorDeIdade += idade;

    }

    var media  = somadorDeIdade/idades.Length;
    Console.WriteLine($"A média das idades é: {media }");
}
#endregion

#region Buscando itens em array
void TestaBuscarPalavra()
{
    string[] arrayDePalavras = new string[5];

    for (int i = 0; i < arrayDePalavras.Length; i++)
    {
        Console.Write($"Digite a {i + 1}ª palavra:");
        arrayDePalavras[i] = Console.ReadLine();
    }

    Console.Write("Digite a palavra a ser encontrada: ");
    var busca = Console.ReadLine();

    foreach (string palavra in arrayDePalavras)
    {
        if (palavra.Equals(busca))
        {
            Console.WriteLine($"Palavra encontrada = {busca}");
            break;
        }
       
    }
    
}
#endregion

#region Criando array utilizando a classe Array 

Array amostra = Array.CreateInstance(typeof(double), 5);
amostra.SetValue(5.9,0);
amostra.SetValue(1.8,1);
amostra.SetValue(7.1,2);
amostra.SetValue(10,3);
amostra.SetValue(6.9,4);
#endregion

#region TestaMediana (Calculo de mediana no Array) ;

void TestaMediana (Array array)
{
    //se array estiver  nulo ou vazio
    if((array == null) || (array.Length==0))
    {
        Console.WriteLine("Array para cálculo da Mediana está vazio ou nulo ");
    }
    
    //ordenando array para cálculo de mediana (sort)
    double[] arrayOrdenado = (double [])array.Clone();
    Array.Sort(arrayOrdenado);

    //Calculando mediana (é necessário encontrar o meio dos arrays passados e que foram ordenados no método anterior)

    int tamanho = arrayOrdenado.Length;
    int meio = tamanho/2;

    //cálculo da mediana (se o resto da divisão do tamanho for diferente de zero o arrarOrdenado retorna o valor do meio,
    //senão (for igual a 0/o array é par) pega a posição que está ao meio + a posição anterior e divide por 2
    double mediana = (tamanho % 2 != 0) ? arrayOrdenado[meio] : (arrayOrdenado[meio] - arrayOrdenado[meio - 1]) / 2;

    Console.WriteLine($"Com base na amostra a mediana = {mediana}");


}
#endregion

#region Array de Objetos 

//testaArrayDeContaCorrente();

void testaArrayDeContaCorrente()
{
    ContaCorrente[] contaCorrentes = new ContaCorrente[]
    {
        new ContaCorrente(874, "444444444"),
        new ContaCorrente(339, "444444444"),
        new ContaCorrente(224, "444444444"),
        new ContaCorrente(372, "444444444")

    };

    for (int i = 0; i < contaCorrentes.Length; i++)
    {
        ContaCorrente contaAtual = contaCorrentes[i];
        Console.WriteLine($"Indice {i}- Conta: {contaAtual.Conta} e Agencia: {contaAtual.Numero_agencia}");
    }   

    
}
#endregion

#region Array de Objetos a partir da classe
//testaArrayDeContaCorrente2();

void testaArrayDeContaCorrente2()
{
    ListaDeContasCorrentes listaDeContasCorrentes = new ListaDeContasCorrentes();

    listaDeContasCorrentes.Adicionar(new ContaCorrente(874, "444444444"));
    listaDeContasCorrentes.Adicionar(new ContaCorrente(339, "444444444"));
    listaDeContasCorrentes.Adicionar(new ContaCorrente(224, "444444444"));
    listaDeContasCorrentes.Adicionar(new ContaCorrente(372, "22222222"));
    listaDeContasCorrentes.Adicionar(new ContaCorrente(372, "22222222"));


    //ContaCorrente conta = listaDeContasCorrentes.MaiorSaldo();
    //Console.WriteLine($"A conta com maior saldo é: {conta.Saldo}");

};
#endregion

#region Removendo item do array e reorganizando

//testaArrayDeContaCorrente3();
void testaArrayDeContaCorrente3()
{
    ListaDeContasCorrentes listaDeContasCorrentes = new ListaDeContasCorrentes();

    listaDeContasCorrentes.Adicionar(new ContaCorrente(874, "111111111"));
    listaDeContasCorrentes.Adicionar(new ContaCorrente(339, "444444444"));
    listaDeContasCorrentes.Adicionar(new ContaCorrente(224, "444444444"));
    listaDeContasCorrentes.Adicionar(new ContaCorrente(372, "22222222"));
    listaDeContasCorrentes.Adicionar(new ContaCorrente(372, "22222222"));

    Console.WriteLine("==============================");

    var contaDoVictor = new ContaCorrente(649,"111111111");
    listaDeContasCorrentes.Adicionar(contaDoVictor);

    Console.WriteLine("==============================");
    listaDeContasCorrentes.ExibeLista();
    listaDeContasCorrentes.Remover(contaDoVictor);

    Console.WriteLine("==============================");
    listaDeContasCorrentes.ExibeLista();

};
#endregion

#region Recuperando uma conta  pelo indice no array

//testaArrayDeContaCorrente4();
void testaArrayDeContaCorrente4()
{
    ListaDeContasCorrentes listaDeContasCorrentes = new ListaDeContasCorrentes();

    listaDeContasCorrentes.Adicionar(new ContaCorrente(874, "111111111"));
    listaDeContasCorrentes.Adicionar(new ContaCorrente(339, "444444444"));
    listaDeContasCorrentes.Adicionar(new ContaCorrente(224, "444444444"));
    listaDeContasCorrentes.Adicionar(new ContaCorrente(372, "22222222"));
    listaDeContasCorrentes.Adicionar(new ContaCorrente(372, "22222222"));

    Console.WriteLine("==============================");

    var contaDoVictor = new ContaCorrente(649, "111111111");
    listaDeContasCorrentes.Adicionar(contaDoVictor);


    for (int i = 0; i < listaDeContasCorrentes.Tamanho; i++)
    {
        ContaCorrente contaCorrente = listaDeContasCorrentes[i]; //Criando um indexador da classe de Conta Corrente quer então pode ter o comportamento de um array
        Console.WriteLine($"Indice [{i}] = Conta: {contaCorrente.Conta} Agência: {contaCorrente.Numero_agencia}");
    }
 

};

#endregion




//Criando Menu de opções
//Utilizando Coleções de arrays (Array list permite uma série de método com arrays, como cadastar, limpar entre outros)



ArrayList _listadeContas = new ArrayList();

atendimentoCliente();

void atendimentoCliente()
{
    char opcao = '0';
    while (opcao != '6')
    {
        Console.Clear();
        Console.WriteLine("==============================================================");
        Console.WriteLine("==================       ATENDIMENTO       ===================");
        Console.WriteLine("==================  1 - Cadastrar Conta    ===================");
        Console.WriteLine("==================  2 - Listar Conta       ===================");
        Console.WriteLine("==================  3 - Remover Conta      ===================");
        Console.WriteLine("==================  4 - Ordenar Conta      ===================");
        Console.WriteLine("==================  5 - Pesquisar Conta    ===================");
        Console.WriteLine("==================  6 - Sair do sistema    ===================");
        Console.WriteLine("==============================================================");
        Console.WriteLine("\n\n");
        Console.Write("Digite a opção desejada: ");
        opcao = Console.ReadLine()[0];
        switch (opcao)
        {
            case '1':
                CadastrarConta();
                break;
            case '2':
                ListarContas();
                break;
            default:
                Console.WriteLine("Opção não implementada");
                break;
        }



    }

}



void CadastrarConta()
{
    Console.Clear();
    Console.WriteLine("==============================================================");
    Console.WriteLine("==================  1 - Cadastrar Conta    ===================");
    Console.WriteLine("==============================================================");
    Console.WriteLine("\n");
    Console.WriteLine("================  Informe os dados da Conta  =================");
    Console.WriteLine("\n");
  
    Console.Write("Número da Conta: ");
    string numeroConta = Console.ReadLine();
   
    Console.Write("Número da agência: ");
    int numeroAgencia = int.Parse(Console.ReadLine());



    ContaCorrente contaCorrente = new ContaCorrente(numeroAgencia, numeroConta); ;
   
    Console.Write("Informe o saldo inicial: ");
    contaCorrente.Saldo = double.Parse(Console.ReadLine());

    Console.Write("Informe o nome do titular da Conta: ");
    contaCorrente.Titular.Nome = Console.ReadLine();

    Console.Write("Informe o CPF do titular da Conta: ");
    contaCorrente.Titular.Cpf = Console.ReadLine();

    Console.Write("Informe a profissão do titular da Conta: ");
    contaCorrente.Titular.Profissao = Console.ReadLine();

    _listadeContas.Add(contaCorrente);
    Console.WriteLine("\n");
    Console.WriteLine("==============  Conta Cadastrada com Sucesso  ================");
    Console.ReadKey();

}

void ListarContas()
{
    Console.Clear();
    Console.WriteLine("==============================================================");
    Console.WriteLine("==================   2 - Listar Contas     ===================");
    Console.WriteLine("==============================================================");
    Console.WriteLine("\n");

    if (_listadeContas.Count <= 0 )
    {
 
        Console.WriteLine("==============  Não há contas cadastradas  ================");
        Console.ReadKey();
        return;

    }
    foreach (ContaCorrente item in _listadeContas)
    {
        Console.WriteLine("==================  Dados da Conta  ====================");
        Console.WriteLine($"Número da conta:{item.Conta} ");
        Console.WriteLine($"Titular da conta:{item.Titular.Nome} ");
        Console.WriteLine($"CPF do titular:{item.Titular.Cpf} ");
        Console.WriteLine($"Profissão do titular:{item.Titular.Profissao} ");
        Console.WriteLine("========================================================");
        Console.ReadKey();

    }


}