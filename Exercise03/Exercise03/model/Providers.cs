using System;
namespace Exercise03.model
{
    class Providers
    {
        private int id;
        private string name;
        private string description;
        private DateTime createdDate;
        private int userId;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public int UserId { get => userId; set => userId = value; }

        public Providers()
        {

        }
        public Providers(int id, string name, string description, DateTime createdDate, int userId)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.createdDate = createdDate;
            this.userId = userId;
          
        }
        public Providers(string name, string description,int userId)
        {
            this.name = name;
            this.description = description;
            this.userId = userId;
        }
        public override string ToString()
        {
            return "ID: "+id+",NAME: "+name+",DESCRIPTION: "+description+",CREATED DATE: "+createdDate+",USER ID: "+userId+"]";
        }
    }
}
