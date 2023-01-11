using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myTestProject.Domain
{
    public class Player: Entity<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public Player(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }
    }
    

       
}
