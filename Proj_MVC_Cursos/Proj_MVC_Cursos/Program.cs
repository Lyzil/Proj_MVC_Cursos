// See https://aka.ms/new-console-template for more information

using System.Runtime.ConstrainedExecution;
using System;
using Proj_MVC_Cursos;

int opcao;
Escola minhaEscola = new Escola();

do
{
    Console.WriteLine("Menu de opções " +
        "\n0. Sair"+
        "\n1. Adicionar curso"+
        "\n2. Pesquisar curso(mostrar inclusive as disciplinas associadas)"+
        "\n3. Remover curso(não pode ter nenhuma disciplina associada)"+
        "\n4. Adicionar disciplina no curso"+
        "\n5. Pesquisar disciplina(mostrar inclusive os alunos matriculados)"+
        "\n6. Remover disciplina do curso(não pode ter nenhum aluno matriculado)"+
        "\n7. Matricular aluno na disciplina"+
        "\n8. Remover aluno da disciplina"+
        "\n9. Pesquisar aluno(informar seu nome e em quais disciplinas ele está matriculado)"+
        "\nEscolhe a opção que deseja: ");

    string inputOpcao = Console.ReadLine();
    if (!int.TryParse(inputOpcao, out opcao))
    {
        Console.WriteLine("Ocorreu um erro, verifique se digitou corretamente.\n");
        continue;
    }
    switch (opcao)
    {
        case 0:
            break;
        case 1:
            Console.WriteLine("\ndigite o ID: ");
            if (!int.TryParse(Console.ReadLine(), out int addID))
            {
                Console.WriteLine("ID inválido!\n");
                break;
            }
            Console.WriteLine("digite a descrição: ");
            string addDescricao = Console.ReadLine();

            Console.WriteLine(minhaEscola.adicionarCurso(new Curso(addID, addDescricao)) ? "adicionado com sucesso!\n" : "Não foi possivel adicionar\n");
            break;
        case 2:
            Console.WriteLine("\ndigite o ID do curso");
            if (!int.TryParse(Console.ReadLine(), out int idConsultaCurso))
            {
                Console.WriteLine("ID inválido!\n");
                break;
            }
            Curso cursoConsultado = minhaEscola.pesquisarCurso(new Curso(idConsultaCurso));
            if (cursoConsultado.Id != -1)
            {
                Console.WriteLine($"ID: {cursoConsultado.Id}\n" +
                               $"Nome: {cursoConsultado.Descricao}\n");
                Console.WriteLine("Informações das diciplinas associadas:");
                for (int i = 0; i < cursoConsultado.Disciplinas.Length; i++)
                {
                    if (cursoConsultado.Disciplinas[i].Qtde > 0)
                    {
                        Console.WriteLine($"Diciplina {i + 1}: {cursoConsultado.Disciplinas[i].Id} | {cursoConsultado.Disciplinas[i].Descricao} \n");
                    }
                }
            }
            else { Console.WriteLine("Curso não encontrado!\n"); }
            break;
        case 3:
            Console.WriteLine("\ndigite o ID: ");
            if (!int.TryParse(Console.ReadLine(), out int delID))
            {
                Console.WriteLine("ID inválido!\n");
                break;
            }
            Console.WriteLine(minhaEscola.removerCurso(new Curso(delID)) ? "Deletado com sucesso!\n" : "Não foi possível deletar (vendedor possui vendas ou não existe)\n");
            break;
        case 4:
            Console.WriteLine("\nDigite o Id da diciiplina: ");
            if (!int.TryParse(Console.ReadLine(), out int IdRegistrar)){
                Console.WriteLine("ID inválido!\n");
                break;
            }
            Curso cursoAchado = minhaEscola.pesquisarCurso(new Curso(IdRegistrar));
            if (cursoAchado.Id != -1){
                Console.WriteLine("Digite a descrição da diciplina: ");
                string descricaoRegistrar = Console.ReadLine();

                cursoAchado.adicionarDisciplina(new Disciplina(IdRegistrar,descricaoRegistrar));
                Console.WriteLine("Diciplina registrada com sucesso!\n");
            }
            else{ Console.WriteLine("Curso não encontrado!\n"); }
            break;
        case 5: //descobrir oq ta errado aqui
            Console.WriteLine("\ndigite o ID da diciplina");
            if (!int.TryParse(Console.ReadLine(), out int idConsultaDiciplina))
            {
                Console.WriteLine("ID inválido!\n");
                break;
            }

            Disciplina diciplinaConsultada = minhaEscola.(new Disciplina(idConsultaDiciplina));
            if (cursoConsultado.Id != -1)
            {
                Console.WriteLine($"ID: {cursoConsultado.Id}\n" +
                               $"Nome: {cursoConsultado.Descricao}\n");
                Console.WriteLine("Informações das diciplinas associadas:");
                for (int i = 0; i < cursoConsultado.Disciplinas.Length; i++)
                {
                    if (cursoConsultado.Disciplinas[i].Qtde > 0)
                    {
                        Console.WriteLine($"Diciplina {i + 1}: {cursoConsultado.Disciplinas[i].Id} | {cursoConsultado.Disciplinas[i].Descricao} \n");
                    }
                }
            }
            break;
        case 6:
            break;
        case 7:
            break;
        case 8:
            break;
        case 9:
            break;
        default:
            Console.WriteLine("\nOcorreu um erro, verifique se digitou corretamente.\n");
            break;
    }
} while (opcao != 0);