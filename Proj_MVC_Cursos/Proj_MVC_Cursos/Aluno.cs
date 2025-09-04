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

        public bool podeMatricular(Curso cursos) 
        {

        }
    }
}
