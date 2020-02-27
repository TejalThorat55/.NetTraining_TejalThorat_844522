namespace MVCCodeTRMProject
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public class DBModel : DbContext
    {
        // Your context has been configured to use a 'DBModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MVCCodeTRMProject.DBModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DBModel' 
        // connection string in the application configuration file.
        public DBModel()
            : base("name=DBModel")
        {

        }


        public virtual DbSet<LoginDetail> LoginDetails { get; set; }
        public virtual DbSet<RoleDetail> RoleDetails { get; set; }
        public virtual DbSet<RequestDetail> RequestDetails { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

    public class LoginDetail
    {
        [Key]
        public int UserId { get; set; }
      
        public string UserName { get; set; }
      
        public string Password { get; set; }
       
        public int RoleId { get; set; }
        
    }

    public class RoleDetail
    {
        [Key]
        public int RoleId { get; set; }
      
        public string RoleName { get; set; }
    }

    public class RequestDetail
    {
        [Key]
        public int RequestId { get; set; }
        
        public string RequestName { get; set; }
     
        public string Skill { get; set; }
       
        public DateTime StartDate { get; set; }
      
        public DateTime EndDate { get; set; }
       
        public string Status { get; set; }

        public int ExecId { get; set; }

        public int TrainerId { get; set; }
    }
}