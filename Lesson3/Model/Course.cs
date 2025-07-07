using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3.Model
{
    internal class Course
    {
        public string Name { get; }
        public int Duration { get; }
        public Course(string name, int duration)
        {
            Name = name;
            if (duration <= 0)
                throw new ArgumentException();
            Duration = duration;
        }
    }
}
