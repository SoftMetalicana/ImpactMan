namespace ImpactMan.Models.Exceptions
{
    using System;

    public class MissingMenuException : Exception
    {
        public new const string Message = "The menu you are trying to reach is missing!";
    }
}
