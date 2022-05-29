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

        public WorkPlansRepository()
        {
            this.insert = "INSERT into WorkPlans (Name, Category) VALUES (@name, @category)";
            this.update = "UPDATE WorkPlans SET Name = @name, Category = @category";
            this.delete = "DELETE FROM WorkPlans WHERE IdWorkPlans = @idworkplan ";
            this.selectAll = "SELECT* FROM WorkPlans";
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
            };
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
                        IdWorkPlans = Convert.ToInt32(row["idWorkPlans"]),
                        Name = row["Name"].ToString(),
                        Category = row["Category"].ToString(),
                    });
                }
                return list;
            }

        }
}
