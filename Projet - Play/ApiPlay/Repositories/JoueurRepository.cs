﻿using ApiPlay.Data;
using ApiPlay.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiPlay.Repositories
{
    public class JoueurRepository : IRepository<Joueur>
    {

        private ApplicationDbContext _dbContext { get; }

        public JoueurRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Create

        public async Task<bool> Ajouter(Joueur joueurAAjouter)
        {
            if (joueurAAjouter == null)
            {
                return false;
            }

            await _dbContext.Joueurs.AddAsync(joueurAAjouter);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        // Read

        public async Task<Joueur>? Obtenir(Expression<Func<Joueur, bool>> predicate)
        {
            return await _dbContext.Joueurs.FindAsync(predicate);
        }

        public async Task<ICollection<Joueur>>? ObtenirTous()
        {
            return await _dbContext.Joueurs.Include(j => j.JoueurJeuxs).ThenInclude(j => j.Jeux).ToListAsync();
        }

        public async Task<ICollection<Joueur>>? ObtenirTous(Expression<Func<Joueur, bool>> predicate)
        {
            return await _dbContext.Joueurs.Where(predicate).Include(j => j.JoueurJeuxs).ThenInclude(j => j.Jeux).ToListAsync();
        }

        public async Task<Joueur>? ObtenirViaId(int id)
        {
            return await _dbContext.Joueurs.Include(j => j.JoueurJeuxs).ThenInclude(j => j.Jeux).FirstOrDefaultAsync(j => j.Id == id);
        }

        // Update

        public async Task<bool> Modifier(Joueur joueurModifie)
        {
            var joueurFromDb = await ObtenirViaId(joueurModifie.Id);

            if (joueurFromDb == null)
            {
                return false;
            }

            if (joueurFromDb.Pseudo != joueurModifie.Pseudo)
                joueurFromDb.Pseudo = joueurModifie.Pseudo;
            if (joueurFromDb.Age != joueurModifie.Age)
                joueurFromDb.Age = joueurModifie.Age;
            if (joueurFromDb.CheminAvatar != joueurModifie.CheminAvatar)
                joueurFromDb.CheminAvatar = joueurModifie.CheminAvatar;

            _dbContext.Joueurs.Update(joueurFromDb);

            return await _dbContext.SaveChangesAsync() > 0;

        }

        // Delete

        public async Task<bool> Supprimer(int id)
        {
            var joueurASupprimer = await ObtenirViaId(id);

            if (joueurASupprimer == null)
            {
                return false;
            }

            _dbContext.Joueurs.Remove(joueurASupprimer);

            return await _dbContext.SaveChangesAsync() > 0;

        }
    }
}
