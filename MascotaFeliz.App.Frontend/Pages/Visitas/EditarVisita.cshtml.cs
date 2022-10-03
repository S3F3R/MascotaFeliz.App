using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using Newtonsoft.Json;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class EditarVisitaModel : PageModel
    {
        private readonly IRepositorioVisitaPyP _repovisita;
        private readonly IRepositorioHistoria _repoHistoria;
        private readonly IRepositorioMascota _repoMascota;
        private readonly IRepositorioVeterinario _repoveterinario;
        DateTime FechaVisita;
        [BindProperty]
        public VisitaPyP visitaPyP { get; set; }
        public Historia historia { get; set; }
        public Mascota mascota { get; set; }
        public Veterinario veterinario { get; set; }
        public IEnumerable<Historia> listaHistorias { get; set; }

        public EditarVisitaModel()
        {
            this._repovisita = new RepositorioVisitaPyP(new Persistencia.AppContext());
            this._repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
            this._repoveterinario= new RepositorioVeterinario(new Persistencia.AppContext());
        }
        
        public IActionResult OnGet(int? mascotaId)
        {
            if (mascotaId.HasValue)
            {
                mascota = _repoMascota.GetMascota(mascotaId.Value);
                visitaPyP = new VisitaPyP();
            }
            
            else
            {
                mascota = new Mascota();
                visitaPyP = new VisitaPyP();
            }
            if (mascota == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
            
               
        }

        public IActionResult OnPost(int veterinarioId, int historiaId)
        {
            
            historia = _repoHistoria.GetHistoria(historiaId);
            Console.WriteLine(JsonConvert.SerializeObject(historia));
            veterinario = _repoveterinario.GetVeterinario(veterinarioId);
            Console.WriteLine(JsonConvert.SerializeObject(veterinario));
            if (!ModelState.IsValid)
            {
                return Page ();
                    
            }
            else
            {
                visitaPyP.FechaVisita = DateTime.Now;
                visitaPyP.IdVeterinario = veterinario.Id;
                visitaPyP = _repovisita.AddVisitaPyP(visitaPyP);
                historia = _repoHistoria.UpdateHistoria(visitaPyP.Id, historia.Id);
                
            }
            return RedirectToPage("/Mascotas/ListaMascotas");
        }
    }
}
