using System;
using System.Collections.Generic;

namespace GenealogicalTree
{
    class Program : Person
    {
        static void Main(string[] args)
        {
            Person johnnyPerson = new Person("Johnny", "Depp", new DateTime(1993, 2, 6), Gender.Male);
            Person miclePerson = new Person("Michele", "Jackson", new DateTime(1990, 2, 6), Gender.Male);
            Person stivenPerson = new Person("Stiven", "Gerrard", new DateTime(1983, 2, 6), Gender.Male);
            Person tonyPerson = new Person("Tony", "Adams", new DateTime(1980, 2, 6), Gender.Male, new List<Person>() { stivenPerson });
            Person micleOwenPerson = new Person("Michele", "Owen", new DateTime(1980, 2, 6), Gender.Male, new List<Person>() { tonyPerson });
            Person courtneyPerson = new Person("Courtney", "Michelle Harrison", new DateTime(1974, 7, 1), Gender.Female, new List<Person>(){
                johnnyPerson,
                micleOwenPerson,
                miclePerson,
                johnnyPerson
            });
            Person jessicaPerson = new Person("Jessica", "Alba", new DateTime(1973, 12, 16), Gender.Female);
            Person samuelPerson = new Person("Samuel", "Leroy Jackson", new DateTime(1970, 4, 16), Gender.Male);
            Person brucePerson = new Person("Bruce", "Willis", new DateTime(1961, 11, 21), Gender.Male, new List<Person>(){
                jessicaPerson,
                samuelPerson,
                courtneyPerson
            });

            ShowFamily(brucePerson);
        }

        private static void ShowFamily(Person mainPerson)
        {
            ShowFamilyTree(mainPerson, 0);
        }

        private static void ShowFamilyTree(Person person, int line)
        {
            String pad = "".PadLeft(line * 4);
            Console.WriteLine(pad + PersonNameIfHasChild(person));
            Console.WriteLine($"{pad}An now {HeOrShe(person)} is " + person.Age + " years old");

            if (person.Children != null)
            {
                foreach (var child in person.Children)
                {
                    ShowFamilyTree(child, line + 1);
                }
            }
        }

        private static string HeOrShe(Person person)
        {
            string gender = String.Empty;
            if (person.gender == Gender.Female)
            {
                return gender = "she";
            }
            else
            {
                return gender = "he";
            }
        }

        private static string PersonNameIfHasChild(Person person)
        {
            if (person.Children != null && person.Children.Count > 0)
            {
                return "*" + person.ToString();
            }
            else
            {
                return "-" + person.ToString();
            }
        }
    }
}
