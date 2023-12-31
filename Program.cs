﻿using System;
using System.Collections.Generic;

namespace Wizard_Program
{
    class Wizard
    {
        public string name;
        public string Spell1;
        public string Spell2;
        public int spellSlots;
        public float experience;
        public List<string> castedSpells;

        public Wizard(string name, string spell1, string spell2, int spellSlots, float experience)
        {
            this.name = name;
            Spell1 = spell1;
            Spell2 = spell2;
            this.spellSlots = spellSlots;
            this.experience = experience;
            castedSpells = new List<string>();
        }

        public void CastSpell()
        {
            Random random = new Random();

            if (spellSlots >= 1)
            {
                int randomNumber = random.Next(1, 3);
                string spellToCast = (randomNumber == 1) ? Spell1 : Spell2;
                castedSpells.Add(spellToCast);

                Console.WriteLine(name + " has casted " + spellToCast);
                spellSlots--;

                if (randomNumber == 1)
                {
                    experience += 0.5f;
                }
                else
                {
                    experience += 1f;
                }

                if (experience >= 1)
                {
                    BuySpellSlots();
                }
            }
            else
            {
                Console.WriteLine(name + " has no spell slots left.");
            }
        }

        public void BuySpellSlots()
        {
            spellSlots += (int)experience;
            experience -= (int)experience;
        }

        public void PrintCastedSpells()
        {
            Console.WriteLine(name + " has casted the following spell:");
            foreach (string spell in castedSpells)
            {
                Console.WriteLine(spell);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Wizard wizard01 = new Wizard("Mlon Eusk", "Money strike", "Tesla bolt", 3, 0f);

            Console.WriteLine("The wizard " + wizard01.name + " has entered the world");
            Console.WriteLine();

            do
            {
                wizard01.CastSpell();
            } while (wizard01.spellSlots > 0 && wizard01.experience >= 1);

            Console.WriteLine(wizard01.name + " has " + wizard01.experience + " Experience: " );
            Console.WriteLine(wizard01.name + " has Spell Slots: " + wizard01.spellSlots);

            wizard01.PrintCastedSpells();

            Console.ReadLine();
        }
    }
}