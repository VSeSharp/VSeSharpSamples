using System.Collections.Generic;

namespace Domain
{
    public class Developer
    {
        public string FirstName { get; set; }
        public List<ProgrammingLanguage> Languages { get; set; }
        public string IntroduceDeveloper()
        {
            return "Hello, I'm " + FirstName;
        }
    }
}
