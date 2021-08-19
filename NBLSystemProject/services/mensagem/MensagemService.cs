using NBLSystemProject.pages.db;
using NBLSystemProject.pages.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBLSystemProject.services
{
    public interface MensagemService
    {
        public void Insert(Mensagem mensagem);

        public void Delete(int id);
    }
}
