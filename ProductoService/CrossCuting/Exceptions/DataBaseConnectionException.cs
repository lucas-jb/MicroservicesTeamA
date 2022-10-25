namespace ProductoService.CrossCuting.Exceptions
{
    [Serializable]
    public class DataBaseConnectionException : Exception
    {
        public string RepositoryName { get; } = String.Empty;
        public DataBaseConnectionException() { }

        public DataBaseConnectionException(string message)
            : base(message) { }

        public DataBaseConnectionException(string message, Exception inner)
            : base(message, inner) { }

        public DataBaseConnectionException(string message, string repositoryName) :
            this(message)
        {
            this.RepositoryName = repositoryName;
        }
    }
}
