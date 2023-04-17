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
            PictureBox pictureBox1 = new PictureBox();
            // Carrega a imagem em um controle PictureBox
            pictureBox1.Image = Image.FromFile("imagem.jpg");

            // Cria um objeto Graphics para desenhar na imagem
            Graphics g = Graphics.FromImage(pictureBox1.Image);

            // Define as propriedades do objeto Graphics
            Font fonte = new Font("Arial", 20);
            SolidBrush corTexto = new SolidBrush(Color.White);

            // Desenha o texto na imagem
            g.DrawString("Texto de exemplo", fonte, corTexto, new PointF(10, 10));

            // Salva a imagem atualizada em um arquivo
            pictureBox1.Image.Save("imagem_com_texto.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            // Exibe a imagem novamente no controle PictureBox
            pictureBox1.Refresh();

        }
    }
}