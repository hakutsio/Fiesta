public class ClienteCRUD {

    // atributos 

    private List<ClienteDTO> listaClientes;  // banco de dados 
    private ClienteDTO cliente;             // cliente "da vez"
    private Tela tela;
    private int linCodigo, colCodigo;
    private int posicao;

    public ClienteCRUD()
    {
        this.listaClientes = new List<ClienteDTO>();
        this.tela = new Tela();
    }


    public void executarCRUD(){

        //1 - montar telado crud 
        this.montarTelaCliente(15,5);

        // preparar um registro em banco de cliente
        this.cliente = new ClienteDTO();

        // 2 - perguntar ao usuario o código do cliente 
        this.entrarDados(1);

        // 3 - procurar pela chave no "banco de dados" (lista de clientes)
        bool achou = this.buscarCodigo();

        // se não achou a chave no banco de dados 
        if (!achou)
        {
            //4.1 - informar que não achou 
            this.tela.centralizar("Cliente não encontrado. Deseja cadastrar (S/N)", 24, 0, 80);

            // 4.2 - perguntar se deseja cadastrar 
            string resp = Console.ReadLine();

            // 4.3 - se o usuario informar que deseja cadastrar
            if (resp.ToLower() == "s")
            {

                //4.3.1 - perguntar os dados restates ao usuario
                this.entrarDados(2);

                // 4.3.2 - perguntar se o usuario confirma o cadastro 
                this.tela.centralizar("Confirma cadastro (S/N): ", 24, 0, 80);
                resp = Console.ReadLine();

                // 4.3.3 - se o usuario confirmar 
                if (resp.ToLower() == "s")
                {
                    // 4.3.3.1 - realizar a inclusão do novo cliente 
                    this.listaClientes.Add(this.cliente);
                }
            }
        }

        // 5 - se achou a chave no banco de dados
        else
        {
            // codigos 5.1 em diante
            this.mostrarDados();

            // codigo 5.2 perguntar ao usuario se ele deseja voltar, alterar ou excluir 
            this.tela.centralizar("o asno deseja voltar/Alterar/Excluir (V/A/E) : ", 24, 0, 80);
            string resp = Console.ReadLine();

            // 5.3 se o usuario deseja alterar 
            if (resp.ToLower() == "a")
            {

            }
            if (resp.ToLower() == "e")
            {
                
            }
        }
        /*
        logica possivel para o crud 
        ---------------------------
        1 - montar a tela do crud --> ok
        2 - perguntar ao usuario a chave do cliente 
        3 - procurar pela chave no "banco de dados"(listaCLientes)
        4 - se não achou a chave no banco de dados
            4.1 - informar que não achou 
            4.2 - perguntar se deseja cadastrar 
            4.3 se i usuario informar que deseja cadastrar
                4.3.1 - perguntar os dados restantes ao usuario 
                4.3.2 - perguntar se o usuario confirma o cadastrro 
                4.3.3 - se o usuario confirmar 
                    4.3.3.1 - realizar a inclusão do novo cliente 
        5 - se achou a chave no banco de dados 
            5.1 - mostrar os dados na tela 
            5.2 - perguntar ao usuario se deseha voltar, alterar ou exckuir 
            5.3 - se o usuario informou que deseja alterar 
                5.3.1 - perguntar os novos dados para o usuario 
                5.3.2 - perguntar se o usuario confirma a alteração 
                5.3.3 - se o usuario confirmou a alteração 
                    5.3.3.1 - gravar a alteração dis dadis di ckuebte 
            5.4 - se o usuario informou que deseja excluir 
                5.4.1 - pguntar se o usuario confirma a exclusão 
                5.4.2 - se o usuario confirmou a exclusão
                    5.4.2.1  excluir cadastro.

                    cada passo listado acima ou vai ser uma chamada para um metodo ou vai ser um if.
        */
    }

/*
    private void montarTelaCliente(int coluna, int linha){


        int coluna2 = coluna+30;

        this.tela.desenharMoldura(coluna,linha,coluna2,linha+6);

        linha++;
        this.tela.centralizar("cadastro de cliente", 6,30,60);

        linha++;
        coluna++;
        Console.SetCursorPosition(31,7);
        Console.Write("Codigo     :");

        Console.SetCursorPosition(31,8);
        Console.Write("Nome       :");
        linha++;

        Console.SetCursorPosition(31,9);
        Console.Write("Email      :");
        linha++;

        Console.SetCursorPosition(31,10);
        Console.Write("Telefone   :");
    }
*/

    private bool buscarCodigo(){

        bool encontrei = false ;
        for(int i =0; i<this.listaClientes.Count; i++){
            if(this.listaClientes[i].Codigo == this.cliente.Codigo){
                encontrei = true;
                this.posicao = i;
                break;
            }
        }
        return encontrei;
    }

    private void mostrarDados()
    {
        Console.SetCursorPosition(colCodigo, linCodigo+1);
        Console.Write(this.listaClientes[this.posicao].Nome);

        Console.SetCursorPosition(colCodigo, linCodigo+2);
        Console.Write(this.listaClientes[this.posicao].Email);

        Console.SetCursorPosition(colCodigo, linCodigo+3);
        Console.Write(this.listaClientes[this.posicao].Telefone);
    }
    
    private void montarTelaCliente(int coluna, int linha)
    {

        int coluna2 = coluna + 30;
        List<string> cadCliente = new List<string>();
        cadCliente.Add("Código   :");
        cadCliente.Add("Nome     :");
        cadCliente.Add("Email    :");
        cadCliente.Add("Telefone :");

        this.tela.desenharMoldura(coluna, linha, coluna2, linha + 6);
        linha++;
        this.tela.centralizar("cadastro de cliente", linha, coluna, coluna2);

        coluna++;
        linha++;

        this.linCodigo = linha;
        this.colCodigo = coluna + cadCliente[0].Length;

        for (int i = 0; i < cadCliente.Count; i++)
        {
            Console.SetCursorPosition(coluna, linha);
            Console.Write(cadCliente[i]);
            linha++;
        }
    }

    private void entrarDados(int qual){
        // entrada de código (chave primaria / identificador único)
        if(qual == 1){
            Console.SetCursorPosition(colCodigo, linCodigo);
            this.cliente.Codigo = int.Parse(Console.ReadLine());
        }

        // entrada de dados do registro 
        if(qual == 2){
            Console.SetCursorPosition(colCodigo, linCodigo+1);
            this.cliente.Nome = Console.ReadLine();

            Console.SetCursorPosition(colCodigo, linCodigo+2);
            this.cliente.Email = Console.ReadLine();

            Console.SetCursorPosition(colCodigo, linCodigo+3);
            this.cliente.Telefone = Console.ReadLine();

        }
    }

}

