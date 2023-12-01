namespace GameCardCreator
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            CardGenerator cards = new CardGenerator();
            int ano;
          

            //intro
            Console.WriteLine("Bem vindo ao GameCardCreator");
            Console.WriteLine("Esse software serve para Criar cards de jogos de PS1 para o PS vita");
            Console.WriteLine("Por favor Escolha o Ano do Card que você quer fazer: (1 - 2022 e 2 - 2023)");

            ano = Convert.ToInt32(Console.ReadLine());
            if (ano == 1)
            {
                cards.CardCreator(2022);
            }
         
        }
    }
}