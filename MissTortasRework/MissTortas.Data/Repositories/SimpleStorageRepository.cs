using MissTortas.Data.Context;
using MissTortas.Data.Entity.Products;
using MissTortas.Data.Interfaces;

namespace MissTortas.Data.Repositories
{
    public class SimpleStorageRepository(MissTortasContext context) : RepositoryCrud<ProductFile>(context), ISimpleStorageRepository 
    {

    }
}
