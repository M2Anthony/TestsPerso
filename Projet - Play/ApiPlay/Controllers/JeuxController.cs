using ApiPlay.Models;
using ApiPlay.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPlay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JeuxController : ControllerBase
    {
        private readonly IRepository<Jeux> _jeuxRepository;

        public JeuxController(IRepository<Jeux> jeuxRepository)
        {
            _jeuxRepository = jeuxRepository;
        }

            // Create

        [HttpPost]
        public async Task<IActionResult> Ajouter([FromForm] Jeux jeuxAAjouter)
        {
            var reussite = await _jeuxRepository.Ajouter(jeuxAAjouter);

            if (reussite == false)
            {
                return BadRequest("Le jeux n'a pas pu être ajouté");
            }

            return Ok("Le jeu a été correctement ajouté");
        }

        // Read

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listeJeux = await _jeuxRepository.ObtenirTous();

            if (listeJeux.Count == 0)
            {
                return NotFound("Aucun jeux n'a été trouvé");
            }

            return Ok(listeJeux);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var jeuxFromDb = await _jeuxRepository.ObtenirViaId(id);

            if (jeuxFromDb == null)
            {
                return NotFound("L'Id ne correspond à aucun jeux");
            }

            return Ok(jeuxFromDb);
        }

        [HttpGet("titre")]
        public async Task<IActionResult> GetAll(string titre)
        {
            var listeJeux = await _jeuxRepository.ObtenirTous(t => t.Titre.StartsWith(titre));

            if (listeJeux.Count == 0)
            {
                return NotFound("Aucun jeux n'a été trouvé");
            }

            return Ok(listeJeux);
        }

        // Update

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] Jeux jeuxModifie)
        {
            var reussite = await _jeuxRepository.Modifier(jeuxModifie);

            if (reussite == false)
            {
                return BadRequest("La modification n'a pas pu être effectuée");
            }

            return Ok("La modification a été correctement effectuée");
        }

        // Delete

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var jeuxASupprimer = await _jeuxRepository.ObtenirViaId(id);

            if (jeuxASupprimer == null)
            {
                return NotFound("L'Id ne correspond à aucun jeux");
            }

            var reussite = await _jeuxRepository.Supprimer(id);

            if (reussite == false)
            {
                return BadRequest("La suppression n'a pas pu être effectuée");
            }

            return Ok("Le jeu a été correctement supprimé");
        }
    }
}
