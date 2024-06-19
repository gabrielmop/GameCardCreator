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
            Console.WriteLine("Por favor Escolha o Ano do Card que você quer fazer: (1 - 2023 e 2 - 2024)");

            ano = Convert.ToInt32(Console.ReadLine());

            switch (ano)

            {
                case 1:
                    cards.CardCreator(2023);
                    break;
                case 2:
                    cards.CardCreator(2024);
                    break;
            };


        }
    }
}