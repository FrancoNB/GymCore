using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.ValueObjects;
using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLayer.Models
{
    public class ExercisesModel
    {

        private int _idExercises;
        private string _name;
        private string _detail;
        private int _quadricepsPoints;
        private int _hamstringPoints;
        private int _calvesPoints;
        private int _buttocksPoints;
        private int _trapeziusPoints;
        private int _dorsalPoints;
        private int _abdominalPoints;
        private int _obliquesPoints;
        private int _bicepsPoints;
        private int _tricepsPoints;
        private int _forearmPoints;
        private int _posteriorDeltoidPoints;
        private int _lateralDeltoidPoints;
        private int _anteriorDeltoidPoints;
        private int _adductorPoints;
        private int _lumbarPoints;
        private int _pectoralPoints;

        public int IdExercises { get => _idExercises; set => _idExercises = value; }
        public string Name { get => _name; set => _name = value; }
        public string Detail { get => _detail; set => _detail = value; }
        public int HamstringPoints { get => _hamstringPoints; set => _hamstringPoints = value; }
        public int QuadricepsPoints { get => _quadricepsPoints; set => _quadricepsPoints = value; }
        public int CalvesPoints { get => _calvesPoints; set => _calvesPoints = value; }
        public int ButtocksPoints { get => _buttocksPoints; set => _buttocksPoints = value; }
        public int TrapeziusPoints { get => _trapeziusPoints; set => _trapeziusPoints = value; }
        public int DorsalPoints { get => _dorsalPoints; set => _dorsalPoints = value; }
        public int AbdominalPoints { get => _abdominalPoints; set => _abdominalPoints = value; }
        public int ObliquesPoints { get => _obliquesPoints; set => _obliquesPoints = value; }
        public int BicepsPoints { get => _bicepsPoints; set => _bicepsPoints = value; }
        public int TricepsPoints { get => _tricepsPoints; set => _tricepsPoints = value; }
        public int ForeArmPoints { get => _forearmPoints; set => _forearmPoints = value; }
        public int PosteriorDeltoidPoints { get => _posteriorDeltoidPoints; set => _posteriorDeltoidPoints = value; }
        public int LateralDeltoidPoints { get => _lateralDeltoidPoints; set => _lateralDeltoidPoints = value; }
        public int AnteriorDeltoidPoints { get => _anteriorDeltoidPoints; set => _anteriorDeltoidPoints = value; }
        public int AdductorPoints { get => _adductorPoints; set => _adductorPoints = value; }
        public int LumbarPoints { get => _lumbarPoints; set => _lumbarPoints = value; }
        public int PectoralPoints { get => _pectoralPoints; set => _pectoralPoints = value; }

        private IExercisesRepository repository;

        public Operation Operation { get; set; }

        public ExercisesModel()
        {
            repository = new ExercisesRepository();
        }

        public ExercisesModel(IExercisesRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AcctionResult> SaveChanges()
        {
            try
            {
                switch (Operation)
                {
                    case Operation.Insert:
                        ValidateInsert();
                        await repository.Insert(GetDataEntity());
                        return new AcctionResult(true, "Ejercicio guardado correctamente...!");
                    
                    case Operation.Update:
                        ValidateUpdate();  
                        await repository.Update(GetDataEntity());
                        return new AcctionResult(true, "Ejercicio modificado correctamente...!");
                    
                    case Operation.Delete:
                        ValidateDelete();
                        await repository.Delete(IdExercises);
                        return new AcctionResult(true, "Ejercicio eliminado correctamente...!");
                    
                    default:
                        return new AcctionResult(false, "No se estableció la operacion a realizar...!");
                }
            }
            catch (Exception ex)
            {
                return new AcctionResult(false, ex.Message);
            }
        }
        public async Task<IEnumerable<ExercisesModel>> GetAll()
        {
            var dataModel = await repository.GetAll();

            var list = new List<ExercisesModel>();
            
            foreach(Exercises item in dataModel)
            {
                list.Add(new ExercisesModel
                {
                    IdExercises = item.IdExercises,
                    Name = item.Name,
                    Detail = item.Detail,
                    HamstringPoints = item.HamstringPoints,
                    QuadricepsPoints = item.QuadricepsPoints,
                    CalvesPoints = item.CalvesPoints,
                    ButtocksPoints = item.ButtocksPoints,
                    TrapeziusPoints = item.TrapeziusPoints,
                    DorsalPoints = item.DorsalsPoints,
                    AbdominalPoints = item.AbdominalsPoints,
                    ObliquesPoints = item.ObliquesPoints,
                    BicepsPoints = item.BicepsPoints,
                    TricepsPoints = item.TricepsPoints,
                    ForeArmPoints = item.ForeArmPoints,
                    PosteriorDeltoidPoints = item.PosteriorDeltoidPoints,
                    LateralDeltoidPoints = item.LateralDeltoidPoints,
                    AnteriorDeltoidPoints = item.AnteriorDeltoidPoints,
                    AdductorPoints = item.AdductorPoints,
                    LumbarPoints = item.LumbarPoints,
                    PectoralPoints = item.PectoralsPoints,
                });
            }
            return list;
        }

        private Exercises GetDataEntity()
        {
            return new Exercises()
            {
                IdExercises = this.IdExercises,
                Name = this.Name,
                Detail = this.Detail,
                HamstringPoints = this.HamstringPoints,
                QuadricepsPoints = this.QuadricepsPoints,
                CalvesPoints = this.CalvesPoints,
                ButtocksPoints = this.ButtocksPoints,
                TrapeziusPoints = this.TrapeziusPoints,
                DorsalsPoints = this.DorsalPoints,
                AbdominalsPoints = this.AbdominalPoints,
                ObliquesPoints = this.ObliquesPoints,
                BicepsPoints = this.BicepsPoints,
                TricepsPoints = this.TricepsPoints,
                ForeArmPoints = this.ForeArmPoints,
                PosteriorDeltoidPoints = this.PosteriorDeltoidPoints,
                LateralDeltoidPoints = this.LateralDeltoidPoints,
                AnteriorDeltoidPoints = this.AnteriorDeltoidPoints,
                AdductorPoints = this.AdductorPoints,
                LumbarPoints = this.LumbarPoints,
                PectoralsPoints = this.PectoralPoints,
            };
        }
        private void ValidateInsert() {
        
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("Se debe especificar el nombre del ejercicio... !");

            if (string.IsNullOrEmpty(Detail))
                Detail = "-";

            if (HamstringPoints > 100 || HamstringPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");
            
            if (QuadricepsPoints > 100 || QuadricepsPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (CalvesPoints > 100 || CalvesPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (ButtocksPoints > 100 || ButtocksPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (TrapeziusPoints > 100 || TrapeziusPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (DorsalPoints > 100 || DorsalPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (AbdominalPoints > 100 || AbdominalPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (ObliquesPoints > 100 || ObliquesPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (BicepsPoints > 100 || BicepsPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (TricepsPoints > 100 || TricepsPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (ForeArmPoints > 100 || ForeArmPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (PosteriorDeltoidPoints > 100 || PosteriorDeltoidPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (LateralDeltoidPoints > 100 || LateralDeltoidPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (AnteriorDeltoidPoints > 100 || AnteriorDeltoidPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (AdductorPoints > 100 || AdductorPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (LumbarPoints > 100 || LumbarPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (PectoralPoints > 100 || PectoralPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");
        }
        private void ValidateUpdate()
        {
            if (IdExercises < 1)
                throw new ArgumentException("No se seleccionó ningún ejercicio...!");

            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("Se debe especificar el nombre del ejercicio... !");

            if (string.IsNullOrEmpty(Detail))
                Detail = "-";

            if (HamstringPoints > 100 || HamstringPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (QuadricepsPoints > 100 || QuadricepsPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (CalvesPoints > 100 || CalvesPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (ButtocksPoints > 100 || ButtocksPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (TrapeziusPoints > 100 || TrapeziusPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (DorsalPoints > 100 || DorsalPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (AbdominalPoints > 100 || AbdominalPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (ObliquesPoints > 100 || ObliquesPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (BicepsPoints > 100 || BicepsPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (TricepsPoints > 100 || TricepsPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (ForeArmPoints > 100 || ForeArmPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (PosteriorDeltoidPoints > 100 || PosteriorDeltoidPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (LateralDeltoidPoints > 100 || LateralDeltoidPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (AnteriorDeltoidPoints > 100 || AnteriorDeltoidPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (AdductorPoints > 100 || AdductorPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (LumbarPoints > 100 || LumbarPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");

            if (PectoralPoints > 100 || PectoralPoints < 0)
                throw new ArgumentException("El valor debe estar en un rango entre 0 y 100...!");
        }
        private void ValidateDelete()
        {
            if (IdExercises < 1)
                throw new ArgumentException("No se seleccionó ningún ejercicio para eliminar...!");
        }

    }
}
