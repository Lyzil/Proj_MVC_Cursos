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
        public int Qtde { get => qtde; set => qtde = value; }

        public bool adicionarDisciplina(Disciplina disciplina)
        {

            for (int i = 0; i < Qtde; i++)
            {
                if (Disciplinas[i].Id == disciplina.Id)
                    return false;
            }
            if (Qtde >= Max) return false;

            this.Disciplinas[qtde++] = disciplina; 
            return true;
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
            for (int i = 0; i < Qtde; i++)
            {
                if (Disciplinas[i].Id == disciplina.Id)
                {
                    if (Disciplinas[i].Qtde > 0) return false; 

                    for (int j = i; j < Qtde - 1; j++)
                        Disciplinas[j] = Disciplinas[j + 1];

                    Disciplinas[Qtde - 1] = new Disciplina();
                    Qtde--;
                    return true;
                }
            }
            return false;
        }
        public override bool Equals(object obj)
        {
            return (this.Id == ((Curso)obj).Id);
        }
    }
}
 