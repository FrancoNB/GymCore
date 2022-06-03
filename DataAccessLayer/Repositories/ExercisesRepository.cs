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
    public class ExercisesRepository : RepositoryControler, IExercisesRepository
    {
        private readonly string insert;
        private readonly string update;
        private readonly string delete;
        private readonly string selectAll;
        private readonly string selectMaxId;

        public ExercisesRepository()
        {
            this.insert = "INSERT INTO Exercises (Name, Detail, QuadricepsPoints, HamstringPoints, CalvesPoints, ButtocksPoints, TrapeziusPoints, DorsalsPoints, LumbarsPoints,"
                           + " PectoralsPoints, AbdominalsPoints, ObliquesPoints, BicepsPoints, TricepsPoints, ForearmPoints, PosteriorDeltoidPoints, LateralDeltoidPoints,"
                           + " AnteriorDeltoidPoints, AdductorPoints) VALUES (@name, @detail, @quadricepsPoints, @hamstringPoints, @calvesPoints, @buttocksPoints,"
                           + " @trapeziusPoints, @dorsalsPoints, @lumbarsPoints, @pectoralsPoints, @abdominalsPoints, @obliquesPoints, @bicepsPoints, @tricepsPoints, @forearmPoints,"
                           + " @posteriorDeltoidPoints, @lateralDeltoidPoints, @anteriorDeltoidPoints, @adductorPoints)";

            this.update = "UPDATE Exercises SET Name = @name, Detail = @detail, QuadricepsPoints = @quadricepsPoints, HamstringPoints = @hamstringPoints, CalvesPoints = @calvesPoints, "
                           + "ButtocksPoints = @buttocksPoints, TrapeziusPoints = @trapeziusPoints, DorsalsPoints = @dorsalsPoints, LumbarsPoints = @lumbarsPoints, PectoralsPoints = @pectoralsPoints, "
                           + "AbdominalsPoints = @abdominalsPoints, ObliquesPoints =  @obliquesPoints, BicepsPoints = @bicepsPoints, TricepsPoints = @tricepsPoints, ForearmPoints = @forearmPoints, "
                           + "PosteriorDeltoidPoints = @posteriorDeltoidPoints, LateralDeltoidPoints = @lateralDeltoidPoints, AnteriorDeltoidPoints = @anteriorDeltoidPoints, "
                           + "AdductorPoints = @adductorPoints WHERE IdExercises = @idExercises"; 

            this.delete = "DELETE FROM Exercises WHERE IdExercises = @idExercises";

            this.selectAll = "SELECT * FROM Exercises";

            this.selectMaxId = "SELECT Max(IdExercises) as lastId FROM Exercises";
        }

        public async Task<int> Insert(Exercises entity)
        {
            parameters = new List<MySqlParameter> {

                new MySqlParameter("@name", entity.Name),
                new MySqlParameter("@detail", entity.Detail),
                new MySqlParameter("@quadricepsPoints", entity.QuadricepsPoints),
                new MySqlParameter("@hamstringPoints", entity.HamstringPoints),
                new MySqlParameter("@calvesPoints", entity.CalvesPoints),
                new MySqlParameter("@buttocksPoints", entity.ButtocksPoints),
                new MySqlParameter("@trapeziusPoints", entity.TrapeziusPoints),
                new MySqlParameter("@dorsalsPoints", entity.DorsalsPoints),
                new MySqlParameter("@lumbarsPoints", entity.LumbarsPoints),
                new MySqlParameter("@pectoralsPoints", entity.PectoralsPoints),
                new MySqlParameter("@abdominalsPoints", entity.AbdominalsPoints),
                new MySqlParameter("@obliquesPoints", entity.ObliquesPoints),
                new MySqlParameter("@bicepsPoints", entity.BicepsPoints),
                new MySqlParameter("@tricepsPoints", entity.TricepsPoints),
                new MySqlParameter("@forearmPoints", entity.ForeArmPoints),
                new MySqlParameter("@posteriorDeltoidPoints", entity.PosteriorDeltoidPoints),
                new MySqlParameter("@lateralDeltoidPoints", entity.LateralDeltoidPoints),
                new MySqlParameter("@anteriorDeltoidPoints", entity.AnteriorDeltoidPoints),
                new MySqlParameter("@adductorPoints", entity.AdductorPoints),
            };
            return await ExecuteNonQueryAsync(insert);
        }

        public async Task<int> Update(Exercises entity)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@name", entity.Name),
                new MySqlParameter("@detail", entity.Detail),
                new MySqlParameter("@quadricepsPoints", entity.QuadricepsPoints),
                new MySqlParameter("@hamstringPoints", entity.HamstringPoints),
                new MySqlParameter("@calvesPoints", entity.CalvesPoints),
                new MySqlParameter("@buttocksPoints", entity.ButtocksPoints),
                new MySqlParameter("@trapeziusPoints", entity.TrapeziusPoints),
                new MySqlParameter("@dorsalsPoints", entity.DorsalsPoints),
                new MySqlParameter("@lumbarsPoints", entity.LumbarsPoints),
                new MySqlParameter("@pectoralsPoints", entity.PectoralsPoints),
                new MySqlParameter("@abdominalsPoints", entity.AbdominalsPoints),
                new MySqlParameter("@obliquesPoints", entity.ObliquesPoints),
                new MySqlParameter("@bicepsPoints", entity.BicepsPoints),
                new MySqlParameter("@tricepsPoints", entity.TricepsPoints),
                new MySqlParameter("@forearmPoints", entity.ForeArmPoints),
                new MySqlParameter("@posteriorDeltoidPoints", entity.PosteriorDeltoidPoints),
                new MySqlParameter("@lateralDeltoidPoints", entity.LateralDeltoidPoints),
                new MySqlParameter("@anteriorDeltoidPoints", entity.AnteriorDeltoidPoints),
                new MySqlParameter("@adductorPoints", entity.AdductorPoints),
                new MySqlParameter("@idExercises", entity.IdExercises)
            };
            return await ExecuteNonQueryAsync(update);
        }

        public async Task<int> Delete(int id)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@idExercises", id)
            };
            return await ExecuteNonQueryAsync(delete);
        }

        public async Task<IEnumerable<Exercises>> GetAll()
        {
            using (var table = await ExecuteReaderAsync(selectAll))
            {
                var list = new List<Exercises>();

                foreach (DataRow row in table.Rows)
                {
                    list.Add(new Exercises()
                    {
                        IdExercises = Convert.ToInt32(row["IdExercises"]),
                        Name = row["Name"].ToString(),
                        Detail = row["Detail"].ToString(),
                        QuadricepsPoints = Convert.ToInt32(row["QuadricepsPoints"]),
                        HamstringPoints = Convert.ToInt32(row["HamstringPoints"]),
                        CalvesPoints = Convert.ToInt32(row["CalvesPoints"]),
                        ButtocksPoints = Convert.ToInt32(row["ButtocksPoints"]),
                        TrapeziusPoints = Convert.ToInt32(row["TrapeziusPoints"]),
                        DorsalsPoints = Convert.ToInt32(row["DorsalsPoints"]),
                        AbdominalsPoints = Convert.ToInt32(row["AbdominalsPoints"]),
                        ObliquesPoints = Convert.ToInt32(row["ObliquesPoints"]),
                        BicepsPoints = Convert.ToInt32(row["BicepsPoints"]),
                        TricepsPoints = Convert.ToInt32(row["TricepsPoints"]),
                        ForeArmPoints = Convert.ToInt32(row["ForearmPoints"]),
                        PosteriorDeltoidPoints = Convert.ToInt32(row["PosteriorDeltoidPoints"]),
                        LateralDeltoidPoints = Convert.ToInt32(row["LateralDeltoidPoints"]),
                        AnteriorDeltoidPoints = Convert.ToInt32(row["AnteriorDeltoidPoints"]),
                        AdductorPoints = Convert.ToInt32(row["AdductorPoints"]),
                        LumbarsPoints = Convert.ToInt32(row["LumbarsPoints"]),
                        PectoralsPoints = Convert.ToInt32(row["PectoralsPoints"])
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