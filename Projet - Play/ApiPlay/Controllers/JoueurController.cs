using ApiPlay.Data;
using ApiPlay.Models;
using ApiPlay.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPlay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoueurController : ControllerBase
    {
        private readonly IRepository<Joueur> _joueurRepository;

        public JoueurController(IRepository<Joueur> repositoryJoueur)
        {
            _joueurRepository = repositoryJoueur;
        }

            // Create

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Joueur joueur)
        {
            var reussite = await _joueurRepository.Ajouter(joueur);

            if (reussite == false)
            {
                return BadRequest(new
                {
                    Message = "Le joueur n'a pas été ajouté"
                });
            };

            return Ok(new
            {
                Message = "Le joueur a bien été ajouté",
            });

        }

            // Read

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listeJoueurs = await _joueurRepository.ObtenirTous();

            return Ok(listeJoueurs);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var joueur = await _joueurRepository.ObtenirViaId(id);

            if (joueur == null)
            {
                return BadRequest("L'Id du joueur n'existe pas");
            }

            return Ok(joueur);
        }

        [HttpGet("pseudo")]
        public async Task<IActionResult> Get(string pseudo)
        {
            return Ok(await _joueurRepository.ObtenirTous(c => c.Pseudo.StartsWith(pseudo)));
        }

            // Update

        [HttpPut]
        public async Task<IActionResult> Put(Joueur joueurModifie)
        {
            var joueur = await _joueurRepository.Modifier(joueurModifie);

            if (joueur == null)
            {
                return BadRequest();
            }

            return Ok(joueur);
        }

            // Delete

        [HttpDelete]
        public async Task <IActionResult> Delete(int id)
        {
            var joueurASupprimer = await _joueurRepository.ObtenirViaId(id);

            if (joueurASupprimer == null)
            {
                return NotFound("Le joueur n'a pas été trouvé");
            }

            return Ok(new
            {
                Message = "Le joueur a été correctement supprimé",
                Joueur = _joueurRepository.Supprimer(id)
            });
        }


    }
}
