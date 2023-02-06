using Softtek.Models;
using System.ComponentModel.DataAnnotations;

namespace Softtek.Constans
{
    public class UserConstans
    {
        public static List<UserModel> Users = new List<UserModel>() {

           new UserModel() { Username = "Elmer",      Password = "Pass123", EmailAddress="elmer.espinoza@gmail.com",   FirstName="Elmer",      LastName="Espinoza",  Rol = "Administrador"  },
           new UserModel() { Username = "Maricarmen", Password = "Pass123", EmailAddress="maricarmen.gomez@gmail.com", FirstName="Maricarmen", LastName="Gomez",     Rol = "Ventas"  },
           new UserModel() { Username = "Muriel",     Password = "Pass123", EmailAddress="muriel.elguera@gmail.com",   FirstName="Muriel",     LastName="Elguera",   Rol = "Logistica"  }
        };

    }
}
