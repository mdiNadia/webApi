using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Slider
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }
        public string DestinationLink1 { get; set; }
        public string DestinationLink2 { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
