using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntelectCompanyCup2021v2
{
    public class Ship
    {
        public int Id { get; }
        public int Capacity { get; set; }
        public bool IsFull { get; set; } = false;

        public Ship(int id, int capacity)
        {
            Id = id;
            Capacity = capacity;
        }
    }
}