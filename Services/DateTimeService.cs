
using WPF_study.Interfaces;

namespace WPF_study.Services
{
    internal class DateTimeService : IDateTime
    {
        public DateTime? GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
