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
        public int DorsalsPoints { get => _dorsalPoints; set => _dorsalPoints = value; }
        public int AbdominalsPoints { get => _abdominalPoints; set => _abdominalPoints = value; }
        public int ObliquesPoints { get => _obliquesPoints; set => _obliquesPoints = value; }
        public int BicepsPoints { get => _bicepsPoints; set => _bicepsPoints = value; }
        public int TricepsPoints { get => _tricepsPoints; set => _tricepsPoints = value; }
        public int ForeArmPoints { get => _forearmPoints; set => _forearmPoints = value; }
        public int PosteriorDeltoidPoints { get => _posteriorDeltoidPoints; set => _posteriorDeltoidPoints = value; }
        public int LateralDeltoidPoints { get => _lateralDeltoidPoints; set => _lateralDeltoidPoints = value; }
        public int AnteriorDeltoidPoints { get => _anteriorDeltoidPoints; set => _anteriorDeltoidPoints = value; }
        public int AdductorPoints { get => _adductorPoints; set => _adductorPoints = value; }
        public int LumbarsPoints { get => _lumbarPoints; set => _lumbarPoints = value; }
        public int PectoralsPoints { get => _pectoralPoints; set => _pectoralPoints = value; }
    }
}
