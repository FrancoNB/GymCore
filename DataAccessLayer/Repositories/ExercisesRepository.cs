﻿using DataAccessLayer.Entities;
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
            this.insert = "INSERT INTO Excercises (Name, Detail, QuadricepsPoints, HamstringPoints, CalvesPoints, ButtocksPoints, TrapeziusPoints, DorsalPoints, LumbarsPoints,"
                           + " PectoralPoints, AbdominalPoints, ObliquesPoints, BicepsPoints, TricepsPoints, ForearmPoints, PosteriorDeltoidsPoints, LateralDeltoidsPoints,"
                           + " AnteriorDeltoidPoints, AdductorPoints) VALUES (@name, @detail, @quadricepsPoints, @hamstringPoints, @calvesPoints, @buttocksPoints,"
                           + " @trapeziusPoints, @dorsalPoints, @lumbarPoints, @pectoralPoints, @abdominalPoints, @obliquesPoints, @bicepsPoints, @tricepsPoints, @forearmPoints,"
                           + " @posteriorDeltoidsPoints, @lateralDeltoidsPoints, @anteriorDeltoidsPoints, @adductorPoints)";

            this.update = "UPDATE Excercises SET Name = @name, Detail = @detail, QuadricepsPoints = @quadricepsPoints, HamstringPoints = @hamstringPoints, CalvesPoints = @calvesPoints, "
                           + "ButtocksPoints = @buttocksPoints, TrapeziusPoints = @trapeziusPoints, DorsalPoints = @dorsalPoints, LumbarsPoints = @lumbarPoints, PectoralPoints = @pectoralPoints, "
                           + "AbdominalPoints = @abdominalPoints, ObliquesPoints =  @obliquesPoints, BicepsPoints = @bicepsPoints, TricepsPoints = @tricepsPoints, ForearmPoints = @forearmPoints, "
                           + "PosteriorDeltoidsPoints = @posteriorDeltoidsPoints, LateralDeltoidsPoints = @lateralDeltoidsPoints, AnteriorDeltoidPoints = @anteriorDeltoidsPoints, "
                           + "AdductorPoints = @adductorPoints) WHERE IdExercises = @idExercices"; 

            this.delete = "DELETE FROM Exercises WHERE IdExercises = @idExercises";

            this.selectAll = "SELECT * FROM Exercises";

            this.selectMaxId = "SELECT Max(IdExercises) as lastid FROM Exercises";
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
                new MySqlParameter("@dorsalPoints", entity.DorsalPoints),
                new MySqlParameter("@lumbarPoints", entity.LumbarPoints),
                new MySqlParameter("@pectoraPoints", entity.PectoralPoints),
                new MySqlParameter("@abdominalPoints", entity.AbdominalPoints),
                new MySqlParameter("@obliquesPoints", entity.ObliquesPoints),
                new MySqlParameter("@bicepsPoints", entity.BicepsPoints),
                new MySqlParameter("@tricepsPoints", entity.TricepsPoints),
                new MySqlParameter("@forearmPoints", entity.ForeArmPoints),
                new MySqlParameter("@posteriorDeltoidsPoints", entity.PosteriorDeltoidsPoints),
                new MySqlParameter("@lateralDeltoidsPoints", entity.LateralDeltoidPoints),
                new MySqlParameter("@anteriorDeltoidsPoints", entity.AnteriorDeltoidPoints),
                new MySqlParameter("@adductorPoints", entity.AddcutorPoints),
            };
            return await ExecuteNonQueryAsync(insert);
        }

        public async Task<int> Update(Exercises entity)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@name", entity.Name),
                new MySqlParameter("@detail", entity.Detail),
                new MySqlParameter("@quadriceps_points", entity.QuadricepsPoints),
                new MySqlParameter("@hamstring_points", entity.HamstringPoints),
                new MySqlParameter("@calves_points", entity.CalvesPoints),
                new MySqlParameter("@buttocks_points", entity.ButtocksPoints),
                new MySqlParameter("@trapezius_points", entity.TrapeziusPoints),
                new MySqlParameter("@dorsal_points", entity.DorsalPoints),
                new MySqlParameter("@lumbar_points", entity.LumbarPoints),
                new MySqlParameter("@pectoral_points", entity.PectoralPoints),
                new MySqlParameter("@abdominal_points", entity.AbdominalPoints),
                new MySqlParameter("@obliques_points", entity.ObliquesPoints),
                new MySqlParameter("@biceps_points", entity.BicepsPoints),
                new MySqlParameter("@triceps_points", entity.TricepsPoints),
                new MySqlParameter("@forearm_points", entity.ForeArmPoints),
                new MySqlParameter("@posterior_deltoids_points", entity.PosteriorDeltoidsPoints),
                new MySqlParameter("@lateral_deltoids_points", entity.LateralDeltoidPoints),
                new MySqlParameter("@anterior_deltoids_points", entity.AnteriorDeltoidPoints),
                new MySqlParameter("@adductor_points", entity.AddcutorPoints),
                new MySqlParameter("@idExercices", entity.IdExercises)
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
                        DorsalPoints = Convert.ToInt32(row["DorsalPoints"]),
                        AbdominalPoints = Convert.ToInt32(row["AbdominalPoints"]),
                        ObliquesPoints = Convert.ToInt32(row["ObliquesPoints"]),
                        BicepsPoints = Convert.ToInt32(row["BicepsPoints"]),
                        TricepsPoints = Convert.ToInt32(row["TricepsPoints"]),
                        ForeArmPoints = Convert.ToInt32(row["ForearmPoints"]),
                        PosteriorDeltoidsPoints = Convert.ToInt32(row["PosteriorDeltoidsPoints"]),
                        LateralDeltoidPoints = Convert.ToInt32(row["LateralDeltoidsPoints"]),
                        AnteriorDeltoidPoints = Convert.ToInt32(row["AnteriorDeltoidPoints"]),
                        AddcutorPoints = Convert.ToInt32(row["AdductorPoints"]),
                        LumbarPoints = Convert.ToInt32(row["LumbarsPoints"]),
                        PectoralPoints = Convert.ToInt32(row["PectoralPoints"]),
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
