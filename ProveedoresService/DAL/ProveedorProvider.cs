using ProveedoresService.Models;

namespace ProveedoresService.DAL
{
    public class ProveedorProvider : IProveedorProvider
    {
        private readonly List<Proveedor> repository = new List<Proveedor>();
        public ProveedorProvider()
        {
            repository.Add(new Proveedor { Id = 1, City = "Pamplona", Name = "MediaMarkt Navarra", Type = "Tecnologia" });
            repository.Add(new Proveedor { Id = 2, City = "Paris", Name = "Frutas Manolo", Type = "Alimentacion" });
            repository.Add(new Proveedor { Id = 3, City = "Barcelona", Name = "OES Tecnologia", Type = "Tecnologia" });
            repository.Add(new Proveedor { Id = 4, City = "Zaragoza", Name = "Hardware SL", Type = "Componentes Informaticos" });
            repository.Add(new Proveedor { Id = 5, City = "Gares", Name = "Carniceria Gabaran", Type = "Alimentacion" });
            repository.Add(new Proveedor { Id = 6, City = "Valencia", Name = "Muebles Valencia", Type = "Muebles Hogar" });
            repository.Add(new Proveedor { Id = 7, City = "Madrid", Name = "MediaMarkt Madrid", Type = "Tecnologia" });
            repository.Add(new Proveedor { Id = 8, City = "Madrid", Name = "MediaMarkt Madrid", Type = "Informatica" });
        }

        public async Task<Proveedor> GetAsync(int id)
        {
            var proveedor = repository.FirstOrDefault(p => p.Id == id);
            return await Task.Run(() => proveedor);

        }

        public async Task<List<Proveedor>> GetAllAsync()
        {
            var proveedores = repository.ToList();
            return await Task.Run(() => proveedores);

        }
    }
}
