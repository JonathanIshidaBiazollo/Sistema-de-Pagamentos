//Jonathan Ishida Biazollo
//2032320
//BCC4B
//Plataforma de desenvolvimento de sistemas
//Rodrigo Gonçalves ROdrigues

using SistemaPagamento;

List<Pagamento> pagamentos = new List<Pagamento>();
PagamentoCartao cartao;

int op = 0;
int opPagamento = 0;
bool validar = true;
decimal valor = 0;
bool valorValido = false;
string digitos = "";
bool digitosValido = false;

do {
    Console.WriteLine("=================================");
    Console.WriteLine("Selecione uma das opções abaixo: ");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("1 - Informar pagamento");
    Console.WriteLine("2 - Listar Pagamentos");
    Console.WriteLine("=================================");
    validar = int.TryParse(Console.ReadLine(), out op);

    if (!validar) {
        Console.Clear();
        Console.WriteLine("Opção inválida, tente novamente por favor: ");
        op = -1;
    }

    switch (op) {
        case 0:
            Console.WriteLine("Sistema finalizado, volte sempre...");
            break;
        case 1:
            do {
                Console.WriteLine("=================================");
                Console.WriteLine("Selecione a forma de pagamento: ");
                Console.WriteLine("0 - Voltar");
                Console.WriteLine("1 - Dinheiro");
                Console.WriteLine("2 - Cartão de Débito");
                Console.WriteLine("3 - Cartão de Crédito");
                Console.WriteLine("=================================");
                validar = int.TryParse(Console.ReadLine(), out opPagamento);

                if (!validar) {
                    Console.Clear();
                    Console.WriteLine("Opção inválida, tente novamente por favor: ");
                    opPagamento = -1;
                }
            }while (opPagamento < 0 || opPagamento > 3);

            if(opPagamento == 0) {
                break;
            } else {
                do {
                    Console.Write("Valor a ser Pago: R$");
                    valorValido = decimal.TryParse(Console.ReadLine(), out valor);

                    if (!valorValido || valor <= 0) {
                        Console.WriteLine("Valor inválido, somente valores numéricos e maiores que zero");
                        valorValido = false;
                    }
                 }while(!valorValido);

                if (opPagamento == 1) {
                    PagamentoDinheiro dinheiro = new PagamentoDinheiro();
                    dinheiro.ValorPagamento = valor;

                    pagamentos.Add(dinheiro);

                    dinheiro.Resumo();
            
                }else if(opPagamento == 2 || opPagamento == 3) {
                    do {

                        Console.WriteLine("Digite os 4 últimos dígitos do cartão: ");
                        digitos = Console.ReadLine();
                    
                        digitosValido = digitos.Length == 4 && digitos.All(char.IsDigit);

                        if (!digitosValido) {
                            Console.WriteLine("Digite somente números e no máximo 4");
                        }

                    } while(!digitosValido);

                    if (opPagamento == 2) {

                        cartao = new PagamentoDebito();

                    }else{

                        cartao = new PagamentoCredito();

                    } 

                    cartao.ValorPagamento = valor;
                    cartao.UltimosDigitos = digitos;

                    pagamentos.Add(cartao);

                    cartao.Resumo() ;
                }
            }

            break; 

        case 2:
            Console.Clear();
            if(pagamentos.Count == 0) {
                Console.WriteLine("Nenhum pagamento cadastrado");
            } else {
                foreach(Pagamento pagamento in pagamentos) {
                    pagamento.Resumo();
                }
            }
            
            break;
        default:
            break;
    }

} while (op != 0);