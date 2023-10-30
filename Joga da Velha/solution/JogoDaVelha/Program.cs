using System;

class Program
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int currentPlayer = 1;
    static int choice;
    static int flag = 0;

    static void Main(string[] args)
    {
        string player1, player2;
        bool singlePlayer = false;

        Console.Write("Digite o nome do Jogador 1: ");
        player1 = Console.ReadLine();
        Console.Write("Digite o nome do Jogador 2: ");
        player2 = Console.ReadLine();

        Console.Write("Você quer jogar contra um oponente (2 Jogadores) ou contra a máquina (1 Jogador)? (2/1): ");
        int mode = int.Parse(Console.ReadLine());

        if (mode == 1)
        {
            singlePlayer = true;
            Console.WriteLine("Você está jogando contra a máquina.");
        }
        else if (mode == 2)
        {
            singlePlayer = false;
            Console.WriteLine("Você está jogando contra outro jogador.");
        }
        else
        {
            Console.WriteLine("Opção inválida. Jogando contra outro jogador por padrão.");
        }

        do
        {
            Console.Clear();
            Console.WriteLine("Jogo da Velha\n");

            if (currentPlayer % 2 == 0)
            {
                Console.WriteLine("Turno de " + player2);
            }
            else
            {
                Console.WriteLine("Turno de " + player1);
            }

            Console.WriteLine();
            BoardDesign();

            // Verifique se é um jogador humano ou a IA
            if ((currentPlayer % 2 == 0 && singlePlayer) || (!singlePlayer))
            {
                bool validInput = false;
                while (!validInput)
                {
                    Console.WriteLine("Escolha uma posição (1-9): ");
                    validInput = int.TryParse(Console.ReadLine(), out choice);

                    if (validInput)
                    {
                        if (choice < 1 || choice > 9 || board[choice - 1] == 'X' || board[choice - 1] == 'O')
                        {
                            validInput = false;
                        }
                    }

                    if (!validInput)
                    {
                        Console.WriteLine("Entrada inválida. Escolha uma posição válida.");
                    }
                }
            }
            else
            {
                choice = GetComputerMove();
            }

            if (currentPlayer % 2 == 0)
            {
                board[choice - 1] = 'O';
                currentPlayer++;
            }
            else
            {
                board[choice - 1] = 'X';
                currentPlayer++;
            }

            flag = CheckWin();
        } while (flag != 1 && flag != -1);

        Console.Clear();
        BoardDesign();

        if (flag == 1)
        {
            if (currentPlayer % 2 == 0)
            {
                Console.WriteLine("Jogador " + player2 + " venceu!");
            }
            else
            {
                Console.WriteLine("Jogador " + player1 + " venceu!");
            }
        }
        else
        {
            Console.WriteLine("Empate!");
        }

        Console.ReadKey();
    }

    static void BoardDesign()
    {
        Console.WriteLine("   |   |   ");
        Console.WriteLine(" " + board[0] + " | " + board[1] + " | " + board[2] + " ");
        Console.WriteLine("---|---|---");
        Console.WriteLine(" " + board[3] + " | " + board[4] + " | " + board[5] + " ");
        Console.WriteLine("---|---|---");
        Console.WriteLine(" " + board[6] + " | " + board[7] + " | " + board[8] + " ");
        Console.WriteLine("   |   |   ");
    }

    static int GetComputerMove()
    {
        int bestMove = -1;
        int bestScore = int.MinValue;

        for (int i = 0; i < 9; i++)
        {
            if (board[i] != 'X' && board[i] != 'O')
            {
                char originalValue = board[i];
                board[i] = 'O'; // Assume a jogada da IA

                int score = MiniMax(board, 0, false);

                board[i] = originalValue; // Desfaz a jogada

                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = i;
                }
            }
        }

        return bestMove + 1;
    }

    static int MiniMax(char[] board, int depth, bool isMaximizing)
    {
        int result = CheckWin();

        if (result != 0)
        {
            return result;
        }

        if (isMaximizing)
        {
            int bestScore = int.MinValue;
            for (int i = 0; i < 9; i++)
            {
                if (board[i] != 'X' && board[i] != 'O')
                {
                    char originalValue = board[i];
                    board[i] = 'O'; // Assume a jogada da IA

                    int score = MiniMax(board, depth + 1, false);

                    board[i] = originalValue; // Desfaz a jogada

                    bestScore = Math.Max(score, bestScore);
                }
            }
            return bestScore;
        }
        else
        {
            int bestScore = int.MaxValue;
            for (int i = 0; i < 9; i++)
            {
                if (board[i] != 'X' && board[i] != 'O')
                {
                    char originalValue = board[i];
                    board[i] = 'X'; // Assume a jogada do jogador humano

                    int score = MiniMax(board, depth + 1, true);

                    board[i] = originalValue; // Desfaz a jogada

                    bestScore = Math.Min(score, bestScore);
                }
            }
            return bestScore;
        }
    }

    static int CheckWin()
    {
        for (int a = 0; a < 8; a++)
        {
            string line = null;

            switch (a)
            {
                case 0:
                    line = board[0].ToString() + board[1] + board[2];
                    break;
                case 1:
                    line = board[3].ToString() + board[4] + board[5];
                    break;
                case 2:
                    line = board[6].ToString() + board[7] + board[8];
                    break;
                case 3:
                    line = board[0].ToString() + board[3] + board[6];
                    break;
                case 4:
                    line = board[1].ToString() + board[4] + board[7];
                    break;
                case 5:
                    line = board[2].ToString() + board[5] + board[8];
                    break;
                case 6:
                    line = board[0].ToString() + board[4] + board[8];
                    break;
                case 7:
                    line = board[2].ToString() + board[4] + board[6];
                    break;
            }

            if (line == "OOO")
            {
                return 1;
            }
            else if (line == "XXX")
            {
                return -1;
            }
        }

        if (board.All(c => c == 'X' || c == 'O'))
        {
            return 0;
        }

        return 2;
    }

}
