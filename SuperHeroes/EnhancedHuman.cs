using System.Collections.Generic;

namespace InheritanceOfSuperHeroes
{
    /// <summary>
    /// A class representing a "enhanced human" SuperHero. Enhanced humans have
    /// super powers, but only when they are in their "enhanced" state.
    /// </summary>
    class EnhancedHuman
    {
        // INSERT PRIVATE FIELDS

                private string identity;
        private string ego;
        private List<SuperPower> powers;
        private bool enhancement;


        /// <summary>
        /// Constructs a new EnhancedHero instance with specified identities 
        /// and SuperPowers (uses the base constructor for SuperHero). EnhancedHumans
        /// are not enhanced upon construction.
        /// </summary>
        /// <param name="trueIdentity">The true identity of the EnhancedHuman</param>
        /// <param name="alterEgo">The alter ego of the EnhancedHuman</param>
        /// <param name="myPowers">A list of SuperPowers the EnhancedHuman possesses</param>
        /// 
        // INSERT CONSTRUCTOR

                public EnhancedHuman(string trueIdentity, string alterEgo, List<SuperPower> myPowers)
        {
            identity = trueIdentity;
            ego = alterEgo;
            powers = myPowers;
            enhancement = false;
        }

        /// <summary>
        /// Switches the current identity with other identity of the 
        /// EnhancedHuman. When their identity is switched, their enhanced state 
        /// is also toggled.
        /// </summary>
        /// 
        // INSERT OVERRIDE FOR SwitchIdentity METHOD

              public void SwitchIdentity() 
        {
            if (enhancement)
            {
                enhancement = false;
            }
            else {
                enhancement = true;
            }
        }

        /// <summary>
        /// Determines whether the EnhancedHuman has a particular SuperPower. 
        /// EnhancedHumans only have SuperPowers in their enhanced state.
        /// </summary>
        /// <param name="whatPower">The SuperPower to be queried</param>
        /// <returns>True is the EnhancedHuman has the provided SuperPower,
        ///     false otherwise</returns>
        ///     
        // INSERT OVERRIDE FOR HasPower 

                public bool HasPower(SuperPower whatpower) {
            if (enhancement)
            {
                if (powers.Contains(whatpower))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else {
                return false;
                }
        }


        /// <summary>
        /// Returns the total power of the EnhancedHuman based 
        /// on thier SuperPowers. EnhancedHumans only have SuperPowers in 
        /// their enhanced state.
        /// </summary>
        /// <returns>The total power of the EnhancedHuman</returns>
        /// 
        // INSERT OVERRIDE FOR TotalPower 
        public int TotalPower() {
            int power = 0;
            if (enhancement)
            {
                for (int x = 0; x < powers.Count; x++)
                {
                    power += (int)powers[x];
                }
            }
            return power;
        }

        public string CurrentIdentity()
        {
            if (enhancement)
            {
                return ego;
            }
            else
            {
                return identity;
            }
        }
        
    }
}
