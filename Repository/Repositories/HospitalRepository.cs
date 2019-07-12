using Model;
using Repository.DataBase;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class HospitalRepository : IHospitalRepository
    {
        public SistemaContext context;

        //Construtor
        public HospitalRepository()
        {
            // Instancia um objeto da classe sitema context que nos 
            // permite ter acessi as tabekas di babci de dadis
            context = new SistemaContext();
        }


        public bool Alterar(Hospital hospital)
        {
            Hospital hospitalOriginal = (from x in context.Hospitais
                                         where x.Id == hospital.Id
                                         select x).FirstOrDefault();
            if (hospitalOriginal == null)
            {
                return false;
            }

            hospitalOriginal.RazaoSocial = hospital.RazaoSocial;
            hospitalOriginal.Particular = hospital.Particular;
            hospitalOriginal.Faturamento = hospital.Faturamento;
            hospitalOriginal.Cnpj = hospital.Cnpj;
            context.SaveChanges();
            return true;
        }

        public bool Apagar(int id)
        {
            Hospital hospital = (
                // linq
                from hospitais in context.Hospitais
                where hospitais.Id == id
                select hospitais).FirstOrDefault();
            if (hospital == null)
            {
                return false;
            }

            hospital.RegistroAtivo = false;
            context.SaveChanges();
            return true;
        }

        public int Inserir(Hospital hospital)
        {
            hospital.dataCriacao = DateTime.Now;
            context.Hospitais.Add(hospital);
            context.SaveChanges();
            return hospital.Id;
        }

        public Hospital ObterPeloId(int id)
        {
            return (from hospital in context.Hospitais
                    where hospital.Id == id
                    select hospital).FirstOrDefault();
        }

        public List<Hospital> ObterTodos(string busca)
        {
            return (from hospital in context.Hospitais
                    where
                    hospital.RegistroAtivo == true &&
                    (hospital.RazaoSocial.Contains(busca) ||
                    hospital.Cnpj.Contains(busca))
                    orderby hospital.RazaoSocial
                    select hospital
                    ).ToList();
        }
    }
}
