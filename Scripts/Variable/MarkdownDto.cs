using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatusTool.Scripts.Variable {
    public sealed class MarkdownDto {
        public required List<MarkdownItemDto> MarkdownItemDtoList { get; set; }
    }

    public class MarkdownItemDto { 
        public required string Directory { get; set; }
        public required string Description { get; set; }
    }
}
