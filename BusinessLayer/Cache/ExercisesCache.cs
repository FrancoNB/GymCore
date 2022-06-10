using BusinessLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer.Cache
{
    public class ExercisesCache : Subscribeable<ExercisesModel>
    {
        private static ExercisesCache instance;

        private static readonly object _lock = new object();
        public static ExercisesCache GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ExercisesCache();
                    }
                }
            }

            return instance;
        }

        private ExercisesCache()
        {
            _resource = new List<ExercisesModel>();
            _subscriberList = new List<ISubscriber<ExercisesModel>>();
        }
    }
}
