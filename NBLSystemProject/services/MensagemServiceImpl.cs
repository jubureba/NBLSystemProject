using NBLSystemProject.pages.db;
using NBLSystemProject.pages.entity;
using NBLSystemProject.repository.entityframework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBLSystemProject.services
{
    public class MensagemServiceImpl : MensagemService
    {
        public void Insert(Mensagem mensagem)
        {
            var msg = new BasicCrud<Mensagem>();
            msg.Insert(mensagem);
            msg.SaveChanges();
        }

        public void Delete(int id)
        {
            var msg = new BasicCrud<Mensagem>();
            Mensagem mensagem = msg.Find(m => m.id == id).SingleOrDefault();
            msg.Delete(mensagem);
            msg.SaveChanges();
        }
    }
}
