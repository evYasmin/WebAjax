using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    interface IHospitalRepository
    {
        List<Hospital> ObterTodos(string busca);

        int Inserir(Hospital hospital);

        bool Alterar(Hospital hospital);

        Hospital ObterPeloId(int id);

        bool Apagar(int id);

    }
}
