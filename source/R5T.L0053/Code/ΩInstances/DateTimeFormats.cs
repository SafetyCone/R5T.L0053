using System;


namespace R5T.L0053
{
    public class DateTimeFormats : IDateTimeFormats
    {
        #region Infrastructure

        public static IDateTimeFormats Instance { get; } = new DateTimeFormats();


        private DateTimeFormats()
        {
        }

        #endregion
    }
}
