using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Util;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");


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


//Criando array utilizando a classe Array 

Array amostra = Array.CreateInstance(typeof(double), 5);
amostra.SetValue(5.9,0);
amostra.SetValue(1.8,1);
amostra.SetValue(7.1,2);
amostra.SetValue(10,3);
amostra.SetValue(6.9,4);


//TestaMediana(amostra);

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

//Array de Objetos 

//testaArrayDeContaCorrente();

void testaArrayDeContaCorrente()
{
    ContaCorrente[] contaCorrentes = new ContaCorrente[]
    {
        new ContaCorrente(874, "444444444", 890.00),
        new ContaCorrente(339, "444444444", 4000.00),
        new ContaCorrente(224, "444444444", 9000.00),
        new ContaCorrente(372, "444444444", 1000.00)

    };

    for (int i = 0; i < contaCorrentes.Length; i++)
    {
        ContaCorrente contaAtual = contaCorrentes[i];
        Console.WriteLine($"Indice {i}- Conta: {contaAtual.Conta} e Agencia: {contaAtual.Numero_agencia}");
    }   

    
}

//Array de Objetos a partir da classe
testaArrayDeContaCorrente2();

void testaArrayDeContaCorrente2()
{
    ListaDeContasCorrentes listaDeContasCorrentes = new ListaDeContasCorrentes();

    listaDeContasCorrentes.Adicionar(new ContaCorrente(874, "444444444", 890000.00));
    listaDeContasCorrentes.Adicionar(new ContaCorrente(339, "444444444", 4000.00));
    listaDeContasCorrentes.Adicionar(new ContaCorrente(224, "444444444", 9000.00));
    listaDeContasCorrentes.Adicionar(new ContaCorrente(372, "22222222", 2000.00));
    listaDeContasCorrentes.Adicionar(new ContaCorrente(372, "22222222", 4000.00));


    ContaCorrente conta = listaDeContasCorrentes.MaiorSaldo();
    Console.WriteLine($"A conta com maior saldo é: {conta.Saldo}");

};






//Retorna comta com maior saldo

