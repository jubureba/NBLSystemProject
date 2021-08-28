using NBLSystemProject.pages.entity;
using NBLSystemProject.repository.entityframework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBLSystemProject.services.usuario
{
    class UsuarioServiceImpl : UsuarioService
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Funcionario usuario)
        {
            var user = new BasicCrud<Funcionario>();
            user.Insert(usuario);
            user.SaveChanges();
        }
    }
}
