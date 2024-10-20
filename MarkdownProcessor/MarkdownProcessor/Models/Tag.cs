using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownProcessorLib.Models;

public class Tag
{
    private string tagType;
    private string content;

    public Tag(string tagType, string content)
    {
        this.tagType = tagType;
        this.content = content;
    }

    public string Create()
    {
        return $"<{tagType}>{content}<{tagType}>";
    }
}
