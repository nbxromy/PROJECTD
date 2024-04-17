using System;
using System.Collections.Generic;

namespace BuildingReservationSystem
{
    class Employee
    {
        public string? Name {get; set;}
        public string? EmployeeNumber {get; set;}
        public string? Department {get; set;}

    }

    class CheckInEmployee : Employee
    {
        public int BadgeID {get; set;}
        public int CheckInDate {get; set;}
        public int ExpirationDate {get; set;}

    }
}


// - Couple, indiv, meeting rooms