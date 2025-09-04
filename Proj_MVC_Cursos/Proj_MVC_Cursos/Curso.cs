using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_MVC_Cursos
{
    internal class Curso
    {
        private int id;
        private int max = 12;
        private int qtde = 0;
        private string descricao;
        private Disciplina[] disciplinas;

        public Curso(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
            this.disciplinas = new Disciplina[max];
            for (int i = 0; i < max; i++)
            {
                this.disciplinas[i] = new Disciplina();
            }
        }
        public Curso(int id) : this(id, "")
        {
            this.id = id;
            this.disciplinas = new Disciplina[max];
            for (int i = 0; i < max; i++)
            {
                this.disciplinas[i] = new Disciplina();
            }
        }
        public Curso() : this(-1, "")
        {
            this.disciplinas = new Disciplina[max];
            for (int i = 0; i < max; i++)
            {
                this.disciplinas[i] = new Disciplina();
            }
        }
        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        internal Disciplina[] Disciplinas { get => disciplinas; set => disciplinas = value; }
        public int Max { get => max; }
        public int Qtde { get => qtde; }

        public bool adicionarDisciplina(Disciplina disciplina)
        {

            foreach (Disciplina disc in this.disciplinas)
            {
                if (disc.Id != -1 && disc.Id == disciplina.Id)
                    return false;
            }
            bool podeAdicionar = (this.qtde < this.max);
            if (podeAdicionar)
                this.Disciplinas[qtde++] = disciplina; 
            return podeAdicionar;
        }
        public Disciplina pesquisarDisciplina(Disciplina disciplina)
        {
            Disciplina disciplinaAchada = new Disciplina();
            foreach (Disciplina disc in this.disciplinas){
                if (disc.Equals(disciplina)){
                    disciplinaAchada = disc;
                    break;
                }
            }
            return disciplinaAchada;
        }

        public bool removerDisciplina(Disciplina disciplina) 
        {
            Disciplina disciplinaParaRemover = pesquisarDisciplina(disciplina);
            if (disciplinaParaRemover.Id == -1)
                return false;
            foreach (Aluno aluno in disciplinaParaRemover.Alunos)
            {
                if (aluno.Id != -1)
                {
                    return false;
                }
            }
            int i = 0;
            while(i < this.max && this.disciplinas[i].Id != disciplina.Id)
            {
                i++;
            }
            for (int j = i; j < max - 1; j++)
            {
                this.disciplinas[j] = this.disciplinas[j+1];
            }
            this.disciplinas[this.max - 1] = new Disciplina();
            this.qtde--;

            return true;
        }
    }
}
 