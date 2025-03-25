﻿using Eventplus_api_senai.Context;
using Eventplus_api_senai.Domais;
using Eventplus_api_senai.Interfaces;

namespace Eventplus_api_senai.Repository
{

    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly Event_Context _context;
        public TipoUsuarioRepository(Event_Context context)
        {
            _context = context;
        }

        public void Cadastro(TipoUsuario novoTipoUsuario)
        {
            try
            {
                _context.TipoUsuario.Add(novoTipoUsuario);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TipoUsuario> Listar()
        {
            try
            {
                List<TipoUsuario> ListaTipoUsuario = _context.TipoUsuario.ToList();
                return ListaTipoUsuario;
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
                TipoUsuario novoTipoUsuario = _context.TipoUsuario.Find(id)!;
                if (novoTipoUsuario != null) {
                _context.TipoUsuario.Remove(novoTipoUsuario);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            try
            {
                TipoUsuario novoTipoUsuario = _context.TipoUsuario.Find(id)!;
                if (novoTipoUsuario != null) {
                    novoTipoUsuario.TituloTipoUsuario = tipoUsuario.TituloTipoUsuario;
                
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            try
            {
                TipoUsuario novoTipoUsuario = _context.TipoUsuario.Find(id)!;
                return novoTipoUsuario;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
