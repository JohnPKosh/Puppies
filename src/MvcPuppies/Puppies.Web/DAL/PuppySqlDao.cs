using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

using Puppies.Web.Models;

namespace Puppies.Web.DAL
{
  public class PuppySqlDao : IPuppyDao
  {
    private readonly string connectionString;

    public PuppySqlDao(string connectionString)
    {
      this.connectionString = connectionString;
    }

    /// <summary>
    /// Returns a list of all puppies
    /// </summary>
    /// <returns></returns>
    public IList<Puppy> GetPuppies()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Returns a specific puppy
    /// </summary>
    /// <returns></returns>
    public Puppy GetPuppy(int id)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Saves a new puppy to the system.
    /// </summary>
    /// <param name="newPuppy"></param>
    /// <returns></returns>
    public void SavePuppy(Puppy newPuppy)
    {
      throw new NotImplementedException();
    }
  }
}
