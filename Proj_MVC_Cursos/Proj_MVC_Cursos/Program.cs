// See https://aka.ms/new-console-template for more information

using System.Runtime.ConstrainedExecution;
using System;
using Proj_MVC_Cursos;

int opcao;
Escola minhaEscola = new Escola();

//  Script de teste
/*
// Criando cursos
Curso curso1 = new Curso(1, "Engenharia de Software");
Curso curso2 = new Curso(2, "Redes de Computadores");
minhaEscola.adicionarCurso(curso1);
minhaEscola.adicionarCurso(curso2);
// Criando disciplinas
Disciplina disc1 = new Disciplina(101, "Programação 1");
Disciplina disc2 = new Disciplina(102, "Banco de Dados");
Disciplina disc3 = new Disciplina(201, "Redes 1");
Disciplina disc4 = new Disciplina(202, "Segurança de Redes");
curso1.adicionarDisciplina(disc1);
curso1.adicionarDisciplina(disc2);
curso2.adicionarDisciplina(disc3);
curso2.adicionarDisciplina(disc4);
// Criando alunos
Aluno aluno1 = new Aluno(1001, "Alice");
Aluno aluno2 = new Aluno(1002, "Bob");
Aluno aluno3 = new Aluno(1003, "Carlos");
// Matriculando alunos
if (aluno1.podeMatricular(curso1)) disc1.matricularAluno(aluno1);
if (aluno2.podeMatricular(curso1)) disc1.matricularAluno(aluno2);
if (aluno2.podeMatricular(curso1)) disc2.matricularAluno(aluno2);
if (aluno3.podeMatricular(curso2)) disc3.matricularAluno(aluno3);
if (aluno3.podeMatricular(curso2)) disc4.matricularAluno(aluno3);
// Exibindo dados
Console.WriteLine("===== Cursos e Disciplinas (teste) =====");
foreach (Curso c in minhaEscola.Cursos)
{
    if (c.Id == -1) continue;
    Console.WriteLine($"\nCurso: {c.Descricao} (ID {c.Id})");
    for (int i = 0; i < c.Qtde; i++)
    {
        Disciplina d = c.Disciplinas[i];
        Console.WriteLine($"  Disciplina: {d.Descricao} (ID {d.Id})");
        for (int j = 0; j < d.Qtde; j++)
        {
            Aluno a = d.Alunos[j];
            Console.WriteLine($"    Aluno: {a.Nome} (ID {a.Id})");
        }
    }
}
Console.WriteLine("========================================\n");
*/

