using System;
using System.Collections.Generic;
using System.Data;
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
    /// <returns><![CDATA[IList<Puppy>]]></returns>
    public IList<Puppy> GetPuppies()
    {
      var rv = new List<Puppy>();
      try
      {
        var connection = new SqlConnection(connectionString);
        using (connection)
        {
          connection.Open();
          var command = new SqlCommand(SqlScriptConstants.GET_ALL_PUPPIES_SQL, connection);

          SqlDataReader reader = command.ExecuteReader();

          if (reader.HasRows)
          {
            while (reader.Read())
            {
              var _pup = new Puppy()
              {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Weight = reader.GetInt32(2),
                Gender = reader.GetString(3),
                PaperTrained = reader.GetBoolean(4)
              };
              rv.Add(_pup);
            }
          }
          reader.Close();
        }
        return rv;
      }
      catch (SqlException ex)
      {
        throw;
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    /// <summary>
    /// Returns a specific puppy
    /// </summary>
    /// <returns>Puppy</returns>
    public Puppy GetPuppy(int id)
    {
      try
      {
        Puppy rv = null;
        var connection = new SqlConnection(connectionString);
        using (connection)
        {
          connection.Open();
          var command = new SqlCommand(SqlScriptConstants.GET_PUPPY_SQL, connection);
          command.Parameters.Add(new SqlParameter("id", id));

          SqlDataReader reader = command.ExecuteReader();

          if (reader.HasRows)
          {
            while (reader.Read())
            {
              var _pup = new Puppy()
              {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Weight = reader.GetInt32(2),
                Gender = reader.GetString(3),
                PaperTrained = reader.GetBoolean(4)
              };
              rv = _pup;
            }
          }
          reader.Close();
        }
        return rv;
      }
      catch (SqlException ex)
      {
        throw;
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    /// <summary>
    /// Saves a new puppy to the system.
    /// </summary>
    /// <param name="newPuppy"></param>
    public void SavePuppy(Puppy newPuppy)
    {
      try
      {
        var connection = new SqlConnection(connectionString);
        using (connection)
        {
          connection.Open();
          var command = new SqlCommand(SqlScriptConstants.SAVE_PUPPY_SQL, connection);
          command.Parameters.Add(new SqlParameter("name", newPuppy.Name));
          command.Parameters.Add(new SqlParameter("weight", newPuppy.Weight));
          command.Parameters.Add(new SqlParameter("gender", newPuppy.Gender));
          command.Parameters.Add(new SqlParameter("paper_trained", newPuppy.PaperTrained));

          _ = command.ExecuteNonQuery();
        }
      }
      catch (SqlException ex)
      {
        throw;
      }
      catch (Exception ex)
      {
        throw;
      }
    }
  }
}
