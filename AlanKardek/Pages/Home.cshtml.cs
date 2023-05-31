using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AlanKardek.Models.Father;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using AlanKardek.Migrations;

namespace AlanKardek.Pages
{
    public class HomeModel : PageModel {
        private readonly AlanKardekContext _context;

        public HomeModel(AlanKardekContext context) {
            _context = context;
        }

        public Usuario? Usuario { get; set; } = null!;
        public string?  mensagem = null;

        public async Task<IActionResult> OnGetAsync(String email, String senha) {
            if (email == "" || senha == "") return NotFound();

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.Email == email);

            if (usuario == null) {
                mensagem = "usuario nao encontrado.";
            }
            else {
                if (usuario.Senha != senha) {
                    mensagem = "senha invalida.";
                }
                else {
                    //Usuario = usuario;

                    if (usuario.Tipo.ToUpper() == "U") {
                        return RedirectToPage("./Aluno_View/index");
                    }
                    else {
                        if(usuario.Privilegiado.ToUpper() == "S") { 
                        return RedirectToPage("./Crud/Index");
                        }
                        else {
                        if(usuario.Privilegiado.ToUpper() == "N"){
                                return RedirectToPage("./Index2");
                            }
                            else
                            {
                                return RedirectToPage("./Prof_View");
                            }
                        
                          
                        }

                    }
                }
            }
            return Page();
        }
    }
}
