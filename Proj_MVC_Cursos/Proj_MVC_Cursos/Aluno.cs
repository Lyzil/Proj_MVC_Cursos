using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Proj_MVC_Cursos
{
    internal class Aluno
    {
        private int id;
        private string nome;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }

        public Aluno(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }
        public Aluno() : this(-1, ""){ }

        public Aluno(int id) : this(id, "") { this.id = id; }

        public bool podeMatricular(Curso cursos) 
        {
            int disciplinasMatriculadas = 0;

            foreach (Disciplina disc in cursos.Disciplinas)
            {
                if (disc.Id != -1)
                {
                    foreach (Aluno alu in disc.Alunos)
                    {
                        if (alu.Id == this.Id)
                            disciplinasMatriculadas++;
                    }
                }
            }
            if (disciplinasMatriculadas >= 6)
                return false;

            foreach (Disciplina disc in cursos.Disciplinas)
            {
                if (disc.Id != -1 && disc.Qtde < disc.Max)
                    return true;
            }
            return false;
        }
        public override bool Equals(object obj)
        {
            return (this.Id == ((Aluno)obj).Id);
        }
    }
}
