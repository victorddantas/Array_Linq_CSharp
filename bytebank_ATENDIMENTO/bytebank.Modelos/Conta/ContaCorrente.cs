namespace bytebank.Modelos.Conta
{
    public class ContaCorrente : IComparable<ContaCorrente> //NECESSÁRIO PARA UTILIZAÇÃO DO MÉTODO SORT (ORDENADÇÃO DAS CONTAS)
    {

        public Cliente Titular { get; set; }
        public string Nome_Agencia { get; set; }

        private int _numero_agencia;
        public int Numero_agencia
        {
            get
            {
                return _numero_agencia;
            }
            set
            {
                if (value <= 0)
                {

                }
                else
                {
                    _numero_agencia = value;
                }
            }

        }

        private string _conta;
        public string Conta
        {
            get
            {
                return _conta;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                else
                {
                    _conta = value;
                }
            }
        }

        private double saldo;
        public double Saldo
        {
            get
            {
                return saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }
                else
                {
                    saldo = value;
                }
            }
        }

        public bool Sacar(double valor)
        {
            if (saldo < valor)
            {
                return false;
            }
            if (valor < 0)
            {
                return false;
            }
            else
            {
                saldo = saldo - valor;
                return true;
            }
        }

        public void Depositar(double valor)
        {
            if (valor < 0)
            {
                return;
            }
            saldo = saldo + valor;
        }

        public bool Transferir(double valor, ContaCorrente destino)
        {
            if (saldo < valor)
            {
                return false;
            }
            if (valor < 0)
            {
                return false;
            }
            else
            {
                saldo = saldo - valor;
                destino.saldo = destino.saldo + valor;
                return true;
            }
        }


        //MÉTODO DA INTERFACE UTILIZADA IComparable<ContaCorrente>
        public int CompareTo(ContaCorrente? other)
        {
            if (other == null)
            {
               return 1;
            }
            else
            {
                return this.Numero_agencia.CompareTo(other.Numero_agencia); // ordenando pelo número da agência
            }
        }

        public ContaCorrente(int numero_agencia, string conta)
        {
            Numero_agencia = numero_agencia;
            Conta = conta;
            Titular = new Cliente();
            TotalDeContasCriadas += 1;

        }

        public static int TotalDeContasCriadas { get; set; }

        //public override bool Equals(object? conta)
        //{
        //    ContaCorrente outroConta = conta as ContaCorrente;

        //    if (outroConta == null)
        //    {
        //        return false;
        //    }

        //    return Numero_agencia == outroConta.Numero_agencia && 
        //        Conta.Equals(outroConta.Conta);
        //}



        //sobreescrevendo o método to string para exibir as informções da conta no método de pesquisa
        public override string ToString()
        {
            return $"\n========= DADOS DA CONTA =========\n" +
                   $"Número da Conta: {this.Conta}\n" +
                   $"Saldo da conta: {this.Saldo}\n" +
                   $"Titular da conta: {this.Titular.Nome}\n" +
                   $"CPF do Titular: {this.Titular.Cpf}\n" +
                   $"Profissão do Titular: {this.Titular.Profissao}\n";
        }
    }
}