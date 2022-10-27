using bytebank.Modelos.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank_ATENDIMENTO.bytebank.Util
{

    //classe responsável por fazer uma lista de contas. 
    public class ListaDeContasCorrentes
    {
        private ContaCorrente[] _itens = null;
        private int _proximaPosicao = 0;

        public ListaDeContasCorrentes(int tamanhoInicial=5)
        {
            _itens = new ContaCorrente[tamanhoInicial];
        }

        public void Adicionar (ContaCorrente intem)
        {
            Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");
            verificarCapacidade(_proximaPosicao + 1);
            _itens[_proximaPosicao] = intem;
            _proximaPosicao++;
        }


        

        //método para verificar se o número de contas bate com o númeoro de posições definidos no construtor do array logo acima
        //se for maior aumentará a capacidade
        private void verificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }
            Console.WriteLine("Aumentando a capacidade da lista");
            ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];

            for (int i = 0; i < _itens.Length; i++)
            {
                novoArray[i] = _itens[i];
            }

            _itens = novoArray;

        }


        //Verificando o maior saldo

       public ContaCorrente MaiorSaldo()
        {

            ContaCorrente saldo =null;
            double maiorValor = 0;
            for (int i = 0; i < _itens.Length; i++)
            {
                if (_itens[i] != null)
                {
                    if (!(maiorValor > _itens[i].Saldo))
                    {

                        saldo = _itens[i];
                    }
                }

            }

            return saldo;



        //Removendo intens da lista
        }
    }
}
