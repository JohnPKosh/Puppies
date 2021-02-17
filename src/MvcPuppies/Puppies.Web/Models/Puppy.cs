using System.ComponentModel.DataAnnotations;

namespace Puppies.Web.Models
{
  /// <summary>
  /// The Puppy class model that encapsulates the basic properties of a dog
  /// </summary>
  public class Puppy
  {
    /// <summary>
    /// Default paramterless constructor
    /// </summary>
    public Puppy() { }

    /// <summary>
    /// A convenience constructor for creating a Puppy (for use on save new)
    /// </summary>
    /// <param name="name">The name (Required)</param>
    /// <param name="weight">weight in lbs</param>
    /// <param name="gender">Gender (Male, Female)</param>
    /// <param name="paperTrained">bool</param>
    public Puppy(string name, int weight, string gender, bool paperTrained)
    {
      Name = name;
      Weight = weight;
      Gender = gender;
      PaperTrained = paperTrained;
    }

    /// <summary>
    /// A convenience constructor for creating an existing Puppy (for retrieval from data store)
    /// </summary>
    /// <param name="id">int identifier</param>
    /// <param name="name">The name</param>
    /// <param name="weight">weight in lbs</param>
    /// <param name="gender">Gender (Male, Female)</param>
    /// <param name="paperTrained">bool</param>
    public Puppy(int id, string name, int weight, string gender, bool paperTrained)
    {
      Id = id;
      Name = name;
      Weight = weight;
      Gender = gender;
      PaperTrained = paperTrained;
    }

    /// <summary>
    /// The Id from the data store location
    /// </summary>
    public int Id { get; set; }

    [StringLength(50, MinimumLength = 1)]    // We only need to decorate name as required since every puppy should have a cute name
    [Required]
    /// <summary>
    /// The name of the puppy
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The weight in lbs.
    /// </summary>
    public int Weight { get; set; }

    /// <summary>
    /// The gender as string (Male, Female)
    /// </summary>
    public string Gender { get; set; }

    /// <summary>
    /// Boolean indicating if your house is a mess!
    /// </summary>
    public bool PaperTrained { get; set; }

  }
}
