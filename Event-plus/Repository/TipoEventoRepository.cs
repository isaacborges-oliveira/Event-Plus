﻿using Eventplus_api_senai.Context;
using Eventplus_api_senai.Domais;
using Eventplus_api_senai.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Eventplus_api_senai.Repository
{
    public class TipoEventoRepository : ITipoEventoRepository
    { //Listar,Cadastrar,,Deletar,Atualizar,ListarPorId
        private readonly Event_Context _context;
        public TipoEventoRepository(Event_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                TipoEvento novotipoEvento = _context.TipoEvento.Find(id)!;
                if (novotipoEvento != null) {

                    novotipoEvento.TituloTipoEvento = tipoEvento.TituloTipoEvento;
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TipoEvento BuscarPorId(Guid id)
        {
            try
            {
                TipoEvento novotipoEvento = _context.TipoEvento.Find(id)!;
                return novotipoEvento;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastro(TipoEvento novoTipoEvento)
        {
            try
            {
                _context.TipoEvento.Add(novoTipoEvento);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                TipoEvento novotipoEvento = _context.TipoEvento.Find(id)!;
                if (novotipoEvento != null)
                { 
                _context.TipoEvento.Remove(novotipoEvento);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TipoEvento> Listar()
        {

            try
            {
                List<TipoEvento> ListaTipoEvento = _context.TipoEvento.ToList();
                return ListaTipoEvento;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
