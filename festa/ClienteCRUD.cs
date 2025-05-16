public class ClienteCRUD {

    // atributos 

    private List<ClienteDTO> listaClientes;
    private ClienteDTO cliente;
    private Tela tela;

    public ClienteCRUD()
    {
        this.listaClientes = new List<ClienteDTO>();
        this.cliente = new ClienteDTO(0,"","","");
        this.tela = new Tela();

    }


    public void executarCRUD(){

        //montar telado crud 
        this.montarTelaCliente();
        /*
        logica possivel para o crud 
        ---------------------------
        1 - montar a tela do crud 
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

    private void montarTelaCliente(){

        int coluna, linha;
        coluna = 30;
        linha = 5;
        int coluna2 = coluna+30;


        this.tela.desenharMoldura(coluna,linha,coluna2,linha+6);

        linha++;
        this.tela.centralizar("cadastro de cliente", 6,30,60);
        linha++;

        coluna++;
        Console.SetCursorPosition(31,7);
        Console.Write("Codigo     :");
        linha++;

        Console.SetCursorPosition(31,8);
        Console.Write("Nome       :");
        linha++;

        Console.SetCursorPosition(31,9);
        Console.Write("Email      :");
        linha++;

        Console.SetCursorPosition(31,10);
        Console.Write("Telefone   :");
        linha++;
    }
}