using Alunos.Model;
using Alunos.Web.Components.Shared;
using Microsoft.AspNetCore.Components;
using MudBlazor;


namespace Alunos.Web.Components.Pages
{
    public class ListaAlunosBase :ComponentBase
    {
        [Inject] protected ISnackbar Snackbar { get; set; }
        public IEnumerable<Aluno> Alunos { get; set; }
        public MensagemAlerta mensagemAlerta { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await Task.Run(() => LoadAlunos());
        }

        public void LoadAlunos()
        {
           
            Alunos = new List<Aluno>
            {
                new Aluno {
                    AlunoId = 1,
                    Nome = "João",
                    Sobrenome = "Vieira",
                    Email="joao@gmail.com",
                    Nascimento = new DateTime(1990,10,5)
                    , Genero = Genero.Masculino,
                    Curso = new Curso{CursoId = 1, Nome="Quimica I", Creditos=4},
                    Foto ="images/foto1.jpg"
                    }
               
            };
        }

        protected void OnRowCommitted(Aluno item)
            {
            // Aqui o 'item' já vem com o Nome e Email novos que o usuário digitou
            // É aqui que você chamaria seu serviço ou banco de dados:
            // alunoService.Update(item); 

         
            mensagemAlerta.Sucesso($"Aluno atualizado com sucesso!,{item.Nome}, {item.Email}");
        }
        public async Task CriarNovo()
        {
            var novo = new Aluno { Nome = "", Email = "" };
            ((List<Aluno>)Alunos).Add(novo);
            StateHasChanged(); // ESSENCIAL para a tela "acordar"
        }

        public async Task ConfirmarExclusao(Aluno item)
        {

        }
    }
}
