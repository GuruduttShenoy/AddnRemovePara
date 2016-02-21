using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AddnRemovePara.Models
{
    /// <summary>
    /// This class creates mapping for the between the database tables tblPara,tblParaLeft and tblParaRight nd our model class
    /// </summary>
    public class ParaDAL:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Maps the Table tblPara to our Model class 'Para'
            modelBuilder.Entity<Para>().ToTable("tblPara");

            //Maps the Table tblParaLeft to our Model class 'ParaLeft'
            modelBuilder.Entity<ParaLeft>().ToTable("tblParaLeft");

            //Maps the Table tblParaRight to our Model class 'ParaRight'
            modelBuilder.Entity<ParaRight>().ToTable("tblParaRight");
        }

        //Creates DBset object of the model class Para so that we can do CRUD operations on it
        public DbSet<Para> ParaObj { get; set; }

        //Creates DBset object of the model class ParaLeft so that we can do CRUD operations on it
        public DbSet<ParaLeft> ParaLeftObj { get; set; }

        //Creates DBset object of the model class ParaLeft so that we can do CRUD operations on it
        public DbSet<ParaRight> ParaRightObj { get; set; }


    }
}