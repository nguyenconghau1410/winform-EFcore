using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.models
{
    internal class Sympton
    {
        [Key]
        public String SymptonID { get; set; }

        public String Name { get; set; }
        [InverseProperty("Symptons")]
        public Disease Disease { get; set; }
    }
}
