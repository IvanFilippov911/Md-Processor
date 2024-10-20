using MarkdownProcessorLib.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownProcessorLib;

class Md
{
    public string Render(string text)
    {
        var blocks = new BlockSplitter().Split(text);
        var resultHtml = new HtmlBuilder().Build(blocks);

        return resultHtml;
    }
}
