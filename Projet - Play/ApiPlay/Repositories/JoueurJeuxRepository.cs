using ApiPlay.Models;
using System.Linq.Expressions;

namespace ApiPlay.Repositories
{
    public class JoueurJeuxRepository : IRepository<JoueurJeux>
    {
        public Task<bool> Ajouter(JoueurJeux entite)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Modifier(JoueurJeux entite)
        {
            throw new NotImplementedException();
        }

        public Task<JoueurJeux>? Obtenir(Expression<Func<JoueurJeux, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<JoueurJeux>>? ObtenirTous()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<JoueurJeux>>? ObtenirTous(Expression<Func<JoueurJeux, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<JoueurJeux>? ObtenirViaId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Supprimer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
