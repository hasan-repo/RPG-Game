using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    class Fight
    {
        public Hero PlayingHero;
        public Monster PlayingMonster;
        bool GameOver;
      
        public Fight(Hero hero, Monster monster)
        {
            this.PlayingHero = hero;
            this.PlayingMonster = monster;
            GameOver = false;

        }

        public void PlayFight()
        {
            GameOver = false;
            Console.WriteLine("MATCH BETWEEN HERO: " + PlayingHero.HeroName + " VS MONSTER: " + PlayingMonster.MonsterName);
            int counter = 0;
            while (GameOver == false)
            {
                if (counter % 2 == 0)
                {
                    heroTurn();

                }
                else
                {
                    MonsterTurn();
                }

                String MonsterHealth = "MONSTER HEALTH: ";
                String HeroHealth = "HERO HEALTH: ";

                if (PlayingMonster.CurrentHealth < 0)
                {
                    MonsterHealth += "0";
                }
                else
                {
                    MonsterHealth += "" + PlayingMonster.CurrentHealth;
                }

                if (PlayingHero.CurrentHealth < 0)
                {
                    HeroHealth += "0";
                }
                else
                {
                    HeroHealth += "" + PlayingHero.CurrentHealth;
                }

                Console.WriteLine(MonsterHealth + " " + HeroHealth);

                if (PlayingHero.CurrentHealth <= 0 || PlayingMonster.CurrentHealth <= 0)
                {
                    GameOverMessage();
                    GameOver = true;

                }

                counter++;
            }
        }

        public void GameOverMessage()
        {

            if (PlayingHero.CurrentHealth <= 0)
            {
                PlayingHero.GamesPlayed++;
               
                Console.WriteLine("MONSTER WON!");
            }
            else if (PlayingMonster.CurrentHealth <= 0)
            {
                PlayingHero.GamesPlayed++;
                PlayingHero.GamesWon++;
              
                Console.WriteLine("HERO WON!");
            }
            PlayingHero.ResetHero();
            PlayingMonster.CurrentHealth = PlayingMonster.OriginalHealth;
            Console.WriteLine("\n RETURNING TO MAIN MENU.....");
        }

        public void heroTurn()
        {
            Console.WriteLine("\n NOW HERO'S TURN: \n PLEASE CHOOSE A NUMBER TO PICK AN OPTION:\n 0 - ATTACK MONSTER");
            int OptionNum = 1;
            bool optionsAvailable = false;

            if (PlayingHero.EquippedWeapon == null)
            {
                optionsAvailable = true;
                Console.WriteLine(OptionNum + " - EQUIP WEAPON");
                OptionNum++;
            }

            if (PlayingHero.EquippedArmor == null)
            {
                optionsAvailable = true;
                Console.WriteLine(OptionNum + " - EQUIP ARMOR");
            }

            bool ValidInput = false;

            String UserInput = "";
            while (ValidInput != true)
            {
                UserInput = Console.ReadLine();


                if (UserInput.Length > 0 && UserInput.Length < 2)
                {
                    if (UserInput[0] >= '0')
                    {
                        if (optionsAvailable == true)
                        {
                            if (OptionNum == 1)
                            {
                                if (UserInput[0] <= '1')
                                {
                                    ValidInput = true;
                                }

                            }
                            else if (OptionNum == 2)
                            {
                                if (UserInput[0] <= '2')
                                {
                                    ValidInput = true;
                                }

                            }
                        }
                        else
                        {
                            ValidInput = true;
                        }

                    }
                }
                if (ValidInput != true)
                {
                    Console.WriteLine("PLEASE ENTER A VALID NUMBER");
                }

            }

            if (ValidInput == true)
            {
                int ChosenOption = Int32.Parse("" + UserInput[0]);
                if (ChosenOption == 0)
                {
                    int TotalHit = Math.Abs(PlayingMonster.Defense - PlayingHero.TotalStrength);
                    Console.WriteLine("HERO DOES " + TotalHit + " DAMAGE TO MONSTER");
                    PlayingMonster.CurrentHealth = PlayingMonster.CurrentHealth - TotalHit;

                }
                else if (ChosenOption == 1)
                {
                    if (OptionNum == 2)
                    {
                        ChooseWeapon();

                    }
                    else if (OptionNum == 1)
                    {
                        ChooseArmor();

                    }
                }
                else if (ChosenOption == 2)
                {
                    ChooseArmor();

                }

            }

        }

        public void ChooseArmor()
        {
            bool ValidInput = false;
            String UserInput = "";

            Console.WriteLine("PLEASE CHOOSE A NUMBER TO EQUIP A ARMOR");
            for (int i = 0; i < PlayingHero.ArmorBagSize; i++)
            {
                Console.WriteLine(i + " - " + PlayingHero.ArmorBag[i].ArmorName);
            }

            while (ValidInput != true)
            {
                UserInput = Console.ReadLine();

                if (UserInput.Length > 0 && UserInput.Length < 2)
                {
                    if (UserInput[0] >= '0' && UserInput[0] <= '2')
                    {
                        ValidInput = true;
                    }
                }
                if (ValidInput != true)
                {
                    Console.WriteLine("PLEASE ENTER A VALID NUMBER");
                }

            }

            if (ValidInput == true)
            {
                int index = Int32.Parse("" + UserInput[0]);
                PlayingHero.EquipArmor(PlayingHero.ArmorBag[index]);
            }

        }

        public void ChooseWeapon()
        {
            bool ValidInput = false;
            String UserInput = "";

            Console.WriteLine("PLEASE CHOOSE A NUMBER TO EQUIP A WEAPON");
            for (int i = 0; i < PlayingHero.WeaponBagSize; i++)
            {
                Console.WriteLine(i + " - " + PlayingHero.WeaponsBag[i].WeaponName);
            }
       
            while (ValidInput != true)
            {
                UserInput = Console.ReadLine();

                if (UserInput.Length > 0 && UserInput.Length < 2)
                {
                    if (UserInput[0] >= '0' && UserInput[0] <= '2')
                    {
                        ValidInput = true;
                    }
                }
                if (ValidInput != true)
                {
                    Console.WriteLine("PLEASE ENTER A VALID NUMBER");
                }

            }

            if (ValidInput == true)
            {
                int index = Int32.Parse("" + UserInput[0]);
                PlayingHero.EquipWeapon(PlayingHero.WeaponsBag[index]);
            }

        }

        public void MonsterTurn()
        {
            Console.WriteLine("\n NOW MONSTER'S TURN:");

            int TotalHit = Math.Abs(PlayingHero.TotalDefense - PlayingMonster.Strength);
            Console.WriteLine("MONSTER DOES " + TotalHit + " DAMAGE TO HERO");
            PlayingHero.CurrentHealth = PlayingHero.CurrentHealth - TotalHit;

        }
    }
}
