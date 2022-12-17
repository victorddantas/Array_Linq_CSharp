using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Util;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

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

#region Para relembrar. Generics e override

// Posso definir o tipo da classe no momento de estanciar ela (classes foram criadas abaixo)

//MinhaCalsseGenerica<string> minhaCalsseGenerica = new MinhaCalsseGenerica<string>();//tipo string
//minhaCalsseGenerica.ExibirDados("Olá MUndo!!!");

//Console.WriteLine("===========================================================================");

//MinhaCalsseGenerica<int> minhaCalsseGenerica2 = new MinhaCalsseGenerica<int>();//tipo int
//minhaCalsseGenerica2.ExibirDados(100000);

//Console.WriteLine("===========================================================================");

//Pessoa pessoa = new Pessoa() { Idade = 24, Nome = "Victor" }; //estancia da classe pessoa

//MinhaCalsseGenerica<Pessoa> minhaCalsseGenerica3 = new MinhaCalsseGenerica<Pessoa>();//tipo pessoa (outra classe)
//minhaCalsseGenerica3.ExibirDados(pessoa);

//public class MinhaCalsseGenerica<T>
//{

//    public T? PropiedadeGenerica { get; set; }// propiedade genérica 


//    public void ExibirDados(T t) 
//    {
//        Console.WriteLine($"Dado informado = {t.ToString()}");
//        Console.WriteLine($"Tipo = {t.GetType()}"); //vai exibir  o tipo 
//    }
//}


//também pode definir  por classe 



//public class Pessoa {
//    public string? Nome { get; set; }
//    public int Idade { get; set; }


//    //O modificador override é necessário para estender ou modificar a implementação abstrata ou virtual de um método, propriedade, indexador ou evento herdado.
//    public override string ToString()
//    {
//        return $"Nome = {this.Nome} com Idade = {this.Idade}";
//    }
//}







#endregion

#region Métodos da Coleção List (genérica) 

List<ContaCorrente> _listaDeContas1 = new List<ContaCorrente>()
{
    new ContaCorrente(999,"598087-A"),
    new ContaCorrente(888,"089543-B"),
    new ContaCorrente(777,"489765-C")
};

List<ContaCorrente> _listaDeContas2 = new List<ContaCorrente>()
{
    new ContaCorrente(999,"598087-D"),
    new ContaCorrente(888,"089543-E"),
    new ContaCorrente(777,"489765-F")
};



//O Addrange adiciona junta duas listas 
_listaDeContas1.AddRange(_listaDeContas2);

for (int i = 0; i < _listaDeContas1.Count; i++)
{
    Console.WriteLine($"Indice[{i}] = Conta [{_listaDeContas1[i].Conta}]");
}


//remover indices de uma lista com o getRange

Console.WriteLine("\n");
Console.WriteLine("============================================");
var range = _listaDeContas2.GetRange(0, 1);

for (int i = 0; i < range.Count; i++)
{
    Console.WriteLine($"Indice[{i}] = Conta [{range[i].Conta}]");
}

//inverter uma lista com reverse
Console.WriteLine("\n");
Console.WriteLine("============================================");


_listaDeContas2.Reverse();

var lista1 = _listaDeContas2;

for (int i = 0; i < lista1.Count; i++)
{
    Console.WriteLine($"Indice[{i}] = Conta [{lista1[i].Conta}]");
}




#endregion

#region Desafio - Encontre o nome no array

//buscarNome();

void buscarNome()
{
    List<string> nomesDosEscolhidos = new List<string>()
{
    "Carlos Vilagran",
    "Richard Grayson",
    "Bob Kane",
    "Will Farrel",
    "Lois Lane",
    "General Welling",
    "Perla Letícia",
    "Uxas",
    "Diana Prince",
    "Elisabeth Romanova",
    "Anakin Wayne"
};

    if (nomesDosEscolhidos.Count > 0)

    {
        Console.WriteLine("\n\n");
        Console.Write("Digite a palavra a ser encontrada: ");
        var busca = Console.ReadLine();

        foreach (var item in nomesDosEscolhidos)
        {
            if (item.Equals(busca))
            {
                Console.WriteLine($"Palavra encontrada = {busca}");
                break;
            }
        }
    }

    else
    {
        Console.WriteLine("Não há palavras na lista");
    }
}



#endregion

#region Criando Sistema Bancário
//Utilizando Coleções de arrays (Array list permite uma série de método com arrays, como cadastar, limpar entre outros)


