using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PustokAP205.Models
{
    public class Feature
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Icon { get; set; }
        public bool IsDeleted { get; set; }
    }
}
