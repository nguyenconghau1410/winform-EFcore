using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.models
{
    internal class Disease
    {
        public Disease()
        {
            this.Symptons = new HashSet<Sympton>();
        }
        [Key]
        public String DiseaseID { get; set; }
        public String Name { get; set; }
        [InverseProperty("Disease")]
        public virtual ICollection<Sympton> Symptons { get; set; }
    }
}
