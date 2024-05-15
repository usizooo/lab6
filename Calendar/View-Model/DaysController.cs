using System.Windows.Media;

namespace Calendar.View_Model
{
    public class DaysController : Singleton
    {
        public static DaysController Instance => Instance<DaysController>();
        private DaysController() { }

        public ImageSource GetImageFromDate(DateTime date) => throw new NotImplementedException();
        public List<bool> GetChecksFromDate(DateTime date) => throw new NotImplementedException();
    }
}