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
        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        internal Aluno[] Alunos { get => alunos; set => alunos = value; }
        public int Max { get => max; }
        public int Qtde { get => qtde; set => qtde = value; }

        public bool matricularAluno(Aluno aluno)
        {
            foreach (Aluno alu in this.alunos)
            {
                if (alu.Id != -1 && alu.Id == aluno.Id)
                    return false;
            }
            bool podeAdicionar = (this.Qtde < this.Max);
            if (podeAdicionar)
                this.Alunos[Qtde++] = aluno;
            return podeAdicionar;
        }
        public bool desmatricularAluno(Aluno aluno) 
        {
            foreach (Aluno alu in this.alunos)
            {
                if (alu.Id != -1 && alu.Id == aluno.Id)
                {
                    int i = 0;
                    while (i < this.max && this.alunos[i].Id != aluno.Id)
                    {
                        i++;
                    }
                    for (int j = i; j < max - 1; j++)
                    {
                        this.alunos[j] = this.alunos[j + 1];
                    }
                    this.alunos[this.max - 1] = new Aluno();
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
