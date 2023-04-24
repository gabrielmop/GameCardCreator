using System.ComponentModel.Design;
using System.Windows.Forms;

namespace GameCardCreator
{
    internal static class Program 
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string nome, lancamento, genero, dev, publi, d1, d2, d3, d4, d5;
            PictureBox pictureBox1 = new PictureBox();
            
            int tamanho = 19;
            Font fonte = new("Gamestation Condensed", tamanho);
            SolidBrush corTexto = new SolidBrush(Color.White);
          

            //intro
            Console.WriteLine("Bem vindo ao GameCardCreator");
            Console.WriteLine("Esse software serve para Criar cards de jogos de PS1 para o PS vita");
            Console.WriteLine("Por favor, escolha a imagem que será usada para o Card:");

            //Escolher Arquivo
            OpenFileDialog arquivo = new OpenFileDialog();
            arquivo.Filter = "Arquivos de imagem (*.jpg)(*.png)|*.jpg";
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
            tamanho = 19;

            Console.WriteLine("Escreva o Genero do jogo:");
            genero = $"Genero:\r\n{Console.ReadLine()}";

            Console.WriteLine("Escreva a Desenvolvedora do jogo:");
            dev = $"Genero:\r\n{Console.ReadLine()}";

            Console.WriteLine("Escreva a Publicante do jogo:");
            publi = $"Genero:\r\n{Console.ReadLine()}";
            
            
            Console.WriteLine("Escreva o Codigo do Disco 1:");
            d1 = Console.ReadLine();
            
            Console.WriteLine("Escreva o Codigo do Disco 2: (Pressione Enter se não houver codigo)");
            d2 = Console.ReadLine();
            
            Console.WriteLine("Escreva o Codigo do Disco 3: (Pressione Enter se não houver codigo)");
            d3 = Console.ReadLine();
            
            Console.WriteLine("Escreva o Codigo do Disco 4: (Pressione Enter se não houver codigo)");
            d4 = Console.ReadLine();
           
            Console.WriteLine("Escreva o Codigo do Disco 5: (Pressione Enter se não houver codigo)");
            d5 = Console.ReadLine();


            if (nome.Length >= 27)
            {
                tamanho = 14;
            }
            g.DrawString(nome, fonte, corTexto, new PointF(560, 74));
            if (tamanho == 14)
            {
                tamanho = 19;
            }           
            g.DrawString(lancamento, fonte, corTexto, new PointF(555, 120));
            g.DrawString(genero, fonte, corTexto, new PointF(555, 210));
            g.DrawString(dev, fonte, corTexto, new PointF(555, 295));
            g.DrawString(publi, fonte, corTexto, new PointF(555, 385));
            tamanho = 18;
            corTexto = new SolidBrush(Color.Black);
            g.DrawString(d1, fonte, corTexto, new PointF(180, 371));
            g.DrawString(d2, fonte, corTexto, new PointF(180, 397));
            g.DrawString(d3, fonte, corTexto, new PointF(180, 423));
            g.DrawString(d4, fonte, corTexto, new PointF(180, 448));
            g.DrawString(d5, fonte, corTexto, new PointF(180, 472));

            Console.WriteLine("Por favor seclecione a imagem para a Capa do Jogo:");
            OpenFileDialog arquivo2 = new OpenFileDialog();
            arquivo.Filter = "Arquivos de imagem (*.jpg)(*.png)|*.jpg";
            arquivo.Title = "Escolha a Capa do jogo";


            if (arquivo2.ShowDialog() == DialogResult.OK)
            {
                // Carrega as imagens
                Image imagemFundo = pictureBox1.Image;
                Image imagemSobreposta = Image.FromFile(arquivo2.FileName);

                // Define o tamanho da imagem sobreposta redimensionada
                int largura = 495;
                int altura = 338;

                // Cria uma miniatura da imagem sobreposta com o tamanho desejado
                Image imagemRedimensionada = imagemSobreposta.GetThumbnailImage(largura, altura, null, IntPtr.Zero);

                // Cria um objeto Graphics a partir da imagem de fundo
                using (g = Graphics.FromImage(imagemFundo))
                {
                    // Define a posição em que a imagem sobreposta será desenhada
                    Point posicao = new Point(32, 22);

                    // Desenha a imagem sobreposta redimensionada na posição definida
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