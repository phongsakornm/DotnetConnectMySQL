using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetConnectMySQL.Models
{
    [Table("ms09_department")]
    public class DepartmentModel
    {
        [Column("depID")]
        public string departmentID { get; set; } = "";
        [Column("description_TH")]
        public string descriptionThai { get; set; } = "";
        [Column("description_EN")]
        public string descriptionEnglish { get; set; } = "";
        [Column("status")]
        public string status { get; set; } = "";
    }
}
