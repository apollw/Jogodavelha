using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    class Program
    {
        static void Main(string[] args)
        {
            int player = 2; //Jogador 1 começa
            int input = 0;
            bool inputCorrect = true;

            //Roda o código enquanto o programa é executado
            do
            {

                if (player == 2){ 
                    player = 1;
                    EnterXorO(player, input);
                }
                else if (player == 1){
                    player = 2;
                    EnterXorO(player, input);
                }

                SetField();

                #region
                //Checando a condição de vitória
                char[] playerChars = {'X','O'};

                foreach(char playerChar in playerChars)
                {
                    if (((playfield[0, 0] == playerChar) && (playfield[0, 1] == playerChar) && (playfield[0,2]==playerChar))
                        || (playfield[1, 0] == playerChar) && (playfield[1, 1] == playerChar) && (playfield[1, 2] == playerChar)
                        || (playfield[2, 0] == playerChar) && (playfield[2, 1] == playerChar) && (playfield[2, 2] == playerChar)
                        || (playfield[0, 0] == playerChar) && (playfield[1, 0] == playerChar) && (playfield[2, 0] == playerChar)
                        || (playfield[0, 1] == playerChar) && (playfield[1, 1] == playerChar) && (playfield[2, 1] == playerChar)
                        || (playfield[0, 2] == playerChar) && (playfield[2, 1] == playerChar) && (playfield[2, 2] == playerChar)
                        || (playfield[0, 0] == playerChar) && (playfield[1, 1] == playerChar) && (playfield[2, 2] == playerChar)
                        || (playfield[0, 2] == playerChar) && (playfield[1, 1] == playerChar) && (playfield[2, 0] == playerChar)
                        
                    )
                    {
                        if(playerChar =='X')
                            Console.WriteLine("Jogador 2 ganhou");
                        else if(playerChar == 'O')
                            Console.WriteLine("Jogador 1 ganhou");

                        Console.WriteLine("Aperte qualquer teclar para reiniciar o jogo");
                        Console.ReadKey();
                        ResetField();
                        break;
                    }
                    else if(turns==10)
                    {
                        Console.WriteLine("EMPATE");
                        Console.WriteLine("Aperte qualquer teclar para reiniciar o jogo");
                        Console.ReadKey();
                        ResetField();
                        break;
                    }
                }
                #endregion

                #region
                //Testa se o campo já foi utilizado
                do
                {
                    Console.Write("\nJogador {0}: Escolha uma posição! ", player);
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());

                    }
                    catch
                    {
                        Console.WriteLine("Por favor, insira um número válido");
                    }

                    if ((input == 1) && (playfield[0, 0] == '1'))
                        inputCorrect = true;
                    else if ((input == 2) && (playfield[0, 1] == '2'))
                        inputCorrect = true;
                    else if ((input == 3) && (playfield[0, 2] == '3'))
                        inputCorrect = true;
                    else if ((input == 4) && (playfield[1, 0] == '4'))
                        inputCorrect = true;
                    else if ((input == 5) && (playfield[1, 1] == '5'))
                        inputCorrect = true;
                    else if ((input == 6) && (playfield[1, 2] == '6'))
                        inputCorrect = true;
                    else if ((input == 7) && (playfield[2, 0] == '7'))
                        inputCorrect = true;
                    else if ((input == 8) && (playfield[2, 1] == '8'))
                        inputCorrect = true;
                    else if ((input == 9) && (playfield[2, 2] == '9'))
                        inputCorrect = true;
                    else
                    {
                        Console.WriteLine("Por favor, insira outra posição!");
                        inputCorrect = false;
                    }                    
                } while (!inputCorrect);            
            } while (true);
            Console.ReadKey();
        }
        #endregion

        static char[,] playfield =
        {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
        };

        static int turns = 0;

        public static void ResetField()
        {
            char[,] playfieldInitial =
         {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
         };

            playfield = playfieldInitial;
            SetField();
            turns = 0;
        }

        public static void SetField()
        {
            Console.Clear();
            Console.WriteLine("______ _____ _____");
            Console.WriteLine("      |     |   ");
            Console.WriteLine("  {0}   |  {1}  |  {2}  ", playfield[0, 0], playfield[0, 1], playfield[0, 2]);
            Console.WriteLine("______|_____|_____");
            Console.WriteLine("      |     |     ");
            Console.WriteLine("  {0}   |  {1}  |  {2}  ", playfield[1, 0], playfield[1, 1], playfield[1, 2]);
            Console.WriteLine("______|_____|_____");
            Console.WriteLine("      |     |     ");
            Console.WriteLine("  {0}   |  {1}  |  {2}  ", playfield[2, 0], playfield[2, 1], playfield[2, 2]);
            Console.WriteLine("______|_____|_____");
            turns++;
        }

        public static void EnterXorO(int player, int input)
        {
            char playerSign = ' ';

            if (player == 1)
            {
                playerSign = 'X';
            }
            else if (player == 2)
            {
                playerSign = 'O';
            }

            switch (input)
            {
                case 1: playfield[0, 0] = playerSign; break;
                case 2: playfield[0, 1] = playerSign; break;
                case 3: playfield[0, 2] = playerSign; break;
                case 4: playfield[1, 0] = playerSign; break;
                case 5: playfield[1, 1] = playerSign; break;
                case 6: playfield[1, 2] = playerSign; break;
                case 7: playfield[2, 0] = playerSign; break;
                case 8: playfield[2, 1] = playerSign; break;
                case 9: playfield[2, 2] = playerSign; break;
            }
        }
    }
}