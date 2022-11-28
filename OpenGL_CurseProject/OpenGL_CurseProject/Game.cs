using OpenGL_CurseProject.Enums;

namespace OpenGL_CurseProject
{
    public class Game
    {
        private const int x = 16;
        private const int y = 25;

        public int Population { get; set; }

        public GameStatus Status { get; set; }

        public Creature[,] creatures = new Creature[y, x];

        public Game()
        {
            Clear();
            Status = GameStatus.Stoped;
        }

        public void AddCreature(int i, int j)
        {
            if (creatures[i, j].Status == CreatureStatus.Mature)
            {
                creatures[i, j].Status = CreatureStatus.Dead;
            }
            else
            {
                creatures[i, j].Status = CreatureStatus.Mature;
            }
        }

        public void Glider()
        {
            creatures[8, 4].Status = CreatureStatus.Mature;
            creatures[9, 4].Status = CreatureStatus.Mature;
            creatures[10, 4].Status = CreatureStatus.Mature;
            creatures[10, 5].Status = CreatureStatus.Mature;
            creatures[9, 6].Status = CreatureStatus.Mature;
        }

        public void Barge()
        {
            creatures[9, 6].Status = CreatureStatus.Mature;
            creatures[8, 7].Status = CreatureStatus.Mature;
            creatures[7, 8].Status = CreatureStatus.Mature;
            creatures[8, 9].Status = CreatureStatus.Mature;
            creatures[9, 8].Status = CreatureStatus.Mature;
            creatures[10, 7].Status = CreatureStatus.Mature;
        }

        public void SpaceShip()
        {
            creatures[9, 6].Status = CreatureStatus.Mature;
            creatures[9, 7].Status = CreatureStatus.Mature;
            creatures[9, 8].Status = CreatureStatus.Mature;
            creatures[10, 9].Status = CreatureStatus.Mature;
            creatures[10, 6].Status = CreatureStatus.Mature;
            creatures[11, 6].Status = CreatureStatus.Mature;
            creatures[12, 6].Status = CreatureStatus.Mature;
            creatures[13, 7].Status = CreatureStatus.Mature;
            creatures[13, 9].Status = CreatureStatus.Mature;
        }

        public void Clear()
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    creatures[i, j] = new Creature();
                }
            }

            Population = 0;
        }

        public void CountPopulation()
        {
            Population = 0;

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (creatures[i, j].Status == CreatureStatus.Growing || creatures[i, j].Status == CreatureStatus.Mature)
                    {
                        Population++;
                    }
                }
            }
        }

        public void GameLogic()
        {
            bool[,] curentState = new bool[y, x];

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    curentState[i, j] = creatures[i, j].Status == CreatureStatus.Mature || CreatureStatus.Growing == creatures[i, j].Status;
                }
            }

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    var numberOfMature = 0;

                    if (curentState[i, (j + 1) % x]) numberOfMature++;
                    if (curentState[i, (j - 1 + x) % x]) numberOfMature++;

                    if (curentState[(i + 1) % y, (j + 1) % x]) numberOfMature++;
                    if (curentState[(i + 1) % y, j]) numberOfMature++;
                    if (curentState[(i + 1) % y, (j - 1 + x) % x]) numberOfMature++;

                    if (curentState[(i - 1 + y) % y, (j + 1) % x]) numberOfMature++;
                    if (curentState[(i - 1 + y) % y, j]) numberOfMature++;
                    if (curentState[(i - 1 + y) % y, (j - 1 + x) % x]) numberOfMature++;

                    if (curentState[i, j])
                    {
                        if (numberOfMature >= 2 && numberOfMature <= 3)
                        {
                            creatures[i, j].Status = CreatureStatus.Mature;
                        }
                        else
                        {
                            creatures[i, j].Status = CreatureStatus.Dying;
                        }
                    }
                    else
                    {
                        if (numberOfMature == 3)
                        {
                            creatures[i, j].Status = CreatureStatus.Growing;
                        }
                        else
                        {
                            creatures[i, j].Status = CreatureStatus.Dead;
                        }
                    }
                }
            }
        }
    }
}
