using ProveedoresService.Models;

namespace ProveedoresService.DAL
{
    public class ProveedoresProvider : IProovedoresProvider
    {
        private readonly List<Proveedor> repository = new List<Proveedor>();
        public ProveedoresProvider()
        {
            repository.Add(new Proveedor { ID = 1, Ciudad = "Pamplona", nombre = "MediaMarkt Navarra", tipo = "Tecnologia" });
            repository.Add(new Proveedor { ID = 2, Ciudad = "Paris", nombre = "Frutas Manolo", tipo = "Alimentacion" });
            repository.Add(new Proveedor { ID = 3, Ciudad = "Barcelona", nombre = "OES Tecnologia", tipo = "Tecnologia" });
            repository.Add(new Proveedor { ID = 4, Ciudad = "Zaragoza", nombre = "Hardware SL", tipo = "Componentes Informaticos" });
            repository.Add(new Proveedor { ID = 5, Ciudad = "Gares", nombre = "Carniceria Gabaran", tipo = "Alimentacion" });
            repository.Add(new Proveedor { ID = 6, Ciudad = "Valencia", nombre = "Muebles Valencia", tipo = "Muebles Hogar" });
            repository.Add(new Proveedor { ID = 7, Ciudad = "Madrid", nombre = "MediaMarkt Madrid", tipo = "Tecnologia" });
            repository.Add(new Proveedor { ID = 8, Ciudad = "Madrid", nombre = "MediaMarkt Madrid", tipo = "Informatica" });
        }

        public async Task<Proveedor> GetAsync(int id)
        {
            var proveedor = repository.FirstOrDefault(p => p.ID == id);
            return await Task.Run(() => proveedor);

        }

        public async Task<List<Proveedor>> GetAllAsync()
        {
            var proveedores = repository.ToList();
            return await Task.Run(() => proveedores);

        }
    }
}
