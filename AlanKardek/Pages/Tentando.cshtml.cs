using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AlanKardek.Models.Father;
using AlanKardek.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using System;
namespace AlanKardek.Pages
{
    public class TentandoModel : PageModel
    {
        private readonly AlanKardekContext _context;

        public TentandoModel(AlanKardekContext context)
        {
            _context = context;
        }

        public IList<Usuario> Usuario { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Usuarios != null)
            {
                Usuario = await _context.Usuarios.ToListAsync();
            }
        }
    }
}
