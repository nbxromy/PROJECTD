using System;
using System.Collections.Generic;

namespace BuildingReservationSystem
{
    class ConferenceRoom
    {
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }

        public ConferenceRoom(string name)
        {
            Name = name;
            Rooms = new List<Room>();
        }

        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }

        public void DisplayAvailableRooms()
        {
            Console.WriteLine($"Available rooms in {Name}:");
            foreach (var room in Rooms)
            {
                if (!room.IsReserved)
                {
                    Console.WriteLine($"Room {room.Number} - Capacity: {room.Capacity}");
                }
            }
        }

        public bool MakeReservation(int roomNumber, DateTime startDate, DateTime endDate)
        {
            Room room = FindRoom(roomNumber);
            if (room != null && !room.IsReserved)
            {
                room.Reserve(startDate, endDate);
                return true;
            }
            return false;
        }

        public bool CancelReservation(int roomNumber)
        {
            Room room = FindRoom(roomNumber);
            if (room != null && room.IsReserved)
            {
                room.CancelReservation();
                return true;
            }
            return false;
        }

        private Room FindRoom(int roomNumber)
        {
            foreach (var room in Rooms)
            {
                if (room.Number == roomNumber)
                {
                    return room;
                }
            }
            return null;
        }
    }

    class Room
    {
        public int Number { get; set; }
        public int Capacity { get; set; }
        public bool IsReserved { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public Room(int number, int capacity)
        {
            Number = number;
            Capacity = capacity;
            IsReserved = false;
        }

        public void Reserve(DateTime startDate, DateTime endDate)
        {
            IsReserved = true;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void CancelReservation()
        {
            IsReserved = false;
            StartDate = default;
            EndDate = default;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a building
            ConferenceRoom building = new ConferenceRoom("TechHub");

            // Add rooms to the building
            building.AddRoom(new Room(101, 10));
            building.AddRoom(new Room(102, 15));
            building.AddRoom(new Room(103, 20));

            // Display available rooms
            building.DisplayAvailableRooms();

            // Make a reservation
            Console.WriteLine("\nMaking a reservation for Room 101...");
            DateTime startDate = new DateTime(2024, 4, 15);
            DateTime endDate = new DateTime(2024, 4, 20);
            if (building.MakeReservation(101, startDate, endDate))
            {
                Console.WriteLine("Reservation successful!");
            }
            else
            {
                Console.WriteLine("Room not available for reservation.");
            }

            // Cancel reservation
            Console.WriteLine("\nCancelling reservation for Room 101...");
            if (building.CancelReservation(101))
            {
                Console.WriteLine("Reservation cancelled successfully!");
            }
            else
            {
                Console.WriteLine("No reservation found for Room 101.");
            }
        }
    }
}