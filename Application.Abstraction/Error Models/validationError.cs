using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Error_Models
{

    public class validationError
    {
        public string Field { get; set; } = default!;
        public IEnumerable<String> Errors { get; set; } = [];
    }
}
