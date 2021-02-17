using System.Collections.Generic;

using Puppies.Web.Models;

namespace Puppies.Web.DAL
{
  /// <summary>
  /// Public interface to access Puppy data from a data store
  /// </summary>
  public interface IPuppyDao
  {
    /// <summary>
    /// Returns a list of all puppies
    /// </summary>
    /// <returns><![CDATA[IList<Puppy>]]></returns>
    IList<Puppy> GetPuppies();

    /// <summary>
    /// Returns a specific puppy
    /// </summary>
    /// <param name = "id" >id</ param >
    /// <returns>Puppy</returns>
    Puppy GetPuppy(int id);

    /// <summary>
    /// Saves a new puppy to the system
    /// </summary>
    /// <param name="newPuppy">Puppy</param>
    void SavePuppy(Puppy newPuppy);
  }
}