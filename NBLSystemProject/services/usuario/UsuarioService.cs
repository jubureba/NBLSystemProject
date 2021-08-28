using NBLSystemProject.pages.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBLSystemProject.services.usuario
{
    interface UsuarioService
    {
        public void Insert(Funcionario usuario);

        public void Delete(int id);
    }
}
