using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.DAL.Entities
{
    public class ModelBase
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }//Soft-Deleted (ex: display all have IsDeleted with false) not temporary 
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } //the Date of Recored Creation in Database
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set;}
    }
}
