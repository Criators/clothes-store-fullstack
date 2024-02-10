using Clothes.Store.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Domain.Entities
{
    public class Custumer
    {
        public Custumer() 
        {
            IsActivate = true;
            CriationDateHour = DateTime.Now;
        }

        public Guid CustumerID { get; set; }

        public string CustumerName { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public string Password { get; set; }

        public DateTime CriationDateHour { get; set; }

        public TypeUser? TypeUser { get; set; }

        public bool IsActivate { get; set; }

        public void Update(string custumerName, string email, string cpf, string password, TypeUser? typeUser)
        {
            CustumerName = custumerName;
            Email = email;
            CPF = cpf;
            Password = password;
            TypeUser = typeUser;
        }

        public void Delete()
        {
            this.IsActivate = false;
        }
    }
}
