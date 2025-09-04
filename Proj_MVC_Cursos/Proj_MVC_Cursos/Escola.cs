using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_MVC_Cursos
{
    internal class Escola
    {
        private int max = 5;
        private int qtde = 0;
        private Curso[] cursos;

        public Escola()
        {
            cursos = new Curso[Max];
            for (int i = 0; i < Max; i++)
            {
                this.cursos[i] = new Curso();
            }
        }

        public int Max { get => max; }
        public int Qtde { get => qtde; set => qtde = value; }
        internal Curso[] Cursos { get => cursos; set => cursos = value; }

        public bool adicionarCurso(Curso curso) 
        {
            foreach (Curso curs in this.cursos)
            {
                if (curs.Id != -1 && curs.Id == curso.Id)
                    return false;
            }
            bool podeAdicionar = (this.Qtde < this.Max);
            if (podeAdicionar)
                this.Cursos[Qtde++] = curso;
            return podeAdicionar;
        }
        public Curso pesquisarCurso(Curso curso)
        {
            Curso cursoAchado = new Curso();
            foreach (Curso curs in this.cursos)
            {
                if (curs.Equals(curso))
                {
                    cursoAchado = curs;
                    break;
                }
            }
            return cursoAchado;
        }
        public bool removerCurso(Curso curso)
        {
            Curso CursoParaRemover = pesquisarCurso(curso);
            if (CursoParaRemover.Id == -1)
                return false;
            foreach (Disciplina disc in CursoParaRemover.Disciplinas)
            {
                if (disc.Id != -1)
                {
                    return false;
                }
            }
            int i = 0;
            while (i < this.Max && this.cursos[i].Id != curso.Id)
            {
                i++;
            }
            for (int j = i; j < Max - 1; j++)
            {
                this.cursos[j] = this.cursos[j + 1];
            }
            this.cursos[this.Max - 1] = new Curso();
            this.Qtde--;

            return true;
        }
    }
}
