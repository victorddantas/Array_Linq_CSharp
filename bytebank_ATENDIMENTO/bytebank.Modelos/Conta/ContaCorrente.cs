namespace bytebank.Modelos.Conta
{
    public class ContaCorrente
    {
        private int _numero_agencia;

        private string _conta;

        private double _saldo;

        public Cliente Titular { get; set; }

        public string Nome_Agencia { get; set; }

        public int Numero_agencia
        {
            get
            {
                return _numero_agencia;
            }
            set
            {
                if (value > 0)
                {
                    _numero_agencia = value;
                }
            }
        }

        public string Conta
        {
            get
            {
                return _conta;
            }
            set
            {
                if (value != null)
                {
                    _conta = value;
                }
            }
        }

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (!(value < 0.0))
                {
                    _saldo = value;
                }
            }
        }

        public static int TotalDeContasCriadas { get; set; }

        public bool Sacar(double valor)
        {
            if (_saldo < valor)
            {
                return false;
            }
            if (valor < 0.0)
            {
                return false;
            }
            _saldo -= valor;
            return true;
        }

        public void Depositar(double valor)
        {
            if (!(valor < 0.0))
            {
                _saldo += valor;
            }
        }

        public bool Transferir(double valor, ContaCorrente destino)
        {
            if (_saldo < valor)
            {
                return false;
            }
            if (valor < 0.0)
            {
                return false;
            }
            _saldo -= valor;
            destino._saldo += valor;
            return true;
        }

        public ContaCorrente(int numero_agencia, string conta)
        {
            Numero_agencia = numero_agencia;
            Conta = conta;
            //Saldo = saldo;
            Titular = new Cliente();
            TotalDeContasCriadas += 1;

        }

        public override string ToString()
        {

            return $" === DADOS DA CONTA === \n" +
                   $"Número da Conta : {this.Conta} \n" +
                   $"Titular da Conta: {this.Titular.Nome} \n" +
                   $"CPF do Titular  : {this.Titular.Cpf} \n" +
                   $"Profissão do Titular: {this.Titular.Profissao}";
        }


    }

}