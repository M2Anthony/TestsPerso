using ApiPlay.Data;
using ApiPlay.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiPlay.Repositories
{
    public class JeuxRepository : IRepository<Jeux>
    {
        private readonly ApplicationDbContext _dbContext;

        public JeuxRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Create

        public async Task<bool> Ajouter(Jeux jeuxAAjouter)
        {
            _dbContext.Jeuxs.Add(jeuxAAjouter);

            return await _dbContext.SaveChangesAsync() > 0;
        }

        // Read

        public async Task<ICollection<Jeux>>? ObtenirTous()
        {
            return await _dbContext.Jeuxs.Include(j => j.JoueurJeuxs).ThenInclude(j => j.Joueur).ToListAsync();
        }

        public async Task<ICollection<Jeux>>? ObtenirTous(Expression<Func<Jeux, bool>> predicate)
        {
            return await _dbContext.Jeuxs.Where(predicate).Include(j => j.JoueurJeuxs).ThenInclude(j => j.Joueur).ToListAsync();

        }

        public async Task<Jeux>? Obtenir(Expression<Func<Jeux, bool>> predicate)
        {
            return await _dbContext.Jeuxs.FindAsync(predicate);
        }
                

        public async Task<Jeux>? ObtenirViaId(int id)
        {
            return await _dbContext.Jeuxs.Include(j => j.JoueurJeuxs).ThenInclude(j => j.Joueur).FirstOrDefaultAsync(j => j.Id == id);

        }

        // Update

        public async Task<bool> Modifier(Jeux jeuxAModifier)
        {
            var jeuxFromDb = await ObtenirViaId(jeuxAModifier.Id);

            if (jeuxFromDb == null)
            {
                return false;
            }

            if (jeuxFromDb.Titre != jeuxAModifier.Titre)
                jeuxFromDb.Titre = jeuxAModifier.Titre;
            if (jeuxFromDb.Description != jeuxAModifier.Description)
                jeuxFromDb.Description = jeuxAModifier.Description;
            if (jeuxFromDb.CheminJaquette != jeuxAModifier.CheminJaquette)
                jeuxFromDb.CheminJaquette = jeuxAModifier.CheminJaquette;

            _dbContext.Jeuxs.Update(jeuxFromDb);
            return await _dbContext.SaveChangesAsync() > 0;

        }

        // Delete

        public async Task<bool> Supprimer(int id)
        {
            var jeuxASupprimer = await ObtenirViaId(id);

            if (jeuxASupprimer == null)
            {
                return false;
            }

            _dbContext.Jeuxs.Remove(jeuxASupprimer);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
