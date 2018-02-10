using System;

namespace CreativeCats.Core.Data
{
    public class RepositoryException : Exception
    {
        public RepositoryException(string message)
            : base(message)
        {
        }
    }
}