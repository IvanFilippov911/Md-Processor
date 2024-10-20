using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownProcessorLib.Models;

public class Block
{
    public BlockType Type { get; }
    public string Value { get; }
    
    public Block(string value, BlockType type)
    {
        Value = value;
        Type = type;
    }
}


public enum BlockType
{
    Text,
    Italic,
    Bold,
    Heading,
    Escape
}