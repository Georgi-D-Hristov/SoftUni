namespace DefiningClasses
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        private const int LimitAge = 30;
        private List<Person> persons;

        public Family()
        {
            persons = new List<Person>();
        }

        public void AddMember(Person member)
        {
            persons.Add(member);
        }

        public Person GetOldestMember()
        {
            return persons.OrderByDescending(p => p.Age).FirstOrDefault();
        }
        public List<Person> GetPersonsOverThirty() 
        { 
            return persons.Where(p=>p.Age > LimitAge).OrderBy(p=>p.Name).ToList();
        }
    }
}
