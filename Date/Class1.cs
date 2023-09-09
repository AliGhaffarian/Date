namespace Date
{
    public class Date
    {
        private int day;
        private int month;
        private int year;
        static private int CharFrequency(string str, char c)
        {
            int result = 0;
            foreach (char ch in str)
                if (ch == c)
                    result++;
            return result;
        }

        //sets all data members to an invalid value
        private void InitBack()
        {
            day = -1;
            month = -1;
            year = -1;
        }

        public bool ExistsInvalidValue()
        {
            return day == -1
                || month == -1
                || year == -1;
        }

        static public bool IsDay(int number)
        {
            return number >= 0 && number <= 31;
        }
        static public bool IsMonth(int number)
        {
            return number >= 0 && number <= 12;
        }
        static public bool IsYear(int number)
        {
            return number >= 0;
        }

        //checks wheter the string is a completely valid date
        static public bool StringContainsDate(string str)
        {
            if (CharFrequency(str, '/') != 2)
                return false;

            return true;
        }

        //returns an invalid date if one parameter of date is invalid
        static public Date ExtractDateFromString(string date)
        {

            if (!StringContainsDate(date))
                return new Date();

            //finding index of each / and length of month
            int firstSlashIndex = date.IndexOf('/');
            int secondSlashIndex = date.IndexOf('/', firstSlashIndex + 1);
            int monthLength = secondSlashIndex - firstSlashIndex - 1;

            //extracting each attribute
            string? year = date.Substring(0, firstSlashIndex);
            string? month = date.Substring((firstSlashIndex + 1), monthLength);
            string? day = date.Substring(secondSlashIndex + 1);

            //converting attributes to int32
            int yearReturn = Convert.ToInt32(year);
            int monthReturn = Convert.ToInt32(month);
            int dayReturn = Convert.ToInt32(day);

            return new Date(yearReturn, monthReturn, dayReturn);
        }
        public int Day
        {
            set
            {
                day = IsDay(value) ? value : -1;
            }
            get { return day; }
        }
        public int Month
        {
            set
            {
                month = IsMonth(value) ? value : -1;

            }

            get { return month; }
        }
        public int Year
        {
            set
            {
                year = IsYear(value) ? value : -1;
            }

            get { return year; }
        }

        public Date(int year, int month, int day)
        {
            Day = day;
            Month = month;
            Year = year;
        }
        public Date()
        {
            InitBack();
        }
        public Date(string? dateStr)
        {
            if (dateStr == null)
                return;
            Date temp = Date.ExtractDateFromString(dateStr);
            if (temp.ExistsInvalidValue())
            {
                InitBack();
                return;
            }

            Day = temp.Day;
            Month = temp.Month;
            Year = temp.Year;
        }
        public Date(Date date)
        {
            Day = date.Day;
            Month = date.Month;
            Year = date.Year;
        }

        public void Print()
        {
            string number = year.ToString().PadLeft(4, '0') + "/"
                            + month.ToString().PadLeft(2, '0') + "/"
                            + day.ToString().PadLeft(2, '0');

            Console.Write(number);
        }

        public static bool operator <(Date first, Date second)

        {
            if (first.Year != second.Year)
                return first.year < second.year;

            if (first.Month != second.Month)
                return first.month < second.month;

            if (first.Day != second.Day)
                return first.day < second.day;

            return false;
        }

        public static bool operator <=(Date first, Date second)

        {
            if (first.Year != second.Year)
                return first.year < second.year;

            if (first.Month != second.Month)
                return first.month < second.month;

            if (first.Day != second.Day)
                return first.day < second.day;

            return true;
        }

        public static bool operator >=(Date first, Date second)

        {
            if (first.Year != second.Year)
                return first.year > second.year;

            if (first.Month != second.Month)
                return first.month > second.month;

            if (first.Day != second.Day)
                return first.day > second.day;

            return true;
        }

        public static bool operator >(Date first, Date second)
        {
            if (first.Year != second.Year)
                return first.year > second.year;

            if (first.Month != second.Month)
                return first.month > second.month;

            if (first.Day != second.Day)
                return first.day > second.day;

            return false;
        }

        public static bool operator ==(Date? first, Date? second)
        {
            if (first is null || second is null)
                return false;

            return first.day == second.day && first.Month == second.Month && first.Year == second.Year;
        }

        public static bool operator !=(Date first, Date second)
        {
            return !(first == second);
        }

        public override string ToString()
        {
            return (Year + "/" + Month + "/" + Day);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType == this.GetType)
                return this == obj;

            return false;
        }
    }

}