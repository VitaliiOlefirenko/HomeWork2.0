using System;
using System.Collections.Generic;
using System.Globalization;

namespace GenealogicalTree
{
    public class Person
    {
        public List<Person> Children { get; set; }
        public readonly Gender gender;
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime Birthday { get; }
        public int Age
        {
            get
            {
                var now = DateTime.Now;
                if (now.Day < Birthday.Day)
                {
                    return now.Year - Birthday.Year - 1;
                }
                else
                {
                    return now.Year - Birthday.Year;
                }
            }
        }

        public Person(string firstName, string lastName, DateTime birthday, Gender gender, List<Person> children = null)
        {
            this.FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            this.gender = gender;
            Children = children;
        }

        public Person()
        {
        }

        public override string ToString()
        {
            return $"{ConvertGenderToText()} {FirstName} {LastName} was born in {Birthday.ToString("dd/MMM/yyyy", new CultureInfo("en-GB"))}";
        }

        private string ConvertGenderToText()
        {
            return gender == Gender.Male ? "Mister." : "Miss.";
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}