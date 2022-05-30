﻿using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
using DataAccessLayer.Support;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;


namespace DataAccessLayer.Repositories.Interfaces
{    internal class WorksRepositorys : RepositoryControler, IWorksRepository
    {
        private readonly string insert;
        private readonly string update;
        private readonly string delete;
        private readonly string selectAll;
        private readonly string selectMaxId;

        public WorksRepositorys()
        {
            this.insert = "INSERT into Works (Series, Duration, Repetitions, RestTime, Load, Intensity, IdExercises) VALUES (@series, @duration, @repetiotions, @restTimes, @load, "
                        + "@intensity, @idExercises";
            this.update = "UPDATE Works SET Series = @series, Duration = @duration, Repetitions = @repetitions, RestTimes = @restTimes, Load = @load, Intensity = @intensity, "
                        + "IdExercices = @idExercises WHERE IdWorks = @idWorks";
            this.delete = "DELETE FROM WorkPlans WHERE IdWorks = @idWorks";

            this.selectAll = "SELECT* FROM Works";

            this.selectMaxId = "SELECT Max(IdWorks) as lastid FROM Works";
        }

        public async Task<int> Insert(Works entity)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@series", entity.Series),
                new MySqlParameter("@duration", entity.Duration),
                new MySqlParameter("@repetitions", entity.Repetitions),
                new MySqlParameter("@restTimes", entity.RestTime),
                new MySqlParameter("@load", entity.Load),
                new MySqlParameter("@intensity", entity.Intensity),
                new MySqlParameter("@idExercises", entity.IdExercises)
            };
            return await ExecuteNonQueryAsync(insert);
        }

        public async Task<int> Update(Works entity)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@series", entity.Series),
                new MySqlParameter("@duration", entity.Duration),
                new MySqlParameter("@repetitions", entity.Repetitions),
                new MySqlParameter("@restTimes", entity.RestTime),
                new MySqlParameter("@load", entity.Load),
                new MySqlParameter("@intensity", entity.Intensity),
                new MySqlParameter("@idExercises", entity.IdExercises),
                new MySqlParameter("@idWorks",entity.IdWorks)
            };
            return await ExecuteNonQueryAsync(update);
        }

        public async Task<int> Delete(int id)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@idWorks", id)
            };
            return await ExecuteNonQueryAsync(delete);
        }

        public async Task<IEnumerable<Works>> GetAll()
        {
            using (var table = await ExecuteReaderAsync(selectAll))
            {
                var list = new List<Works>();

                foreach (DataRow row in table.Rows)
                {
                    list.Add(new Works()
                    {
                        IdWorks = Convert.ToInt32(row["IdWorkPlans"]),
                        Series = Convert.ToInt32(row["Series"]),
                        Duration = Convert.ToInt32(row["Duration"]),
                        Repetitions = Convert.ToInt32(row["Repetitions"]),
                        RestTime = Convert.ToInt32(row["RestTimes"]),
                        Load = Convert.ToDouble(row["Load"]),
                        Intensity = Convert.ToInt32(row["Intensity"]),
                        IdExercises = Convert.ToInt32(row["IdExcercises"])
                    });
                }
                return list;
            }
        }

        public async Task<int> GetLastId() 
        {
            using (var table = await ExecuteReaderAsync(selectMaxId))
            {
                if (table.Rows.Count > 0)
                    return Convert.ToInt32(table.Rows[0]["lastId"]);
                else
                    return 0;
            }
        }
    }
}
