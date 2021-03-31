using System;

namespace BirthdayApp
{
    enum Gender
    {
        Male,
        Female,
        Other
    }

    class PersonRecord
    {
        public string FullName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Gender Gender { get; private set; }
        public int PhoneNumber { get; private set; }

        public PersonRecord(string fullName, DateTime dateOfBirth, Gender gender, int phoneNumber)
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

        public static PersonRecord ScanProfile()
        {
            string fullName = Console.ReadLine();
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            Gender gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine(), true);
            int phoneNumber = int.Parse(Console.ReadLine());
            return new PersonRecord(fullName, dateOfBirth, gender, phoneNumber);
        }
    }

    class ExceptionCatcher
    {

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Please enter name, date of birth, gender, and phone number, on separate lines:");

                var profile = GetProfile();

                if (profile != null)
                {
                    Console.WriteLine($"Successfully parsed {profile}.");
                }

                Console.WriteLine();
            }
        }

        public static PersonRecord GetProfile()
        {
            PersonRecord result = null;

            // INSERT CODE HERE
            try
            {
                result = PersonRecord.ScanProfile();
                Console.WriteLine("Operation was successful!");
                
            }
            catch (Exception E)
            {
                if (E.Message.Substring(0,1) == "S")
                {
                    Console.WriteLine("Invalid format: "+ E.Message);
                    Console.WriteLine("Please use format DD/MM/YYYY for date of birth.");
                }

                if (E.Message.Substring(0, 1) == "R")
                {
                    Console.WriteLine("Invalid argument: " + E.Message);
                    Console.WriteLine("Please ensure gender is Female, Male, or Other.");
                }

                if (E.Message.Substring(0, 1) == "I")
                {
                    Console.WriteLine("Invalid format: " + E.Message);
                    Console.WriteLine("Please enter an integer.");
                }
                /*
                else
                {
                    Console.WriteLine("Unknown Error: " + Error.Message);
                }
                */
            }

            return result;
        }
    }
}
