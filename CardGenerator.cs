using GameCardCreator.Cards;

namespace GameCardCreator
{
    internal class CardGenerator
    {
        public void CardCreator(int ano)
        {
            CardBase Card = null;
            string nome, lancamento, genero, dev, publi, d1, d2, d3, d4, d5;
            PictureBox pictureBox1 = new PictureBox();
            SolidBrush corTexto;
            Font fonte = null;
            

            switch (ano)
            {
                case 2023:
                    Card = new Card2023();
                    fonte = new("Gamestation Condensed", 16);
                    break;
                case 2024:
                    Card = new Card2024();
                    fonte = new("Gamestation Condensed", 19);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Ano não suportado");
            } 
            
            
            Console.Clear();
            Console.WriteLine("Por favor, escolha a imagem que será usada para o Card:");

            //Escolher Arquivo
            OpenFileDialog arquivo = new OpenFileDialog();
            arquivo.Filter = "Arquivos de imagem (*.jpg)(*.png)|*.jpg;*.png";
            arquivo.Title = "Escolha o Card";
            arquivo.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


            if (arquivo.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(arquivo.FileName);
            }
            //Carrega a imagem pra editar
            Graphics g = Graphics.FromImage(pictureBox1.Image);




            Console.WriteLine("Escreva o nome do Jogo:");
            nome = Console.ReadLine();

            Console.WriteLine("Escreva a Data de Lançamento do Jogo:");
            lancamento = $"Lançamento:\r\n{Console.ReadLine()}";

            Console.WriteLine("Escreva o Genero do jogo:");
            genero = $"Genero:\r\n{Console.ReadLine()}";

            Console.WriteLine("Escreva a Desenvolvedora do jogo:");
            dev = $"Desenvolvedora:\r\n{Console.ReadLine()}";

            Console.WriteLine("Escreva a Publicante do jogo:");
            publi = $"Publicante:\r\n{Console.ReadLine()}";


            Console.WriteLine("Escreva o Codigo do Disco 1:");
            d1 = Console.ReadLine();


            for (int i = 1; i <= 1; i++)
            {

                Console.WriteLine("Escreva o Codigo do Disco 2: (Pressione Enter se não houver codigo)");
                d2 = Console.ReadLine();
                if (d2 == "")
                    break;
                else
                if (ano == 2024)
                {
                    fonte = new("Gamestation Condensed", Card.tamanhoDisco);
                    g.DrawString(" | " + d2, fonte, corTexto = Card.cordisco, new PointF(Card.d2x, Card.d2y));
                }else
                g.DrawString(d2, fonte, corTexto = Card.cordisco,  new PointF(Card.d2x, Card.d2y));

                Console.WriteLine("Escreva o Codigo do Disco 3: (Pressione Enter se não houver codigo)");
                d3 = Console.ReadLine();
                if (d3 == "")
                    break;
                else
                     if (ano == 2024)
                {
                    
                    g.DrawString(" | " + d3, fonte, corTexto = Card.cordisco, new PointF(Card.d3x, Card.d3y));
                }else
                g.DrawString(d3, fonte, corTexto = Card.cordisco, new PointF(Card.d3x, Card.d3y));


                Console.WriteLine("Escreva o Codigo do Disco 4: (Pressione Enter se não houver codigo)");
                d4 = Console.ReadLine();
                if (d4 == "")
                    break;
                else
                     if (ano == 2024)
                {
                    
                    g.DrawString(" | " + d4, fonte, corTexto = Card.cordisco, new PointF(Card.d4x, Card.d4y));
                }else
                g.DrawString(d4, fonte, corTexto = Card.cordisco, new PointF(Card.d4x, Card.d4y));

                Console.WriteLine("Escreva o Codigo do Disco 5: (Pressione Enter se não houver codigo)");
                d5 = Console.ReadLine();
                if (d5 == "")
                    break;
                else
                     if (ano == 2024)
                {
                    
                    g.DrawString(" | " + d5, fonte, corTexto = Card.cordisco, new PointF(Card.d5x, Card.d5y));
                }else
                g.DrawString(d5, fonte, corTexto = Card.cordisco, new PointF(Card.d5x, Card.d5y));
            }

            
            g.DrawString(nome, fonte = new("Gamestation Condensed", Card.tamanhoFonte), corTexto = Card.cornome, new PointF(Card.nomex, Card.nomey));
            g.DrawString(lancamento, fonte, corTexto = Card.corinfo, new PointF(Card.lancax, Card.lancay));
            g.DrawString(genero, fonte, corTexto, new PointF(Card.generox, Card.generoy));
            g.DrawString(dev, fonte, corTexto, new PointF(Card.devx, Card.devy));
            g.DrawString(publi, fonte, corTexto, new PointF(Card.publix, Card.publiy));
            if (ano == 2024)
            {
               fonte = new ("Gamestation Condensed", Card.tamanhoDisco);
            }
            g.DrawString(d1, fonte, corTexto = Card.cordisco, new PointF(Card.d1x, Card.d1y));

            Console.WriteLine("Por favor seclecione a imagem para a Capa do Jogo:");
            OpenFileDialog arquivo2 = new OpenFileDialog();
            arquivo2.Filter = "Arquivos de imagem (*.jpg)(*.png)|*.jpg;*.png";
            arquivo2.Title = "Escolha a Capa do jogo";


            if (arquivo2.ShowDialog() == DialogResult.OK)
            {
                Image imagemFundo = pictureBox1.Image;
                Image imagemSobreposta = Image.FromFile(arquivo2.FileName);

                Image imagemRedimensionada = imagemSobreposta.GetThumbnailImage(Card.capalargura, Card.capaaltura, null, IntPtr.Zero);

                using (g = Graphics.FromImage(imagemFundo))
                {
                    Point posicao = new Point(Card.posicaox, Card.posicaoy);

                    g.DrawImage(imagemRedimensionada, posicao);
                }
            }

            SaveFileDialog salvarArquivo = new SaveFileDialog();
            salvarArquivo.Filter = "Arquivos de imagem (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp";
            salvarArquivo.Title = "Escolha onde salvar o Card:";

            if (salvarArquivo.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Image.Save(salvarArquivo.FileName);
            } 
        }

    }
}
