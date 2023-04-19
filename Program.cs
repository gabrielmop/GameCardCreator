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
            int tamanho = 20;
            Font fonte = new("zrnic rg", tamanho);
            SolidBrush corTexto = new SolidBrush(Color.White);
          


            Console.WriteLine("Bem vindo ao GameCardCreator");
            Console.WriteLine("Esse software serve para Criar cards de jogos de PS1 para o PS vita");
            Console.WriteLine("Por favor, escolha a imagem que será usada para o Card:");

            OpenFileDialog arquivo = new OpenFileDialog();
            arquivo.Filter = "Arquivos de imagem (*.jpg)(*.png)|*.jpg";
            arquivo.Title = "Escolha um arquivo de imagem";

            if (arquivo.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(arquivo.FileName);
            }

            Graphics g = Graphics.FromImage(pictureBox1.Image);

            Console.WriteLine("Escreva o nome do Jogo");
            nome = Console.ReadLine();

            if (nome.Length >= 27)
            {
                tamanho = 14;
            }
           
            g.DrawString(nome, fonte, corTexto, new PointF(560, 71));

            Console.WriteLine("Escreva a Data de Lançamento do Jogo");
            lancamento = $"Lançamento:{Environment.NewLine} {Console.ReadLine()}";
            tamanho = 20;

            g.DrawString(lancamento, fonte, corTexto, new PointF(555, 110));




            pictureBox1.Image.Save("imagem_com_texto.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            

        }
    }
}