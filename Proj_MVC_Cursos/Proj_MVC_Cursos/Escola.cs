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
            for (int i = 0; i < Qtde; i++)
            {
                if (cursos[i].Id == curso.Id)
                {
                    // Se possuir disciplinas, não remove
                    if (cursos[i].Qtde > 0) return false;

                    for (int j = i; j < Qtde - 1; j++)
                        cursos[j] = cursos[j + 1];

                    cursos[Qtde - 1] = new Curso();
                    Qtde--;
                    return true;
                }
            }
            return false;
        }
    }
}
