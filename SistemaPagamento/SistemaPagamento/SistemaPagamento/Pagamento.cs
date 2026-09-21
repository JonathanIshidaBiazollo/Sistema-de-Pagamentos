using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPagamento {
    public abstract class Pagamento {
        public decimal ValorPagamento {
            get;
            set; 
        }

        public virtual decimal Desconto() {
            return 0;
        }

        public decimal ValorPagamentoFinal() {
            return ValorPagamento - Desconto();
        }

        public abstract void Resumo();

    }
}
