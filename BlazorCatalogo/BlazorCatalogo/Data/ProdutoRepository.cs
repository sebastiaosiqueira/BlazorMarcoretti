namespace BlazorCatalogo.Data
{
    public class ProdutoRepository
    {
        private readonly List<Produto> _produtos =
    [
        new Produto
        {
            Id = 1,
            Nome = "Notebook Pro X",
            Descricao = "Notebook de alto desempenho para trabalho e estudos.",
            Preco = 7999,
            ImagemUrl = "imagens/notebook.jpg",
            DocumentoInformacoes = """
            Produto: Notebook Pro X

            Categoria: Notebook profissional de alto desempenho.

            Especificações Técnicas:
            Processador: Intel Core i7 12ª geração
            Memória RAM: 16 GB DDR5
            Armazenamento: SSD NVMe 1 TB
            Tela: 15.6 polegadas Full HD
            Placa de vídeo: NVIDIA RTX 3050
            Sistema Operacional: Windows 11 Pro

            Bateria:
            Duração média: 8 horas de uso moderado.

            Conectividade:
            Wi-Fi 6
            Bluetooth 5.2

            Portas:
            2 portas USB-A
            2 portas USB-C
            1 porta HDMI
            1 entrada para fone de ouvido

            Características adicionais:
            Teclado retroiluminado
            Leitor de impressão digital
            Webcam HD integrada

            Dimensões e peso:
            Peso: 1.8 kg
            Espessura: 18 mm

            Estoque/Unidades:
            Unidades disponíveis: 15

            Cores disponíveis:
            Preto
            Prata

            Personalização:
            Não é possível personalizar este produto.

            Garantia:
            1 ano de garantia do fabricante.

            Prazo de envio:
            3 dias úteis após confirmação do pagamento.
            """
        },

        new Produto
        {
            Id = 2,
            Nome = "Mouse Precision MX",
            Descricao = "Mouse sem fio ergonômico para produtividade.",
            Preco = 249,
            ImagemUrl = "imagens/mouse.jpg",
            DocumentoInformacoes = """
            Produto: Mouse Precision MX

            Categoria:
            Mouse sem fio para uso profissional e doméstico.

            Tipo de conexão:
            Bluetooth
            Receptor USB 2.4GHz

            Compatibilidade:
            Windows
            macOS
            Linux

            Sensor:
            Sensor óptico de alta precisão
            DPI ajustável até 4000 DPI

            Botões:
            6 botões programáveis
            Scroll inteligente

            Alimentação:
            Bateria recarregável interna.

            Autonomia da bateria:
            Até 70 dias com carga completa.

            Tempo de recarga:
            Aproximadamente 2 horas.

            Conector de recarga:
            USB-C

            Características ergonômicas:
            Design ergonômico para uso prolongado.

            Peso:
            135 gramas

            Cores disponíveis:
            Preto
            Cinza grafite

            Estoque/Unidades disponível:
            40 unidades

            Personalização:
            É possível configurar botões usando software do fabricante.

            Garantia:
            2 anos de garantia.

            Prazo de envio:
            Envio em até 2 dias úteis.
            """
        },

        new Produto
        {
            Id = 3,
            Nome = "Monitor LED 15\" Vision",
            Descricao = "Monitor compacto ideal para escritório e uso doméstico.",
            Preco = 899,
            ImagemUrl = "imagens/monitor.jpg",
            DocumentoInformacoes = """
            Produto: Monitor LED 15 Vision

            Categoria:
            Monitor LED compacto para escritório.

            Tamanho da tela:
            15 polegadas

            Resolução:
            Full HD (1920 x 1080)

            Tipo de painel:
            IPS

            Taxa de atualização:
            75 Hz

            Tempo de resposta:
            5 ms

            Brilho:
            250 nits

            Conectividade:
            HDMI
            VGA

            Ajustes disponíveis:
            Inclinação ajustável.

            Consumo de energia:
            18W em uso normal.

            Peso:
            2.3 kg

            Cores disponíveis:
            Preto

            Itens inclusos:
            Cabo HDMI
            Fonte de alimentação
            Manual do usuário

            Estoque/Unidades disponível:
            22 unidades

            Personalização:
            Não possui opções de personalização.

            Garantia:
            1 ano de garantia do fabricante.

            Prazo de envio:
            4 dias úteis.
            """
        }
    ];

        public List<Produto> ObterTodos() => _produtos;

        public Produto? ObterPorId(int id)
            => _produtos.FirstOrDefault(p => p.Id == id);
    }
}