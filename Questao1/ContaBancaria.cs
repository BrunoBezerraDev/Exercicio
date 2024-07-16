using System.Globalization;

namespace Questao1
{
    public class ContaBancaria
    {
        public int Numero { get; private set; }
        public string Titular { get; set; }
        private double saldo;

        //conta sem depósito inicial
        public ContaBancaria(int numero, string titular)
        {
            Numero = numero;
            Titular = titular;
        }

        //inicializar a conta com um depósito inicial
        public ContaBancaria(int numero, string titular, double depositoInicial) : this(numero, titular)
        {
            Deposito(depositoInicial);
        }

        //realizar um depósito na conta
        public void Deposito(double quantia)
        {
            saldo += quantia;  // incrementa o saldo da conta com a quantia recebida
        }

        //realizar um saque na conta
        public void Saque(double quantia)
        {
            saldo -= quantia + 3.50;  // deduz a quantia do saldo, adicionando uma taxa de saque de $3.50
        }

        //retornar o saldo atual da conta
        public double Saldo()
        {
            return saldo;
        }

        // formatar os dados da conta como uma string
        public override string ToString()
        {
            return "Conta " + Numero
                + ", Titular: " + Titular
                + ", Saldo: $ " + saldo.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
