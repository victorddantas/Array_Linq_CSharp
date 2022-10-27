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

            ContaCorrente saldo = null;
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
        }


        //Exibindo um array 

        public void ExibeLista()
        {
            for (int i = 0; i < _itens.Length; i++)
            {
                if (_itens[i] != null)
                {
                    var conta = _itens[i];
                    Console.WriteLine($"Indice [{i}] = Conta: {conta.Conta} - Nº da Agência: {conta.Numero_agencia}");
                }
            }
        }

        //Removendo itens da lista

            public void Remover (ContaCorrente conta)
            {
                int indiceItem = -1;
                for (int i = 0 ; i < _proximaPosicao; i++)
                {
                    ContaCorrente contaAtual = _itens[i];
                    if (contaAtual == conta)
                    {
                        indiceItem = i;
                        break;
                    }
                }

                for   (int i = indiceItem; i < _proximaPosicao-1; i++)
                {
                    _itens[i] = _itens[i + 1];


                }

                _proximaPosicao--;
                _itens[_proximaPosicao] = null;
            }


        }
    }