//poderia utilizar o Array list porém o tipo genérico é melhor pois da mais segurança pois vai aceitar elementos do tipo definido no "<>" (No caso abaixo tipo ContaCorrente) 
//além de dar  a versatilidade do Genrics que pode ser definido o tipo no momento da utlizaçao, evitando erros.
List<ContaCorrente> _listadeContas = new List<ContaCorrente>() {
    new ContaCorrente(95, "123456-x"){Saldo=100, Titular = new Cliente("33333333333", "Victor", "Programador")}, 
    new ContaCorrente(96, "789101-y"){Saldo=200, Titular = new Cliente("44444444444", "Vivian", "Médica")}, 
    new ContaCorrente(97, "121314-z"){Saldo=300, Titular = new Cliente("55555555555", "Vinicius","Engenheiro")},
};

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
            case '3':
                RemoverContas();
                break;
            case '4':
                OrdenarContas();
                break;
            case '5':
                PesquisarContas();
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

    Console.Write("Nome do Titular: ");
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

    if (_listadeContas.Count <= 0)
    {

        Console.WriteLine("==============  Não há contas cadastradas  ================");
        Console.ReadKey();
        return;

    }
    foreach (ContaCorrente item in _listadeContas)
    {
        Console.WriteLine("==================  Dados da Conta  ====================");
        Console.WriteLine($"Número da conta:{item.Conta} ");
        Console.WriteLine($"Saldo da conta:{item.Saldo} ");
        Console.WriteLine($"Titular da conta:{item.Titular.Nome} ");
        Console.WriteLine($"CPF do titular:{item.Titular.Cpf} ");
        Console.WriteLine($"Profissão do titular:{item.Titular.Profissao} ");
        Console.WriteLine("========================================================");
        Console.ReadKey();

    }

}

void RemoverContas()
{
    Console.Clear();
    Console.WriteLine("==============================================================");
    Console.WriteLine("==================   3 - Remover Contas     ==================");
    Console.WriteLine("==============================================================");
    Console.WriteLine("\n");

    Console.Write("Informe o número da conta: ");
    string numeroConta = Console.ReadLine();
    ContaCorrente? conta = null;

    foreach(var item in _listadeContas)
    {
        if(item.Conta.Equals(numeroConta))
        {
            conta= item;
        }
    }

    if (conta != null)
    {
        _listadeContas.Remove(conta);
        Console.Write("...Conta removida com sucesso!!!");
    }
    else
    {
        Console.Write("...Conta não encontrada...");
    }
    Console.ReadKey();
}

void OrdenarContas()
{
    _listadeContas.Sort();
    Console.WriteLine("...Lista de contas ordenada...");
    Console.ReadKey();
}

void PesquisarContas()
{
    Console.Clear();
    Console.WriteLine("==============================================================");
    Console.WriteLine("=================   5 - Pesquisar Contas    ==================");
    Console.WriteLine("==============================================================");
    Console.WriteLine("\n");

    Console.Write("Deseja pesquisar por (1) NÚMERO DA CONTA ou (2)CPF TITULAR ? ");

    switch (int.Parse(Console.ReadLine()))
    {
        case 1:
            {
                Console.Write("Informe o número da conta: ");
                string _numeroConta = Console.ReadLine();
                ContaCorrente consultaConta = ConsultaPorNumeroConta(_numeroConta);
                Console.WriteLine(consultaConta.ToString()); //O método Tostring foi reescrito
                Console.ReadKey();
                break;
            }
        case 2:
            {
                Console.Write("Informe o CPF do titular: ");
                string _Cpf = Console.ReadLine();
                ContaCorrente consultaCpf = ConsultaPorCPFTitular(_Cpf);
                Console.WriteLine(consultaCpf.ToString()); //O método Tostring foi reescrito
                Console.ReadKey();
                break;
            }
    }
}



ContaCorrente ConsultaPorNumeroConta(string? numeroConta)
{
    ContaCorrente? conta = null;

    for (int i = 0; i < _listadeContas.Count; i++)
    {
        if (_listadeContas[i].Conta.Equals(numeroConta))
        {
            conta = _listadeContas[i];
        }
    }

    return conta;

    Console.ReadKey();
}

ContaCorrente ConsultaPorCPFTitular(string? cpf)
{
    ContaCorrente? conta = null;

    for (int i = 0; i < _listadeContas.Count; i++)
    {
        if (_listadeContas[i].Titular.Cpf.Equals(cpf))
        {
            conta = _listadeContas[i];
        }
    }

    return conta;

    Console.ReadKey();

}
#endregion




