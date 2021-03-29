using System.Collections.Generic;

namespace M3Oblig1
{
    public class Person
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public int BirthYear;
        public int DeathYear;
        public Person Father;
        public Person Mother;

        public string GetDescription()
        {
            string description = string.Empty;

            if (FirstName != null)
            {
                description += $" {FirstName}";
            }
            if (LastName != null)
            {
                description += $" {LastName}";
            }

            //if (Id <= 1)
            //{
            //    Id = 1;
            //}

            if (Id != 0)
            {
                description += $" (Id={Id})";
            }
            if (BirthYear != 0)
            {
                description += $" Født: {BirthYear}";
            }
            if (DeathYear != 0)
            {
                description += $" Død: {DeathYear}";
            }

            if (Father != null)
            {
                description += $" Far: {Father.FirstName} (Id={Father.Id})";
            }

            if (Mother != null)
            {
                description += $" Mor: {Mother.FirstName} (Id={Mother.Id})";
            }


            //description = $"{dFirstName} {LastName} (Id={dId}) Født: {BirthYear} Død: {DeathYear} Far: {Father.FirstName} (Id={Father.Id}) Mor: {Mother.FirstName} (Id={Mother.Id})";
            return description.TrimStart();
        }

        public string GetChildDescription()
        {
            string description = "";

            if (FirstName != null)
            {
                description += $"    {FirstName}";
            }

            if (Id != 0)
            {
                description += $" (Id={Id})";
            }
            if (BirthYear != 0)
            {
                description += $" Født: {BirthYear}";
            }
            return description + "\n";
        }

    }
}