using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Puppies.Web.DAL
{
  public static class SqlScriptConstants
  {
    /// <summary>SELECTs all rows from the puppies table ordered by Id Asc (for consistency sake only)</summary>
    public const string GET_ALL_PUPPIES_SQL =
@"
SELECT [id]
      ,[name]
      ,[weight]
      ,[gender]
      ,[paper_trained]
FROM [dbo].[puppies]
ORDER BY [id]
";

    /// <summary>SELECTs all rows from the puppies table</summary>
    public const string GET_PUPPY_SQL =
@"
SELECT [id]
      ,[name]
      ,[weight]
      ,[gender]
      ,[paper_trained]
FROM [dbo].[puppies]
WHERE [id] = @id
";

    /// <summary>INSERTs a row into the puppies table</summary>
    public const string SAVE_PUPPY_SQL =
@"
INSERT INTO [dbo].[puppies]
           ([name]
           ,[weight]
           ,[gender]
           ,[paper_trained])
     VALUES
           (@name
           ,@weight
           ,@gender
           ,@paper_trained)
";
  }
}
