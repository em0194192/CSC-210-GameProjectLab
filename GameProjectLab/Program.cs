using System;

namespace GameProjectLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //instantiate players and weapons
            Weapon snowball = new Weapon("snowball", "splats");
            Weapon waterballoon = new Weapon("water balloon", "pops");
            Player player1 = new Player("Calvin", 100, snowball);
            Player player2 = new Player("Hobbes", 100, waterballoon);

            //Declare Variable
            int damage;
            string winner;

            //Game Loop - Runs Until a player has health below zero
            while (player1.health > 0 && player2.health > 0)
            {
                //P1 ATTACKS P2

                //Console Output Indicating Who Attacks Who
                Console.WriteLine(player1.playerName + " attacks " + player2.playerName);

                //P1 generates number
                damage = player1.generate_random_number();

                //P1's Weapon receives damage value, outputs weapontype, weaponaction, and damage
                player1.currentWeapon.strike(damage);

                //P2 receives damage, outputs name and new health amount
                Console.WriteLine(player2.attack(damage));

                //Empty Line for Readability
                Console.WriteLine();

                //Check if Player 2 Defeated
                if (player2.health <= 0)
                {
                    break;
                }

                //P2 ATTACKS P1

                //Console Output Indicating Who Attacks Who
                Console.WriteLine(player2.playerName + " attacks " + player1.playerName);

                //P2 generates number
                damage = player2.generate_random_number();

                //P2's Weapon receives damage value, outputs weapontype, weaponaction, and damage
                player2.currentWeapon.strike(damage);

                //P1 receives damage, outputs name and new health amount
                Console.WriteLine(player1.attack(damage));

                //Empty Line for Readability
                Console.WriteLine();

                //Check if Player 1 Defeated
                if (player1.health <= 0)
                {
                    break;
                }
            }

            //Determine Winner
            if (player1.health > player2.health)
            {
                winner = player1.playerName;
            }
            else
            {
                winner = player2.playerName;
            }
            
            //Output Winner and each players final health points
            Console.WriteLine(winner + " Wins!");
            Console.WriteLine("Final Health Points:");
            Console.WriteLine(player1.playerName + ": " + player1.health);
            Console.WriteLine(player2.playerName + ": " + player2.health);

        }
    }

    //Define the Weapon Class
    public class Weapon
    {
        public string weaponType { get; set; }
        public string weaponAction { get; set; }

        //Strike Method receives damage amount, outputs string indicating weapontype, weaponaction, and damage caused.
        public int strike(int weaponDamage)
        {
            Console.WriteLine("The " + this.weaponType + " " + this.weaponAction + ". It causes " + weaponDamage + " damage.");
            return weaponDamage;
        }

        //Constructor requires weaponType and weaponAction on object creation
        public Weapon(string weaponType, string weaponAction) 
        { 
          this.weaponType = weaponType; 
          this.weaponAction = weaponAction; 
        }
    }
    
    //Define the Player Class
    public class Player
    {
        //Properties for player's name, health, weapon
        public string playerName { get; set; }
        public int health { get; set; }
        public Weapon currentWeapon { get; set; } 

        //Create Instance of "Random" Object for Random Number Generation
        private static Random random = new Random();
        
        //Method to Generate a Random Number for damage amounts
        public int generate_random_number()
        {
            return random.Next(10, 25);
        }

        //Attack Method - receives damage amount from strikes, deducts health from player and outputs string
        public string attack(int weaponDamage)
        {
            this.health = this.health - weaponDamage;
            return this.playerName + " has " + this.health + " health!";
        }

        //Constructor requires playername, health, and weapon on object creation
        public Player(string playerName, int health, Weapon currentWeapon)
        {
            this.playerName = playerName;
            this.health = health;
            this.currentWeapon = currentWeapon;
        }
    }
}
