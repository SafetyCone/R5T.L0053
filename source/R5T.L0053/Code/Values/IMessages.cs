using System;

using R5T.T0131;


namespace R5T.L0053
{
    [ValuesMarker]
    public partial interface IMessages : IValuesMarker
    {
        public string EventDataReceivedWasNull => "<Event data received was null>";
    }
}
