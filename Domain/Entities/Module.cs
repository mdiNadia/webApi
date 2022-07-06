using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Module
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Controller { get; set; }
        public DateTime CreateDate { get; set; }

        public int? ParentId { get; set; }
        public Module Parent { get; set; }

        public ICollection<Module> Children { get; set; }

    }
}
