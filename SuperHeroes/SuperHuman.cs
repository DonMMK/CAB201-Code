using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceOfSuperHeroes
{
    /// <summary>
    /// A class representing a "super human" SuperHero. Super humans have
    /// super powers, and can gain/lose super powers under certain conditions.
    /// </summary>
    class SuperHuman
    {
        // INSERT PRIVATE FIELDS




        /// <summary>
        /// Constructs a new SuperHuman instance with specified identities 
        /// and SuperPowers (uses the base constructor for SuperHero).
        /// </summary>
        /// <param name="trueIdentity">The true identity of the SuperHuman</param>
        /// <param name="alterEgo">The alter ego of the SuperHuman</param>
        /// <param name="myPowers">A list of SuperPowers the SuperHuman possesses</param>
        /// 
        // INSERT CONSTRUCTOR

                private string identity;
        private string ego;
        private List<SuperPower> powers;
        private bool change = false;

        public SuperHuman(string trueIdentity, string alterEgo, List<SuperPower> myPowers) {
            identity = trueIdentity;
            ego = alterEgo;
            powers = myPowers;
        }


        /// <summary>
        /// Determines whether the SuperHuman has a particular SuperPower.
        /// </summary>
        /// <param name="whatPower">The SuperPower to be queried</param>
        /// <returns>True is the SuperHuman has the provided SuperPower,
        ///     false otherwise</returns>
        ///     
        // INSERT OVERRIDE FOR HasPower METHOD

        public bool HasPower(SuperPower whatPower)
        {
            if (powers.Contains(whatPower))
            {
                return true;
            }
            else {
                return false;
            }
        }


        /// <summary>
        /// Returns the total power of the SuperHuman based on thier SuperPowers.
        /// </summary>
        /// <returns>The total power of the SuperHuman</returns>
        /// 
        // INSERT OVERRIDE FOR TotalPower METHOD

                public int TotalPower() {
            int power = 0;
                for (int x = 0; x < powers.Count; x++)
                {
                    power += (int)powers[x];
                }
            return power;
        }


        /// <summary>
        /// Adds a new SuperPower to the set of SuperPowers the SuperHuman 
        /// possesses, and adjusts their total power accordingly.
        /// </summary>
        /// <param name="newPower">The new SuperPower</param>
        /// 
        // INSERT AddSuperPower METHOD

                public void AddSuperPower(SuperPower newPower) {
            powers.Add(newPower);
        }

        /// <summary>
        /// Removes a particular SuperPower from the set of SuperPowers the 
        /// SuperHuman possesses (if it exists), and adjusts their total 
        /// power accordingly.
        /// </summary>
        /// <param name="power">The SuperPower to be removed</param>
        /// 
        // INSERT LoseSinglePower METHOD

                public void LoseSinglePower(SuperPower power) {
            powers.Remove(power);
        }


        /// <summary>
        /// Removes all SuperPowers that the SuperHuman possesses, and adjusts 
        /// their total power accordingly.
        /// </summary>
        /// 
        // INSERT LoseAllSuperPowers METHOD

                public void LoseAllSuperPowers()
        {
            powers.RemoveRange(0,powers.Count);
        }

        public string CurrentIdentity() {
            
            if (change) { return ego; }
            else { return identity; }
        }
        public void SwitchIdentity()
        {
            if (change)
            {
                change = false;
            }
            else {
                change = true;
            }
        }

    }
}
