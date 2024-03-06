using System.Linq.Expressions;

namespace ApiPlay.Repositories
{
    public interface IRepository<EntiteGenerique>
    {
        // CRUD

        // Create

        Task<bool> Ajouter(EntiteGenerique entite);

        // Read

        Task<ICollection<EntiteGenerique>>? ObtenirTous();

        Task<ICollection<EntiteGenerique>>? ObtenirTous(Expression<Func<EntiteGenerique, bool>> predicate);

        Task<EntiteGenerique>? ObtenirViaId(int id);

        Task<EntiteGenerique>? Obtenir(Expression<Func<EntiteGenerique, bool>> predicate);

        // Update

        Task<bool> Modifier(EntiteGenerique entite);

        // Delete

        Task<bool> Supprimer(int id);



    }
}
