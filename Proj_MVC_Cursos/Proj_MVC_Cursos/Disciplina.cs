using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_MVC_Cursos
{
    internal class Disciplina
    {
        private int id;
        private string descricao;
        private int max = 15;
        private int qtde = 0;
        private Aluno[] alunos;
        public Disciplina(int id, string descricao) 
        { 
            this.id = id;
            this.descricao = descricao;
            this.alunos = new Aluno[Max];
            for (int i = 0; i < Max; i++)
            {
                this.alunos[i] = new Aluno();
            }
        }
        public Disciplina() : this(-1,"")
        {
            this.alunos = new Aluno[Max];
            for (int i = 0; i < Max; i++)
            {
                this.alunos[i] = new Aluno();
            }
        }

        public Disciplina(int id) : this(id, "")
        {
            this.id = id;
            this.alunos = new Aluno[Max];
            for (int i = 0; i < Max; i++)
            {
                this.alunos[i] = new Aluno();
            }
        }
        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        internal Aluno[] Alunos { get => alunos; set => alunos = value; }
        public int Max { get => max; }
        public int Qtde { get => qtde; set => qtde = value; }

        public bool matricularAluno(Aluno aluno)
        {
            for (int i = 0; i < Qtde; i++)
            {
                if (Alunos[i].Id == aluno.Id)
                    return false;
            }

            if (Qtde >= Max)
                return false;

            Alunos[Qtde++] = aluno;
            return true;
        }
        public bool desmatricularAluno(Aluno aluno) 
        {
            for (int i = 0; i < Qtde; i++)
            {
                if (Alunos[i].Id == aluno.Id)
                {
                    for (int j = i; j < Qtde - 1; j++)
                        this.alunos[j] = this.alunos[j + 1];

                    this.alunos[this.Qtde - 1] = new Aluno();
                    this.qtde--;
                    return true;
                }
            }
            return false;
        }
        public override bool Equals(object obj)
        {
            return (this.Id == ((Disciplina)obj).Id);
        }
    }
}