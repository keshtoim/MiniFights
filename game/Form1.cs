using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace game
{
    public partial class Form1 : Form
    {
        #region Constants and Globals
        private float playerHealth = 100f;
        private float playerArmor = 50f;
        private float playerDamage = 25f;
        private int playerPotions = 5;

        private float enemyHealth = 0f;
        private float enemyArmor = 0f;
        private float enemyDamage = 0f;
        private bool isBattleActive = false;

        private char[,] currentMap;
        private int playerRow = 1;
        private int playerCol = 1;
        private const int CellSize = 20;

        private int totalEnemies = 0;
        private int defeatedEnemies = 0;
        private int wave = 1;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            infoAboutPlayer.ReadOnly = true;
            infoAboutEnemy.ReadOnly = true;
        }

        public static char[,] GenerateMazeKruskal(int width, int height, int extraEnemies, out int enemyCount)
        {
            if (width % 2 == 0) width++;
            if (height % 2 == 0) height++;

            var maze = new char[height, width];
            var rand = new Random();

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    maze[y, x] = (x % 2 == 1 && y % 2 == 1) ? ' ' : '#';

            int totalCells = ((width - 1) / 2) * ((height - 1) / 2);
            var parent = Enumerable.Range(0, totalCells).ToArray();

            int Find(int i)
            {
                if (parent[i] != i) parent[i] = Find(parent[i]);
                return parent[i];
            }

            void Union(int a, int b) => parent[Find(a)] = Find(b);

            var walls = new List<(int x, int y, int c1, int c2)>();
            for (int y = 1; y < height - 1; y += 2)
                for (int x = 1; x < width - 1; x += 2)
                {
                    int idx = (y / 2) * ((width - 1) / 2) + (x / 2);
                    if (x + 2 < width) walls.Add((x + 1, y, idx, idx + 1));
                    if (y + 2 < height) walls.Add((x, y + 1, idx, idx + ((width - 1) / 2)));
                }

            walls = walls.OrderBy(_ => rand.Next()).ToList();

            foreach (var (wx, wy, c1, c2) in walls)
            {
                if (Find(c1) != Find(c2))
                {
                    maze[wy, wx] = ' ';
                    Union(c1, c2);
                }
            }

            int corridorCount = rand.Next(3, 6);
            for (int c = 0; c < corridorCount; c++)
            {
                int centerX = rand.Next(3, width - 4);
                int centerY = rand.Next(3, height - 4);
                if (maze[centerY, centerX] != ' ') continue;
                for (int dy = -1; dy <= 1; dy++)
                    for (int dx = -1; dx <= 1; dx++)
                    {
                        int ny = centerY + dy, nx = centerX + dx;
                        if (ny >= 0 && ny < height && nx >= 0 && nx < width)
                            maze[ny, nx] = ' ';
                    }
            }

            int arenaCount = rand.Next(2, 4);
            for (int a = 0; a < arenaCount; a++)
            {
                int arenaSize = rand.Next(5, 9);
                if (arenaSize % 2 == 0) arenaSize--;

                int margin = 4;
                int maxRow = height - arenaSize - margin;
                int maxCol = width - arenaSize - margin;

                if (maxRow <= margin || maxCol <= margin) continue;

                int row = rand.Next(margin, maxRow);
                int col = rand.Next(margin, maxCol);

                for (int r = row; r < row + arenaSize; r++)
                    for (int c = col; c < col + arenaSize; c++)
                        if (r >= 0 && r < height && c >= 0 && c < width)
                            maze[r, c] = ' ';
            }

            var emptyCells = new List<(int y, int x)>();
            for (int y = 1; y < height - 1; y++)
                for (int x = 1; x < width - 1; x++)
                    if (maze[y, x] == ' ')
                        emptyCells.Add((y, x));

            int baseEnemies = rand.Next(8, 13);
            enemyCount = Math.Min(baseEnemies + extraEnemies, emptyCells.Count);

            for (int i = 0; i < enemyCount; i++)
            {
                if (emptyCells.Count == 0) break;
                int index = rand.Next(emptyCells.Count);
                var (y, x) = emptyCells[index];
                maze[y, x] = 'X';
                emptyCells.RemoveAt(index);
            }

            maze[1, 0] = ' ';
            maze[1, 1] = ' ';
            maze[height - 2, width - 1] = ' ';
            maze[height - 2, width - 2] = ' ';

            return maze;
        }

        private void DrawMaze()
        {
            if (currentMap == null) return;

            int width = currentMap.GetLength(1);
            int height = currentMap.GetLength(0);

            Bitmap bitmap = new Bitmap(width * CellSize, height * CellSize);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                Font font = new Font("Consolas", 10, FontStyle.Bold);

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        char ch = currentMap[y, x];
                        Brush brush = Brushes.White;
                        string symbol = " ";

                        if (ch == '#') { brush = Brushes.Gray; symbol = "#"; }
                        else if (ch == 'X') { brush = Brushes.Red; symbol = "X"; }
                        else if (ch == ' ') { brush = Brushes.White; symbol = " "; }

                        g.FillRectangle(brush, x * CellSize, y * CellSize, CellSize, CellSize);

                        if (y == playerRow && x == playerCol)
                        {
                            g.DrawString("@", font, Brushes.Green, x * CellSize + 2, y * CellSize + 1);
                        }
                        else if (symbol != " ")
                        {
                            g.DrawString(symbol, font, Brushes.Black, x * CellSize + 2, y * CellSize + 1);
                        }
                    }
                }
            }

            pictureBox1.Image = bitmap;
        }

        private void gameStartBtn_Click(object sender, EventArgs e)
        {
            StartNewWave(1);
        }

        private void StartNewWave(int waveNumber)
        {
            #region Visibility
            labelMap.Visible = true;
            pictureBox1.Visible = true;

            labelAboutPlayer.Visible = true;
            infoAboutPlayer.Visible = true;

            labelAboutEnemy.Visible = true;
            infoAboutEnemy.Visible = true;

            attackBtn.Visible = true;
            blockBtn.Visible = true;
            potionBtn.Visible = true;

            infoAboutNumberOfEnemies.Visible = true;
            #endregion

            wave = waveNumber;
            int mapSize = 21;
            int extraEnemies = (wave - 1) * 3;

            currentMap = GenerateMazeKruskal(mapSize, mapSize, extraEnemies, out totalEnemies);
            defeatedEnemies = 0;

            playerRow = 1;
            playerCol = 1;

            int mapWidth = currentMap.GetLength(1);
            int mapHeight = currentMap.GetLength(0);
            int imageWidth = mapWidth * CellSize;
            int imageHeight = mapHeight * CellSize;

            pictureBox1.Size = new Size(imageWidth, imageHeight);
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;

            UpdatePlayerInfo();
            UpdateEnemiesCounter();
            DrawMaze();
            gameStartBtn.Visible = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (isBattleActive)
            {
                switch (e.KeyCode)
                {
                    case Keys.D1:
                    case Keys.NumPad1:
                        attackBtn_Click(null, null);
                        return;
                    case Keys.D2:
                    case Keys.NumPad2:
                        blockBtn_Click(null, null);
                        return;
                    case Keys.D3:
                    case Keys.NumPad3:
                        UsePotion();
                        ProcessTurn(); 
                        return;
                }
                return;
            }

            if (currentMap == null) return;

            if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
            {
                UsePotion();
                return;
            }

            int newRow = playerRow;
            int newCol = playerCol;

            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.W:
                    newRow--; break;
                case Keys.Down:
                case Keys.S:
                    newRow++; break;
                case Keys.Left:
                case Keys.A:
                    newCol--; break;
                case Keys.Right:
                case Keys.D:
                    newCol++; break;
                default: return;
            }

            if (newRow >= 0 && newRow < currentMap.GetLength(0) &&
                newCol >= 0 && newCol < currentMap.GetLength(1))
            {
                char target = currentMap[newRow, newCol];
                if (target == ' ' || target == 'X')
                {
                    if (target == 'X')
                    {
                        playerRow = newRow;
                        playerCol = newCol;
                        StartBattle();
                        return;
                    }

                    playerRow = newRow;
                    playerCol = newCol;
                    DrawMaze();
                }
            }
        }

        private void UsePotion()
        {
            if (playerPotions > 0)
            {
                playerHealth += 25f;
                if (playerHealth > 100f) playerHealth = 100f; 
                playerPotions--;
                UpdatePlayerInfo();

                if (isBattleActive)
                {
                    MessageBox.Show("Вы выпили зелье! +25 HP", "Зелье", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Вы выпили зелье вне боя! +25 HP", "Зелье", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Нет зелий!", "Ошибка", MessageBoxButtons.OK);
            }
        }

        #region Battle System
        private void StartBattle()
        {
            Random rand = new Random();
            enemyHealth = rand.Next(50, 101);
            enemyArmor = rand.Next(25, 51);
            enemyDamage = rand.Next(5, 31);

            isBattleActive = true;

            UpdatePlayerInfo();
            UpdateEnemyInfo();
        }

        private void UpdatePlayerInfo()
        {
            infoAboutPlayer.Clear();

            infoAboutPlayer.SelectionFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            infoAboutPlayer.AppendText("Здоровье\n");
            infoAboutPlayer.SelectionFont = new Font("Microsoft Sans Serif", 10, FontStyle.Italic);
            infoAboutPlayer.AppendText($"{playerHealth:F0}\n\n");

            infoAboutPlayer.SelectionFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            infoAboutPlayer.AppendText("Броня\n");
            infoAboutPlayer.SelectionFont = new Font("Microsoft Sans Serif", 10, FontStyle.Italic);
            infoAboutPlayer.AppendText($"{playerArmor:F0}\n\n");

            infoAboutPlayer.SelectionFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            infoAboutPlayer.AppendText("Урон\n");
            infoAboutPlayer.SelectionFont = new Font("Microsoft Sans Serif", 10, FontStyle.Italic);
            infoAboutPlayer.AppendText($"{playerDamage:F0}\n\n");

            infoAboutPlayer.SelectionFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            infoAboutPlayer.AppendText("Зелья\n");
            infoAboutPlayer.SelectionFont = new Font("Microsoft Sans Serif", 10, FontStyle.Italic);
            infoAboutPlayer.AppendText($"{playerPotions}\n");
        }

        private void UpdateEnemyInfo()
        {
            infoAboutEnemy.Clear();

            infoAboutEnemy.SelectionFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            infoAboutEnemy.AppendText("Здоровье\n");
            infoAboutEnemy.SelectionFont = new Font("Microsoft Sans Serif", 10, FontStyle.Italic);
            infoAboutEnemy.AppendText($"{enemyHealth:F0}\n\n");

            infoAboutEnemy.SelectionFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            infoAboutEnemy.AppendText("Броня\n");
            infoAboutEnemy.SelectionFont = new Font("Microsoft Sans Serif", 10, FontStyle.Italic);
            infoAboutEnemy.AppendText($"{enemyArmor:F0}\n\n");

            infoAboutEnemy.SelectionFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            infoAboutEnemy.AppendText("Урон\n");
            infoAboutEnemy.SelectionFont = new Font("Microsoft Sans Serif", 10, FontStyle.Italic);
            infoAboutEnemy.AppendText($"{enemyDamage:F0}\n");
        }

        private void attackBtn_Click(object sender, EventArgs e)
        {
            if (!isBattleActive) return;

            float dmgToEnemy = playerDamage;
            float dmgToPlayer = enemyDamage * (1 - playerArmor / 100f);

            enemyHealth -= dmgToEnemy;
            playerHealth -= dmgToPlayer;

            ProcessTurn();
        }

        private void blockBtn_Click(object sender, EventArgs e)
        {
            if (!isBattleActive) return;

            float counterDamage = enemyDamage * 0.05f;
            enemyHealth -= counterDamage;

            MessageBox.Show($"Вы блокировали атаку и нанесли {counterDamage:F1} урона врагу!", "Блок", MessageBoxButtons.OK);
            ProcessTurn();
        }

        private void potionBtn_Click(object sender, EventArgs e)
        {
            if (!isBattleActive)
            {
                UsePotion();
                return;
            }

            UsePotion();
            ProcessTurn();
        }

        private void ProcessTurn()
        {
            if (playerHealth <= 0)
            {
                playerHealth = 0;
                MessageBox.Show("Вы пали в бою!", "Поражение", MessageBoxButtons.OK);
                EndBattle(false);
            }
            else if (enemyHealth <= 0)
            {
                enemyHealth = 0;
                MessageBox.Show("Вы победили врага!", "Победа", MessageBoxButtons.OK);
                EndBattle(true);
            }
            else
            {
                UpdatePlayerInfo();
                UpdateEnemyInfo();
            }
        }

        private void EndBattle(bool playerWon)
        {
            isBattleActive = false;

            if (playerWon)
            {
                currentMap[playerRow, playerCol] = ' ';
                playerPotions++;
                defeatedEnemies++;

                UpdatePlayerInfo();
                UpdateEnemiesCounter();
                DrawMaze();

                if (defeatedEnemies >= totalEnemies)
                {
                    MessageBox.Show($"Волна {wave} пройдена!\nГенерация новой карты...", "Победа!", MessageBoxButtons.OK);
                    StartNewWave(wave + 1);
                }
            }
            else
            {
                MessageBox.Show("Вы погибли! Игра начнётся заново.");
                gameStartBtn.Visible = true;
            }
        }
        #endregion

        private void UpdateEnemiesCounter()
        {
            infoAboutNumberOfEnemies.Text = $"Побеждено врагов:\n{defeatedEnemies} из {totalEnemies}";
        }
    }
}