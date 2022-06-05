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
    public class WorkPlansDetailRepository : RepositoryControler, IWorkPlansDetailRepository
    {
        private readonly string insert;
        private readonly string update;
        private readonly string delete;
        private readonly string selectAll;
        private readonly string selectMaxId;


        public WorkPlansDetailRepository()
        {
            this.insert = "INSERT INTO WorkPlansDetail (Day, WorkPlans_idWorkPlans, Works_idWorks) VALUES (@day, @idWorkPlans, @idWorks)";
            this.update = "UPDATE WorkPlansDetail SET Day = @day, WorkPlans_idWorkPlans = @idWorkPlans, Works_idWorks = @idWorks WHERE IdWorkPlansDetail = @idWorkPlansDetail";
            this.delete = "DELETE FROM WorkPlansDetail WHERE idWorkPlansDetail = @idWorkplansDetail";
            this.selectAll = "SELECT * FROM WorkPlansDetail";
            this.selectMaxId = "SELECT Max(IdWorkPlansDetail) AS lastId FROM WorkPlansDetail";
        }

        public async Task<int> Insert(WorkPlansDetail entity)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@day", entity.Day),
                new MySqlParameter("@idWorkPlans", entity.IdWorkPlans),
                new MySqlParameter("@idWorks", entity.IdWorks)

            };
            return await ExecuteNonQueryAsync(insert);
        }

        public async Task<int> Update(WorkPlansDetail entity)
        {
            parameters = new List<MySqlParameter>
            {
               new MySqlParameter("@day", entity.Day),
               new MySqlParameter("@idWorkPlans", entity.IdWorkPlans),
               new MySqlParameter("@idWorks", entity.IdWorks),
               new MySqlParameter("@idWorkPlansDetail", entity.IdWorkPlansDetail)
            };
            return await ExecuteNonQueryAsync(update);
        }

        public async Task<int> Delete(int id)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@idWorkPlansDetail", id)
            };
            return await ExecuteNonQueryAsync(delete);
        }

        public async Task<IEnumerable<WorkPlansDetail>> GetAll()
        {
            using (var table = await ExecuteReaderAsync(selectAll))
            {
                var list = new List<WorkPlansDetail>();

                foreach (DataRow row in table.Rows)
                {
                    list.Add(new WorkPlansDetail()
                    {
                        IdWorkPlansDetail = Convert.ToInt32(row["IdWorkPlansDetail"]),
                        IdWorks = Convert.ToInt32(row["Works_idWorks"]),
                        IdWorkPlans = Convert.ToInt32(row["WorkPlans_idWorkPlans"]),
                        Day = Convert.ToInt32(row["Day"])
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
