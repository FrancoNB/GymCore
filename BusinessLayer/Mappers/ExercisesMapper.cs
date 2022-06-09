using BusinessLayer.Models;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mappers
{
    public static class ExercisesMapper
    {
        public static Exercises Adapter(ExercisesModel model)
        {
            if (model == null) return null;

            return new Exercises
            {
                IdExercises = model.IdExercises,
                Name = model.Name,
                Detail = model.Detail,
                HamstringPoints = model.HamstringPoints,
                QuadricepsPoints = model.QuadricepsPoints,
                CalvesPoints = model.CalvesPoints,
                ButtocksPoints = model.ButtocksPoints,
                TrapeziusPoints = model.TrapeziusPoints,
                DorsalsPoints = model.DorsalsPoints,
                AbdominalsPoints = model.AbdominalsPoints,
                ObliquesPoints = model.ObliquesPoints,
                BicepsPoints = model.BicepsPoints,
                TricepsPoints = model.TricepsPoints,
                ForeArmPoints = model.ForeArmPoints,
                PosteriorDeltoidPoints = model.PosteriorDeltoidPoints,
                LateralDeltoidPoints = model.LateralDeltoidPoints,
                AnteriorDeltoidPoints = model.AnteriorDeltoidPoints,
                AdductorPoints = model.AdductorPoints,
                LumbarsPoints = model.LumbarsPoints,
                PectoralsPoints = model.PectoralsPoints
            };
        }

        public static ExercisesModel Adapter(Exercises entity)
        {
            if (entity == null) return null;

            return new ExercisesModel
            {
                IdExercises = entity.IdExercises,
                Name = entity.Name,
                Detail = entity.Detail,
                HamstringPoints = entity.HamstringPoints,
                QuadricepsPoints = entity.QuadricepsPoints,
                CalvesPoints = entity.CalvesPoints,
                ButtocksPoints = entity.ButtocksPoints,
                TrapeziusPoints = entity.TrapeziusPoints,
                DorsalsPoints = entity.DorsalsPoints,
                AbdominalsPoints = entity.AbdominalsPoints,
                ObliquesPoints = entity.ObliquesPoints,
                BicepsPoints = entity.BicepsPoints,
                TricepsPoints = entity.TricepsPoints,
                ForeArmPoints = entity.ForeArmPoints,
                PosteriorDeltoidPoints = entity.PosteriorDeltoidPoints,
                LateralDeltoidPoints = entity.LateralDeltoidPoints,
                AnteriorDeltoidPoints = entity.AnteriorDeltoidPoints,
                AdductorPoints = entity.AdductorPoints,
                LumbarsPoints = entity.LumbarsPoints,
                PectoralsPoints = entity.PectoralsPoints
            };
        }

        public static IEnumerable<Exercises> AdapterList(IEnumerable<ExercisesModel> models)
        {
            var entities = new List<Exercises>();

            foreach (ExercisesModel item in models)
            {
                entities.Add(Adapter(item));
            }

            return entities;
        }

        public static IEnumerable<ExercisesModel> AdapterList(IEnumerable<Exercises> entities)
        {
            var models = new List<ExercisesModel>();

            foreach (Exercises item in entities)
            {
                models.Add(Adapter(item));
            }

            return models;
        }
    }
}
