using System;
using System.Windows.Forms;

namespace game
{
    public partial class BattleForm : Form
    {
        private float playerHealth, playerArmor, playerDamage;
        private float enemyHealth, enemyArmor, enemyDamage;
        private int potions;
        private bool playerWon = false;

        public bool PlayerWon => playerWon;

        public BattleForm(float pHp, float pArm, float pDmg, int potionCount)
        {
            InitializeComponent();
            Random rand = new Random();

            playerHealth = pHp;
            playerArmor = pArm;
            playerDamage = pDmg;
            potions = potionCount;

            enemyHealth = rand.Next(50, 101);
            enemyArmor = rand.Next(25, 51);
            enemyDamage = rand.Next(5, 31);

            UpdateUI();
        }

        private void UpdateUI()
        {
            lblPlayer.Text = $"Игрок\nHP: {playerHealth:F0}\nБроня: {playerArmor:F0}\nУрон: {playerDamage:F0}";
            lblEnemy.Text = $"Враг\nHP: {enemyHealth:F0}\nБроня: {enemyArmor:F0}\nУрон: {enemyDamage:F0}";
            lblPotions.Text = $"Зелий: {potions}";
            btnPotion.Enabled = potions > 0;

            lblPlayer.Refresh();
            lblEnemy.Refresh();
            lblPotions.Refresh();
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            float dmgToEnemy = playerDamage;
            float dmgToPlayer = enemyDamage * (1 - playerArmor / 100f);

            enemyHealth -= dmgToEnemy;
            playerHealth -= dmgToPlayer;

            ProcessTurn();
            UpdateUI();
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            float counterDamage = enemyDamage * 0.05f;
            enemyHealth -= counterDamage;

            MessageBox.Show($"Вы блокировали атаку и нанесли {counterDamage:F1} урона врагу!", "Блок", MessageBoxButtons.OK);
            ProcessTurn();
        }

        private void btnPotion_Click(object sender, EventArgs e)
        {
            if (potions > 0)
            {
                playerHealth += 25f;
                potions--;
                MessageBox.Show("Вы выпили зелье! +25 HP", "Зелье", MessageBoxButtons.OK);
            }
            ProcessTurn();

        }

        private void ProcessTurn()
        {
            if (playerHealth <= 0)
            {
                playerHealth = 0;
                MessageBox.Show("Вы пали в бою!", "Поражение", MessageBoxButtons.OK);
                Close();
            }
            else if (enemyHealth <= 0)
            {
                enemyHealth = 0;
                playerWon = true;
                MessageBox.Show("Вы победили врага!", "Победа", MessageBoxButtons.OK);
                Close();
            }
            else
            {
                UpdateUI();
            }
        }
    }
}