namespace ProductoService.CrossCuting.Exceptions
{
    [Serializable]
    public class ProductoNotFoundException : Exception
    {
        public int ProductoId { get; }
        public ProductoNotFoundException() { }

        public ProductoNotFoundException(string message)
            : base(message) { }

        public ProductoNotFoundException(string message, Exception inner)
            : base(message, inner) { }
        public ProductoNotFoundException(string message, int productoId) : this(message)
        {
            ProductoId = productoId;
        }
    }
}
