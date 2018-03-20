using System;
using System.Collections.Generic;

namespace StandartInterfaces
{
    public sealed class Person
    {
        private String lastName;

        public String LastName
        {
            get { return lastName; }
            private set
            {
                var trimedValue = value.Trim();
                if (String.IsNullOrEmpty(trimedValue))
                    throw new ArgumentException("Wrong argument, last name must be not empty, null or full whitespaces.", nameof(LastName));
                lastName = trimedValue;
            }
        }

        private String firstName;

        public String FirstName
        {
            get { return firstName; }
            private set
            {
                var trimedValue = value.Trim();
                if (String.IsNullOrEmpty(trimedValue))
                    throw new ArgumentException("Wrong argument, first name must be not empty, null or full whitespaces.", nameof(FirstName));
                firstName = trimedValue;
            }
        }

        private String middleName;

        public String MiddleName
        {
            get { return middleName; }
            private set
            {
                var trimedValue = value.Trim();
                if (String.IsNullOrEmpty(trimedValue))
                    throw new ArgumentException("Wrong argument, middle name must be not empty, null or full whitespaces.", nameof(MiddleName));
                middleName = trimedValue;
            }
        }

        private DateTime birthDate;

        public DateTime BirthDate
        {
            get { return birthDate; }
            private set
            {
                if (value > DateTime.Now)
                    throw new ArgumentOutOfRangeException(nameof(BirthDate));
                birthDate = value;
            }
        }

        private DateTime? deathDate;

        public DateTime? DeathDate
        {
            get { return deathDate; }
            private set
            {
                if (value != null && (value < BirthDate || value > DateTime.Now))
                    throw new ArgumentOutOfRangeException(nameof(DeathDate));
                deathDate = value;
            }
        }

        public Int32 Age => (DeathDate?.Year ?? DateTime.Now.Year) - BirthDate.Year;

        public Person(String fullName, DateTime birthDate, DateTime? deathDate = null)
        {
            var names = fullName.Split(' ');
            if (names.Length < 3)
                throw new ArgumentException("Illegal format full name representation.", nameof(fullName));

            LastName = names[0];
            FirstName = names[1];
            MiddleName = names[2];

            BirthDate = birthDate;
            DeathDate = deathDate;
        }

        public Person(String lastName, String firstName, String middleName, DateTime birthDate,
            DateTime? deathDate = null)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;

            BirthDate = birthDate;
            DeathDate = deathDate;
        }

        public override String ToString() => 
            $"{LastName} {FirstName} {MiddleName} ({BirthDate.Year} - {DeathDate?.Year})";

        public sealed class LastNameComparer : IComparer<Person>
        {
            public Int32 Compare(Person x, Person y) =>
                x.LastName.CompareTo(y.LastName);
        }

        public sealed class AgeComparer : IComparer<Person>
        {
            public Int32 Compare(Person x, Person y) =>
                x.Age.CompareTo(y.Age);
        }

        public sealed class BirthDateComparer : IComparer<Person>
        {
            public Int32 Compare(Person x, Person y) =>
                x.BirthDate.CompareTo(y.BirthDate);
        }
    }
}