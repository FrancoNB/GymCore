using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Exercises 
    {
        private int _idExercises;
        private string _name;
        private string _detail;
        private int _quadriceps_points;
        private int _hamstring_points;
        private int _calves_points;
        private int _buttocks_points;
        private int _trapezius_points;
        private int _dorsal_points;
        private int _abdominal_points;
        private int _obliques_points;
        private int _biceps_points;
        private int _triceps_points;
        private int _forearm_points;
        private int _posterior_deltoid_points;
        private int _lateral_deltoid_points;
        private int _anterior_deltoid_points;
        private int _adductor_points;

        public int IdExercises { get => _idExercises; set => _idExercises = value; }
        public string Name { get => _name; set => _name = value; }
        public string Detail { get => _detail; set => _detail = value; }
        public int HamstringPoints { get => _hamstring_points; set => _hamstring_points = value; }
        public int QuadricepsPoints { get => _quadriceps_points; set => _quadriceps_points = value; }
        public int CalvesPoints { get => _calves_points; set => _calves_points = value; }
        public int ButtocksPoints { get => _buttocks_points; set => _buttocks_points = value; }
        public int TrapeziusPoints { get => _trapezius_points; set => _trapezius_points = value; }
        public int DorsalPoints { get => _dorsal_points; set => _dorsal_points = value; }
        public int AbdominalPoints { get => _abdominal_points; set => _abdominal_points = value; }
        public int ObliquesPoints { get => _obliques_points; set => _obliques_points = value; }
        public int BicepsPoints { get => _biceps_points; set => _biceps_points = value; }
        public int TricepsPoints { get => _triceps_points; set => _triceps_points = value; }
        public int ForeArmPoints { get => _forearm_points; set => _forearm_points = value; }
        public int PosteriorDeltoidsPoints { get => _posterior_deltoid_points; set => _posterior_deltoid_points = value; }
        public int LateralDeltoidPoints { get => _lateral_deltoid_points; set => _lateral_deltoid_points = value; }
        public int AnteriorDeltoidPoints { get => _anterior_deltoid_points; set => _anterior_deltoid_points = value; }
        public int AddcutorPoints { get => _adductor_points; set => _adductor_points = value; }

    }
}
