using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03.model
{
    class Users
    {
        private int id;
        private string userName;
        private string pswd;
        private string fullName;

        public int Id { get => id; set => id = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Pswd { get => pswd; set => pswd = value; }
        public string FullName { get => fullName; set => fullName = value; }

        public Users()
        {

        }
        public Users(int id, string userName, string pswd, string fullName)
        {
            this.id = id;
            this.userName = userName;
            this.pswd = pswd;
            this.fullName = fullName;
        }

        public override string ToString()
        {
            return "USERS [ID: "+id+",USERNAME: "+userName+",PSWD: "+pswd+",FULLNAME: "+fullName+"]";
        }

    }
}
