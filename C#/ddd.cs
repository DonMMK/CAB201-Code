using System;

namespace BirthdayApp
{
    enum Gender
    {
        Male,
        Female,
        Other
    }

    class PersonProfile
    {
        public string FullName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Gender Gender { get; private set; }
        public int PhoneNumber { get; private set; }

        public PersonProfile(string fullName, DateTime dateOfBirth, Gender gender, int phoneNumber)
        {
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"{FullName}; {DateOfBirth}; {Gender}; {PhoneNumber}";
        }

        public static PersonProfile ScanProfile()
        {
            string fullName = Console.ReadLine();
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            Gender gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine(), true);
            int phoneNumber = int.Parse(Console.ReadLine());
            return new PersonProfile(fullName, dateOfBirth, gender, phoneNumber);
        }
    }

    class ExceptionCatcher
    {

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Please enter name, date of birth, gender, and phone number, on separate lines:");

                var profile = GetValidProfile();

                if (profile != null)
                {
                    Console.WriteLine($"Successfully parsed {profile}.");
                }

                Console.WriteLine();
            }
        }

        public static PersonProfile GetValidProfile()
        {
            PersonProfile result = null;

            // bool success = true;

            try
            {
                result = PersonProfile.ScanProfile();

                Console.WriteLine("Operation was successful!");
            }

            catch (Exception ex)
            {
                if (ex.Message.Substring(0, 1) == "S")
                {
                    Console.WriteLine("Invalid format: " + ex.Message);
                    Console.WriteLine("Please use format DD/MM/YYYY for date of birth.");
                }

                if (ex.Message.Substring(0, 1) == "R")
                {
                    Console.WriteLine("Invalid argument: " + ex.Message);
                    Console.WriteLine("Recognised genders Male, Female, or Other.");
                }

               if (ex.Message.Substring(0, 1) == "I")
               {
                    Console.WriteLine("Invalid format: " + ex.Message);
                    Console.WriteLine("Phone number must be an integer.");
               }
            }

            return result;
        }
    }
}