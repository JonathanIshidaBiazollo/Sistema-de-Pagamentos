using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPagamento {
    public class PagamentoDinheiro : Pagamento {
        public override void Resumo() {
            Console.WriteLine("============================");
            Console.WriteLine("Tipo de pagamento: Dinheiro");
            Console.WriteLine("Valor Original R$: {0}", ValorPagamento);
            Console.WriteLine("Desconto R$: {0}", Desconto());
            Console.WriteLine("Valor Final a ser pago R$: {0}", ValorPagamentoFinal());
            Console.WriteLine("============================");
        }
    }
}
