using ClubeDoLivro.Domain;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ClubeDoLivro.Blazor.Pages
{
    public partial class AutorListPage
    {
        [Inject]
        HttpClient HttpClient { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        private NavigationManager Navigation { get; set; }



        private List<Autor> Autores;

        protected override async Task OnInitializedAsync()
        {
            Autores = new List<Autor>()
            {
                new Autor { Id = 1, Nome = "Leonardo", SobreNome = "Said", Livros = new List<Livro>()},
                new Autor { Id = 2, Nome = "Felipe", SobreNome = "Said", Livros = new List<Livro>()}
            };
        }

        public async Task OpenPopup(Autor autor = null, bool podeRemover = false )
        {
            var parameters = new DialogParameters
            {
                {
                    "autor", autor?.Clone() ?? new Autor()
                },
                {
                    "podeRemover", podeRemover
                }
            };

            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true };
            var dialog = DialogService.Show<AutorPage>("Autor", parameters, options);
            var result = await dialog.Result;

            if (!result.Canceled)
            {
                if (podeRemover)
                {
                    Autores = Autores.Where(n => n.Id != autor.Id).ToList();
                }
                else
                {
                    if(autor is null)
                    {
                        Autores.Add(result.Data as Autor);
                    }
                    else
                    {
                        var autorAlterardo = result.Data as Autor;
                        autor.Nome = autorAlterardo.Nome;
                        autor.SobreNome = autorAlterardo.SobreNome;
                    }
                }
                StateHasChanged();
            }
        }
      
    }
}