do
{
    Console.WriteLine("Menu de opções " +
        "\n0. Sair" +
        "\n1. Adicionar curso" +
        "\n2. Pesquisar curso (mostrar inclusive as disciplinas associadas)" +
        "\n3. Remover curso (não pode ter nenhuma disciplina associada)" +
        "\n4. Adicionar disciplina no curso" +
        "\n5. Pesquisar disciplina (mostrar inclusive os alunos matriculados)" +
        "\n6. Remover disciplina do curso (não pode ter nenhum aluno matriculado)" +
        "\n7. Matricular aluno na disciplina" +
        "\n8. Remover aluno da disciplina" +
        "\n9. Pesquisar aluno (informar seu nome e em quais disciplinas ele está matriculado)" +
        "\nEscolha a opção que deseja: ");

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
            Console.WriteLine("\nDigite o ID do curso: ");
            if (!int.TryParse(Console.ReadLine(), out int addID))
            {
                Console.WriteLine("ID inválido!\n");
                break;
            }
            Console.WriteLine("Digite a descrição do curso: ");
            string addDescricao = Console.ReadLine();

            Console.WriteLine(minhaEscola.adicionarCurso(new Curso(addID, addDescricao))
                ? "Curso adicionado com sucesso!\n"
                : "Não foi possível adicionar o curso (ID já existe ou limite atingido)\n");
            break;

        case 2:
            Console.WriteLine("\nDigite o ID do curso: ");
            if (!int.TryParse(Console.ReadLine(), out int idConsultaCurso))
            {
                Console.WriteLine("ID inválido!\n");
                break;
            }
            Curso cursoConsultado = minhaEscola.pesquisarCurso(new Curso(idConsultaCurso));
            if (cursoConsultado.Id != -1)
            {
                Console.WriteLine($"ID: {cursoConsultado.Id}\nNome: {cursoConsultado.Descricao}\n");
                Console.WriteLine("Informações das disciplinas associadas:");
                for (int i = 0; i < cursoConsultado.Qtde; i++)
                {
                    Console.WriteLine($"Disciplina {i + 1}: {cursoConsultado.Disciplinas[i].Id} | {cursoConsultado.Disciplinas[i].Descricao} \n");
                }
            }
            else
            {
                Console.WriteLine("Curso não encontrado!\n");
            }
            break;

        case 3:
            Console.WriteLine("\nDigite o ID do curso: ");
            if (!int.TryParse(Console.ReadLine(), out int delID))
            {
                Console.WriteLine("ID inválido!\n");
                break;
            }
            Console.WriteLine(minhaEscola.removerCurso(new Curso(delID))
                ? "Curso removido com sucesso!\n"
                : "Não foi possível remover o curso (possui disciplinas ou não existe)\n");
            break;

        case 4:
            Console.WriteLine("Cursos disponíveis:");
            foreach (var curso in minhaEscola.Cursos)
            {
                if (curso != null && curso.Id != -1)
                {
                    Console.WriteLine($"{curso.Id} - {curso.Descricao}");
                }
            }
            Console.WriteLine("\nDigite o ID do curso: ");
            if (!int.TryParse(Console.ReadLine(), out int idCursoDisciplina))
            {
                Console.WriteLine("ID inválido!\n");
                break;
            }
            
            Curso cursoAchado = minhaEscola.pesquisarCurso(new Curso(idCursoDisciplina));
            if (cursoAchado.Id != -1)
            {
                Console.WriteLine("IDs de disciplinas em uso:");
                foreach (var disciplina in cursoAchado.Disciplinas)
                {
                    if (disciplina != null && disciplina.Id != -1)
                        Console.WriteLine($"{disciplina.Id} - {disciplina.Descricao}");
                }

                Console.WriteLine("\nDigite o ID da disciplina: ");
                if (!int.TryParse(Console.ReadLine(), out int IdRegistrar))
                {
                    Console.WriteLine("ID inválido!\n");
                    break;
                }
                Console.WriteLine("Digite a descrição da disciplina: ");
                string descricaoRegistrar = Console.ReadLine();

                Console.WriteLine(cursoAchado.adicionarDisciplina(new Disciplina(IdRegistrar, descricaoRegistrar)) 
                                ? "Disciplina registrada com sucesso!\n"
                                : "Não foi possível adicionar a disciplina (ID já existe ou limite atingido)\n");
            }
            else{ Console.WriteLine("Curso não encontrado!\n"); }
            break;

        case 5:
            Console.WriteLine("Cursos disponíveis:");
            foreach (var curso in minhaEscola.Cursos)
            {
                if (curso != null && curso.Id != -1)
                    Console.WriteLine($"{curso.Id} - {curso.Descricao}");
            }

            Console.WriteLine("\nDigite o ID do curso: ");
            if (!int.TryParse(Console.ReadLine(), out int idCursoBusca))
            {
                Console.WriteLine("ID inválido!\n");
                break;
            }

            Curso cursoBuscado = minhaEscola.pesquisarCurso(new Curso(idCursoBusca));
            if (cursoBuscado.Id == -1)
            {
                Console.WriteLine("Curso não encontrado!\n");
                break;
            }
            Console.WriteLine("Disciplinas disponíveis:");
            foreach (var disciplina in cursoBuscado.Disciplinas)
            {
                if (disciplina != null && disciplina.Id != -1)
                    Console.WriteLine($"{disciplina.Id} - {disciplina.Descricao}");
            }
            Console.WriteLine("\nDigite o ID da disciplina: ");
            if (!int.TryParse(Console.ReadLine(), out int idDisciplinaBusca))
            {
                Console.WriteLine("ID inválido!\n");
                break;
            }
            Disciplina disciplinaBuscada = cursoBuscado.pesquisarDisciplina(new Disciplina(idDisciplinaBusca));
            if (disciplinaBuscada.Id != -1)
            {
                Console.WriteLine($"ID: {disciplinaBuscada.Id}\nDescrição: {disciplinaBuscada.Descricao}\n");
                Console.WriteLine("Alunos matriculados:");
                for (int i = 0; i < disciplinaBuscada.Qtde; i++)
                {
                    Console.WriteLine($"Aluno {i + 1}: {disciplinaBuscada.Alunos[i].Id} | {disciplinaBuscada.Alunos[i].Nome} \n");
                }
            }
            else
            {
                Console.WriteLine("Disciplina não encontrada!\n");
            }
            break;

        case 6:
            Console.WriteLine("Cursos disponíveis:");
            foreach (var curso in minhaEscola.Cursos)
            {
                if (curso != null && curso.Id != -1)
                    Console.WriteLine($"{curso.Id} - {curso.Descricao}");
            }
            Console.WriteLine("\nDigite o ID do curso: ");
            if (!int.TryParse(Console.ReadLine(), out int idCursoDelDisc))
            {
                Console.WriteLine("ID inválido!\n");
                break;
            }
            Curso cursoDelDisc = minhaEscola.pesquisarCurso(new Curso(idCursoDelDisc));
            if (cursoDelDisc.Id == -1)
            {
                Console.WriteLine("Curso não encontrado!\n");
                break;
            }
            Console.WriteLine("Disciplinas disponíveis:");
            foreach (var disciplina in cursoDelDisc.Disciplinas)
            {
                if (disciplina != null && disciplina.Id != -1)
                    Console.WriteLine($"{disciplina.Id} - {disciplina.Descricao}");
            }
            Console.WriteLine("\nDigite o ID da disciplina: ");
            if (!int.TryParse(Console.ReadLine(), out int idDisciplinaDel))
            {
                Console.WriteLine("ID inválido!\n");
                break;
            }
            Console.WriteLine(cursoDelDisc.removerDisciplina(new Disciplina(idDisciplinaDel))
                ? "Disciplina removida com sucesso!\n"
                : "Não foi possível remover a disciplina (possui alunos ou não existe)\n");
            break;

        case 7:
            Console.WriteLine("\nDigite o ID do curso: ");
            if (!int.TryParse(Console.ReadLine(), out int idCursoAluno))
            {
                Console.WriteLine("ID inválido!\n");
                break;
            }
            Curso cursoAluno = minhaEscola.pesquisarCurso(new Curso(idCursoAluno));
            if (cursoAluno.Id == -1)
            {
                Console.WriteLine("Curso não encontrado!\n");
                break;
            }
            Console.WriteLine("Disciplinas disponíveis:");
            foreach (var disciplina in cursoAluno.Disciplinas)
            {
                if (disciplina != null && disciplina.Id != -1)
                    Console.WriteLine($"{disciplina.Id} - {disciplina.Descricao}");
            }
            Console.WriteLine("Digite o ID da disciplina: ");
            if (!int.TryParse(Console.ReadLine(), out int idDisciplinaAluno))
            {
                Console.WriteLine("ID inválido!\n");
                break;
            }
            Disciplina disciplinaAluno = cursoAluno.pesquisarDisciplina(new Disciplina(idDisciplinaAluno));
            if (disciplinaAluno.Id == -1)
            {
                Console.WriteLine("Disciplina não encontrada!\n");
                break;
            }
            Console.WriteLine("\nDigite o ID do aluno: ");
            if (!int.TryParse(Console.ReadLine(), out int idAluno))
            {
                Console.WriteLine("ID inválido!\n");
                break;
            }
            Console.WriteLine("Digite o nome do aluno: ");
            string nomeAluno = Console.ReadLine();

            Aluno novoAluno = new Aluno(idAluno, nomeAluno);

            bool MatriculadoEmOutroCurso = false;
            foreach (Curso curso in minhaEscola.Cursos)
            {
                if (curso.Id == -1) continue;
                if (curso.Id == cursoAluno.Id) continue; // ignora o curso original

                foreach (Disciplina disc in curso.Disciplinas)
                {
                    if (disc.Id == -1) continue;

                    foreach (Aluno alu in disc.Alunos)
                    {
                        if (alu.Id == novoAluno.Id)
                        {
                            MatriculadoEmOutroCurso = true;
                            break;
                        }
                    }
                    if (MatriculadoEmOutroCurso) break;
                }
                if (MatriculadoEmOutroCurso) break;
            }
            if (MatriculadoEmOutroCurso){
                Console.WriteLine("Aluno já está matriculado em outro curso!\n");
                break;
            }
            if (novoAluno.podeMatricular(cursoAluno)){
                Console.WriteLine(disciplinaAluno.matricularAluno(novoAluno)
                    ? "Aluno matriculado com sucesso!\n"
                    : "Não foi possível matricular (já existe ou limite atingido)\n");
            }
            else
            {
                Console.WriteLine("Aluno não pode ser matriculado (curso lotado ou sem disciplinas disponíveis)\n");
            }
            break;

        case 8:
            Console.WriteLine("Cursos disponíveis:");
            foreach (var curso in minhaEscola.Cursos)
            {
                if (curso != null && curso.Id != -1)
                    Console.WriteLine($"{curso.Id} - {curso.Descricao}");
            }
            Console.WriteLine("\nDigite o ID do curso: ");
            if (!int.TryParse(Console.ReadLine(), out int idCursoDelAlu))
            {
                Console.WriteLine("ID inválido!\n");
                break;
            }
            Curso cursoDelAlu = minhaEscola.pesquisarCurso(new Curso(idCursoDelAlu));
            if (cursoDelAlu.Id == -1)
            {
                Console.WriteLine("Curso não encontrado!\n");
                break;
            }
            Console.WriteLine("Disciplinas disponíveis:");
            foreach (var disciplina in cursoDelAlu.Disciplinas)
            {
                if (disciplina != null && disciplina.Id != -1)
                    Console.WriteLine($"{disciplina.Id} - {disciplina.Descricao}");
            }
            Console.WriteLine("Digite o ID da disciplina: ");
            if (!int.TryParse(Console.ReadLine(), out int idDiscDelAlu))
            {
                Console.WriteLine("ID inválido!\n");
                break;
            }
            Disciplina descDelAlu = cursoDelAlu.pesquisarDisciplina(new Disciplina(idDiscDelAlu));
            if (descDelAlu.Id == -1)
            {
                Console.WriteLine("Disciplina não encontrada!\n");
                break;
            }
            Console.WriteLine("\nDigite o ID do aluno: ");
            if (!int.TryParse(Console.ReadLine(), out int idDelAluno))
            {
                Console.WriteLine("ID inválido!\n");
                break;
            }
            Console.WriteLine(descDelAlu.desmatricularAluno(new Aluno(idDelAluno))
                ? "Aluno removido da disciplina com sucesso!\n"
                : "Não foi possível remover o aluno (não existe ou não está matriculado)\n");
            break;

        case 9:
            Console.WriteLine("Digite o nome do aluno: ");
            string nomeBusca = Console.ReadLine();
            bool encontrado = false;

            foreach (Curso curso in minhaEscola.Cursos)
            {
                if (curso.Id == -1) continue;

                foreach (Disciplina disc in curso.Disciplinas)
                {
                    if (disc.Id == -1) continue;

                    foreach (Aluno alu in disc.Alunos)
                    {
                        if (alu.Id != -1 && alu.Nome.Equals(nomeBusca, StringComparison.OrdinalIgnoreCase))
                        {
                            if (!encontrado)
                            {
                                Console.WriteLine($"Aluno encontrado: {alu.Nome} (ID {alu.Id})");
                                Console.WriteLine("Disciplinas matriculadas:");
                                encontrado = true;
                            }
                            Console.WriteLine($"- {disc.Descricao} (Curso: {curso.Descricao})");
                        }
                    }
                }
            }

            if (!encontrado)
                Console.WriteLine("Aluno não encontrado!\n");
            break;

        default:
            Console.WriteLine("\nOcorreu um erro, verifique se digitou corretamente.\n");
            break;
    }
} while (opcao != 0);

