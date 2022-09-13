using System;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using System.Collections.Generic;

namespace MascotaFeliz.App.Consola
{
    class Program
    {

        private static IRepositorioDueno _repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hola amigos vamos a empezar a trabajar con las tablas");
                       
            //ListarDuenosFiltro();      
            //AddDueno();
            BuscarDueno(3);
            //DeleteDueno(1);
            //UpdateDueno();

            //ListarVeterinariosFiltro();
            //AddVeterinario();
            BuscarVeterinario(4);
            //DeleteVeterinario(2);
            //UpdateVeterinario();
            

        }

        private static void AddDueno()
        {
            var dueno = new Dueno
            {
                Nombres = "Luis Felipe",
                Apellidos = "Fadul", 
                Direccion = "Calle 1 # 1-15",
                Telefono = "4564564566",
                Correo = "fadulitomenor@gmail.com"
            };
            _repoDueno.AddDueno(dueno);
        }

        private static void DeleteDueno(int idDueno)
        {
            _repoDueno.DeleteDueno(idDueno);
        }

        private static void UpdateDueno()
        {
            var dueno = new Dueno
            {
                Nombres = "Luis Felipe",
                Apellidos = "Fadul", 
                Direccion = "Calle 145 # 158-15",
                Telefono = "123456789",
                Correo = "sebas@gmail.com",
                Id = 3
            };
            _repoDueno.UpdateDueno(dueno);
        }

         private static void AddVeterinario()
        {
            var veterinario = new Veterinario
            {
                Nombres = "Peter",
                Apellidos = "Pan", 
                Direccion = "Transversal 9 # 17A-155",
                Telefono = "3363365858",
                TarjetaProfesional = "TP52546"
            };
            _repoVeterinario.AddVeterinario(veterinario);
        }

        private static void DeleteVeterinario(int idVeterinario)
        {
            _repoVeterinario.DeleteVeterinario(idVeterinario);
        }

        private static void UpdateVeterinario()
        {
            var veterinario = new Veterinario
            {
                Nombres = "Sebastian",
                Apellidos = "Ruiz", 
                Direccion = "Calle 15 # 158-15",
                Telefono = "666",
                TarjetaProfesional = "TP5254",
                Id = 4
            };
            _repoVeterinario.UpdateVeterinario(veterinario);
        }

        private static void BuscarDueno(int idDueno)
        {
            var dueno = _repoDueno.GetDueno(idDueno);
            Console.WriteLine("El dueño solicitado con el Id= "+dueno.Id+", Correponde a "+dueno.Nombres + " " + dueno.Apellidos);
        }

        private static void BuscarVeterinario(int idVeterinario)
        {
            var veterinario = _repoVeterinario.GetVeterinario(idVeterinario);
            Console.WriteLine("El veterinario solicitado con el Id= "+veterinario.Id+", Correponde a "+veterinario.Nombres + " " + veterinario.Apellidos);
        }

        private static void ListarDuenosFiltro()
        {
            var duenosM = _repoDueno.GetDuenosPorFiltro("Fel");
            foreach (Dueno p in duenosM)
            {
                Console.WriteLine(p.Nombres + " " + p.Apellidos);
            }

        }

        private static void ListarVeterinariosFiltro()
        {
            var veterinariosM = _repoVeterinario.GetVeterinariosPorFiltro("e");
            foreach (Veterinario p in veterinariosM)
            {
                Console.WriteLine(p.Nombres + " " + p.Apellidos);
            }

        }


        
        
    }
}
