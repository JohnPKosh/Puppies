using Puppies.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Puppies.Web.DAL
{
  public class PuppyDaoList : IPuppyDao
  {

    public PuppyDaoList() { }


    /// <summary>
    /// Returns a list of all puppies
    /// </summary>
    /// <returns></returns>
    public IList<Puppy> GetPuppies() =>
      new List<Puppy> { new Puppy() { Id = 1, Name = "Garcon", Weight = 8, Gender = "Female", PaperTrained = false } };


    /// <summary>
    /// Returns a specific puppy
    /// </summary>
    /// <returns></returns>
    public Puppy GetPuppy(int id) => new Puppy() { Id = 1, Name = "Garcon", Weight = 8, Gender = "Female", PaperTrained = false };

    /// <summary>
    /// Saves a new puppy to the system.
    /// </summary>
    /// <param name="newPuppy"></param>
    /// <returns></returns>
    public void SavePuppy(Puppy newPuppy)
    {
      // Do nothing for now
      //throw new NotImplementedException();
    }
  }
}
