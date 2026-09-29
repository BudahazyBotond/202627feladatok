using System;
using System.Collections.Generic;
using System.Text;

namespace MikulasCukraszda_lib
{
    public class Feladatok
    {
        public List<Feladat> FeladatokList { get; } = new();

        public static Feladatok operator +(Feladatok tasks, Feladat feladat)
        {
            //if (tasks is null) throw new ArgumentNullException(nameof(tasks));
            if (feladat is null) throw new ArgumentNullException(nameof(feladat));

            tasks.FeladatokList.Add(feladat);
            return tasks;

        }

    }
}
