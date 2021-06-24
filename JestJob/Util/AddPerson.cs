using JestJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JestJob.Util
{
    public class AddPerson
    {
        private readonly PersonContext _context;

        public AddPerson(PersonContext context)
        {
            _context = context;
        }
        public AddPerson()
        {

        }

        public void Add()
        {
            Person person = new Person
            {
                FullName = "Mojtaba - " + DateTime.Now
            };
            _context.People.Add(person);
            _context.SaveChanges();
        }
    }
}
