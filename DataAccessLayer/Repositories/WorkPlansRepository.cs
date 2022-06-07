using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
using DataAccessLayer.Support;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;


namespace DataAccessLayer.Repositories.Interfaces
{
    public class WorkPlansRepository : RepositoryControler, IWorkPlansRepository
    {
        private readonly string insert;
        private readonly string update;
        private readonly string delete;
        private readonly string selectAll;
        private readonly string selectMaxId;

        public WorkPlansRepository()
        {
            this.insert = "INSERT INTO WorkPlans (Name, Category) VALUES (@name, @category)";
            this.update = "UPDATE WorkPlans SET Name = @name, Category = @category WHERE IdWorkPlans = @idWorkPlans";
            this.delete = "DELETE FROM WorkPlans WHERE IdWorkPlans = @idWorkplans";
            this.selectAll = "SELECT * FROM WorkPlans";
            this.selectMaxId = "SELECT Max(IdWorkPlans) AS lastId FROM WorkPlans";
        }

        public async Task<int> Insert(WorkPlans entity)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@name", entity.Name),
                new MySqlParameter("@category", entity.Category),
            };
            return await ExecuteNonQueryAsync(insert);
        }

        public async Task<int> Update(WorkPlans entity)
        {
            parameters = new List<MySqlParameter>
            {
               new MySqlParameter("@name", entity.Name),
               new MySqlParameter("@category", entity.Category),
               new MySqlParameter("@idWorkPlans", entity.IdWorkPlans
            )};
            return await ExecuteNonQueryAsync(update);
        }

        public async Task<int> Delete(int id)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@idWorkPlans", id)
            };
            return await ExecuteNonQueryAsync(delete);
        }

        public async Task<IEnumerable<WorkPlans>> GetAll()
        {
            using (var table = await ExecuteReaderAsync(selectAll))
            {
                var list = new List<WorkPlans>();

                foreach (DataRow row in table.Rows)
                {
                    list.Add(new WorkPlans()
                    {
                        IdWorkPlans = Convert.ToInt32(row["IdWorkPlans"]),
                        Name = row["Name"].ToString(),
                        Category = row["Category"].ToString(),
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
