using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Works
    {
        private int _idWorks;
        private int _series;
        private int _duration;
        private int _repetitions;
        private int _restTime;
        private double _load;
        private int _intensity;
        private int _idExercises;

        public int IdWorks { get => _idWorks; set => _idWorks = value; }
        public int Series { get => _series; set => _series = value; }
        public int Duration { get => _duration; set => _duration = value; }
        public int Repetitions { get => _repetitions; set => _repetitions = value; }
        public int RestTime { get => _restTime; set => _restTime = value; }
        public double Load { get => _load; set => _load = value; }
        public int Intensity { get => _intensity; set => _intensity = value; }
        public int IdExercises { get => _idExercises; set => _idExercises = value; }
    }
}
