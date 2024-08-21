using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTestTask.Models
{
    public class AccountClass
    {
        [Key]
        public int Id { get; set; }

        public int ClassIndex { get; set; }

        public string? ClassName {  get; set; }

        [ForeignKey(nameof(OriginFile))]
        public int OriginFileId { get; set; }

        public OriginFile? OriginFile { get; set; }
    }
}
