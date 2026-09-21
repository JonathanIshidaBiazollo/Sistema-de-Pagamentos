using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPagamento {
    public abstract class PagamentoCartao : Pagamento {
        public string UltimosDigitos {  
            get;
            set; 
        }
    }
}
