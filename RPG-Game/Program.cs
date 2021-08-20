using System;

namespace RPG_Game
{

        class Program
        {

            public Weapon[] WeaponList = { new Weapon("KNIFE", 10), new Weapon("PISTOL", 15), new Weapon("GUN", 20) };
            public Armor[] ArmorList = { new Armor("VEST", 10), new Armor("HELMET", 15), new Armor("BOOT", 20) };

            public Monster Monster1 = new Monster("Uranus", 30, 20);
            public Monster Monster2 = new Monster("Zilong", 40, 90);
            public Monster Monster3 = new Monster("Nana", 50, 10);

            public Monster[] monsterList = { new Monster("Uranus", 30, 20), new Monster("Zilong", 40, 90), new Monster("Nana", 50, 10) };

            public Hero human = new Hero("PLAYER");


            public void Start()
            {
                FillWeaponNArmor();
                Fight NewFight = new Fight(human, Monster2);

                Console.WriteLine("ENTER HERO NAME:");
                String UserInput = Console.ReadLine();
                human.HeroName = UserInput;

                while (UserInput != "3")
                {
                    Console.WriteLine(
                            "MAIN MENU\n PLEASE PICK A NUMBER TO PROCEED\n 0 - SHOW STAT\n 1 - SHOW INVENTORY\n 2 - PLAY MATCH\n 3 - QUIT GAME");
                    bool ValidInput = false;
                    while (ValidInput != true)
                    {
                        UserInput = Console.ReadLine();

                        if (UserInput.Length > 0 && UserInput.Length < 2)
                        {
                            if (UserInput[0] >= '0' && UserInput[0] <= '3')
                            {
                                ValidInput = true;
                            }
                        }
                        if (ValidInput != true)
                        {
                            Console.WriteLine("PLEASE ENTER A VALID NUMBER!");
                        }

                    }

                    if (ValidInput == true)
                    {
                        if (UserInput[0] == '0')
                        {
                            human.ShowStats();
                        }
                        else if (UserInput[0] == '1')
                        {
                            human.ShowInventory();
                        }
                        else if (UserInput[0] == '2')
                        {
                            Console.WriteLine("PLEASE CHOOSE A NUMBER TO PICK A MONSTER");
                            for (int i = 0; i < monsterList.Length; i++)
                            {
                                Console.WriteLine(i + " - " + monsterList[i].MonsterName);
                            }

                            bool valid = false;

                            while (valid != true)
                            {
                                UserInput = Console.ReadLine();
                                if (UserInput.Length > 0 && UserInput.Length < 2)
                                {
                                    if (UserInput[0] >= '0' && UserInput[0] <= '2')
                                    {
                                        valid = true;
                                    }

                                }
                                if (valid != true)
                                {
                                    Console.WriteLine("PLEASE ENTER A VALID NUMBER");
                                }

                            }

                            if (valid == true)
                            {
                                if (UserInput[0] == '0')
                                {
                                    NewFight.PlayingMonster = Monster1;
                                }
                                else if (UserInput[0] == '1')
                                {
                                    NewFight.PlayingMonster = Monster2;
                                }
                                else if (UserInput[0] == '2')
                                {
                                    NewFight.PlayingMonster = Monster3;
                                }
                            NewFight.PlayFight();

                            }
                        }

                    }
                }



            }

            public void FillWeaponNArmor()
            {
                human.ArmorBagSize = ArmorList.Length;
                human.WeaponBagSize = WeaponList.Length;

                for (int i = 0; i < 3; i++)
                {
                    human.ArmorBag[i] = ArmorList[i];
                    human.WeaponsBag[i] = WeaponList[i];
                }

            }


            static void Main(String[] args)
            {
                Program newGame = new Program();
                newGame.Start();
            }
        }
  }


