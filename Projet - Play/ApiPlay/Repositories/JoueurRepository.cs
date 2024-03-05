using ApiPlay.Models;
using System.Linq.Expressions;

namespace ApiPlay.Repositories
{
    public class JoueurRepository : IRepository<Joueur>
    {

        private 

        public Task<bool> Ajouter(Joueur entite)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Modifier(Joueur entite)
        {
            throw new NotImplementedException();
        }

        public Task<Joueur>? Obtenir(Expression<Func<Joueur, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Joueur>>? ObtenirTous()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Joueur>>? ObtenirTous(Expression<Func<Joueur, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Joueur>? ObtenirViaId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Supprimer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
