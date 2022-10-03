using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class HistoriamascotaModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota;
        private readonly IRepositorioHistoria _repoHistoria;

        [BindProperty]

        public Historia historia { get; set; }
        public Mascota mascota { get; set; }
    

        public HistoriamascotaModel()
        {
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
            this._repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
        }

        public IActionResult OnGet(int mascotaId)
        {
            mascota = _repoMascota.GetMascota(mascotaId);
            historia = _repoHistoria.GetHistoria(mascota.Historia.Id);
            if (mascota ==null)
            {
                return RedirectToPage("./Not found");
            }
            else 
            {
                return Page();    
            }
         
        }
    }
}
