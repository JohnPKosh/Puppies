using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using Microsoft.Extensions.Logging;

using Puppies.Web.Models;

namespace Puppies.Web.DAL
{
  public class PuppySqlDao : IPuppyDao
  {
    private readonly ILogger<PuppySqlDao> _logger;
    private readonly string _connectionString;

    public PuppySqlDao(ILogger<PuppySqlDao> logger, string connectionString)
    {
      _logger = logger;
      _connectionString = connectionString;
    }

    ///<inheritdoc cref="IPuppyDao.GetPuppies"/>
    /// <remarks>
    /// For simplicty sake ADO.net is used here. Alternate implementations could use EF, Dapper, or other micro-orms
    /// </remarks>
    public IList<Puppy> GetPuppies()
    {
      var rv = new List<Puppy>();
      try
      {
        var connection = new SqlConnection(_connectionString);
        using (connection)
        {
          connection.Open();
          var command = new SqlCommand(SqlScriptConstants.GET_ALL_PUPPIES_SQL, connection);

          SqlDataReader reader = command.ExecuteReader();

          if (reader.HasRows)
          {
            while (reader.Read())
            {             
              var _pup = new Puppy  // TODO: consider using the other Puppy constructor if you prefer.
              {
                Id = reader.GetInt32(0),   // Referencing by position done for simplicity here.
                Name = reader.GetString(1),
                Weight = reader.IsDBNull(3) ? 0 : reader.GetInt32(2),   // perhaps we don't know how much?
                Gender = reader.IsDBNull(3) ? null : reader.GetString(3), // perhaps we are not sure?
                PaperTrained = reader.IsDBNull(3) ? false : reader.GetBoolean(4)
              };
              rv.Add(_pup);
            }
          }
          reader.Close();
        }
#if DEBUG
        _logger.LogInformation("GetPuppies ALL from SQL Server called");  // TODO: Implement full logging solution when building production app
#endif
        return rv;
      }
      catch (SqlException ex)
      {
        _logger.LogError(ex, "GetPuppies ALL SqlException - {1}",  ex.Message);
        throw;
      }
      catch (Exception ex)  // TODO: Add basic catch-all library exception type instead of using System.Exception
      {
        _logger.LogError(ex, "GetPuppies ALL Exception - {1}", ex.Message);
        throw;
      }
    }

    ///<inheritdoc cref="IPuppyDao.GetPuppy(int)"/>
    /// <remarks>
    /// For simplicty sake ADO.net is used here. Alternate implementations could use EF, Dapper, or other micro-orms
    /// </remarks>
    public Puppy GetPuppy(int id)
    {
      try
      {
        Puppy rv = null;
        var connection = new SqlConnection(_connectionString);
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
              var _pup = new Puppy // TODO: consider using the other Puppy constructor if you prefer.
              {
                Id = reader.GetInt32(0),    // Referencing by position done for simplicity here.
                Name = reader.GetString(1),
                Weight = reader.IsDBNull(3) ? 0 : reader.GetInt32(2),   // perhaps we don't know how much?
                Gender = reader.IsDBNull(3) ? null : reader.GetString(3), // perhaps we are not sure?
                PaperTrained = reader.IsDBNull(3) ? false : reader.GetBoolean(4)
              };
              rv = _pup;
            }
          }
          reader.Close();
        }
#if DEBUG
        _logger.LogInformation("GetPuppy({0}) from SQL Server called", id);  // TODO: Implement full logging solution when building production app
#endif
        return rv;
      }
      catch (SqlException ex)
      {
        _logger.LogError(ex, "GetPuppy SqlException ({0}) - {1}", id, ex.Message);
        throw;
      }
      catch (Exception ex)  // TODO: Add basic catch-all library exception type instead of using System.Exception
      {
        _logger.LogError(ex, "GetPuppy ({0}) - {1}", id, ex.Message);
        throw;
      }
    }

    ///<inheritdoc cref="IPuppyDao.SavePuppy(Puppy)"/>
    /// <remarks>
    /// For simplicty sake ADO.net is used here. Alternate implementations could use EF, Dapper, or other micro-orms
    /// </remarks>
    public void SavePuppy(Puppy newPuppy)
    {
      try
      {
        var connection = new SqlConnection(_connectionString);
        using (connection)
        {
          connection.Open();
          var command = new SqlCommand(SqlScriptConstants.SAVE_PUPPY_SQL, connection);
          command.Parameters.Add(new SqlParameter("name", newPuppy.Name));
          command.Parameters.Add(new SqlParameter("weight", newPuppy.Weight));
          if (newPuppy.Gender == null)
          {
            command.Parameters.Add(new SqlParameter("gender", DBNull.Value));
          }
          else
          {
            command.Parameters.Add(new SqlParameter("gender", newPuppy.Gender));
          }
          command.Parameters.Add(new SqlParameter("paper_trained", newPuppy.PaperTrained));

          _ = command.ExecuteNonQuery();
#if DEBUG
          _logger.LogInformation("SavePuppy {0} to SQL Server called", newPuppy.Name);  // TODO: Implement full logging solution when building production app
#endif
        }
      }
      catch (SqlException ex)
      {
        _logger.LogError(ex, "SavePuppy SqlException - {1}", ex.Message);
        throw;
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "SavePuppy Exception - {1}", ex.Message);
        throw;
      }
    }
  }
}
