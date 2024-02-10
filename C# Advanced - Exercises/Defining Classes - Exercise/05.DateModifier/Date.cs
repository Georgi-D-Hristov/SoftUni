namespace _05.DateModifier;

using System;

public class Date
{
    private string startDate;
    private string endDate;

    public Date(string startDate, string endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }

    public string EndDate
    {
        get { return endDate; }
        set { endDate = value; }
    }


    public string StartDate
    {
        get { return startDate; }
        set { startDate = value; }
    }

    public int GetDateDifference()
    {
        var startDate = DateTime.Parse(StartDate);
        var endDate = DateTime.Parse(EndDate);
        var diference = Math.Abs((startDate - endDate).Days);
        return diference;
    }
}
