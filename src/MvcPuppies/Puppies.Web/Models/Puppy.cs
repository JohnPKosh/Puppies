using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Puppies.Web.Models
{
    public class Puppy
    {
        public Puppy() {}

        public Puppy(string name, int weight, string gender, bool paperTrained) {
            Name = name;
            Weight = weight;
            Gender = gender;
            PaperTrained = paperTrained;
        }

        public Puppy(int id, string name, int weight, string gender, bool paperTrained)
        {
            Id = id;
            Name = name;
            Weight = weight;
            Gender = gender;
            PaperTrained = paperTrained;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int Weight { get; set; }

        public string Gender { get; set; }

        public bool PaperTrained { get; set; }

    }
}
