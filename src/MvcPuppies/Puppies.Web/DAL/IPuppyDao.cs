using Puppies.Web.Models;
using System.Collections.Generic;

namespace Puppies.Web.DAL
{
    public interface IPuppyDao
    {
        /// <summary>
        /// Returns a list of all puppies
        /// </summary>
        /// <returns></returns>
        IList<Puppy> GetPuppies();

        /// <summary>
        /// Returns a specific puppy
        /// </summary>
        /// <param name = "id" ></ param >
        /// <returns></returns>
        Puppy GetPuppy(int id);

        /// <summary>
        /// Saves a new puppy to the system
        /// </summary>
        /// <param name="newPuppy"></param>
        /// <returns></returns>
        void SavePuppy(Puppy newPuppy);
    }
}