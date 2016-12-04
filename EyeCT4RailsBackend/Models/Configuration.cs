using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedObservableCollection;

namespace EyeCT4RailsBackend
{
    public class Configuration : ExtendedNotifyPropertyChanged
    {
        //Properties
        public int LargeRepairJobsPerYear
        {
            get { return largeRepairJobsPerYear; }
            set { SetField(this, ref largeRepairJobsPerYear, value); }
        }
        public int SmallRepairJobsPerYear
        {
            get { return smallRepairJobsPerYear; }
            set { SetField(this, ref smallRepairJobsPerYear, value); }
        }
        public int LargeCleaningJobsPerYear
        {
            get { return largeCleaningJobsPerYear; }
            set { SetField(this, ref largeCleaningJobsPerYear, value); }
        }
        public int SmallCleaningJobsPerYear
        {
            get { return smallCleaningJobsPerYear; }
            set { SetField(this, ref smallCleaningJobsPerYear, value); }
        }
        //fields
        private int largeRepairJobsPerYear;
        private int smallRepairJobsPerYear;
        private int largeCleaningJobsPerYear;
        private int smallCleaningJobsPerYear;
        public Configuration(int LargeRepairJobsPerYear, int SmallRepairJobsPerYear, int LargeCleaningJobsPerYear, int SmallCleaningJobsPerYear)
        {
            this.LargeRepairJobsPerYear = LargeRepairJobsPerYear;
            this.SmallRepairJobsPerYear = SmallRepairJobsPerYear;
            this.LargeCleaningJobsPerYear = LargeCleaningJobsPerYear;
            this.SmallCleaningJobsPerYear = SmallCleaningJobsPerYear;
        }
    }
}
