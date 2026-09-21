using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPagamento {
    public class PagamentoCredito : PagamentoCartao{


        public override decimal Desconto() {
            return ValorPagamento * 10/100;
        }

        public override void Resumo() {
            Console.WriteLine("============================");
            Console.WriteLine("Tipo de pagamento: Crédito");
            Console.WriteLine("Ultímos dígitos do cartão: {0}", UltimosDigitos);
            Console.WriteLine("Valor Original R$: {0}", ValorPagamento);
            Console.WriteLine("Desconto R$: {0}", Desconto());
            Console.WriteLine("Valor Final a ser pago R$: {0}", ValorPagamentoFinal());
            Console.WriteLine("============================");
        }
    }
}
