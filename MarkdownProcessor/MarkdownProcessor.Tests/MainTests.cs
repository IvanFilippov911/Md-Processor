using Xunit;
using MarkdownProcessorLib;

namespace MarkdownProcessor.Tests;
public class MarkdownProcessorTests
{
    [Fact]
    public void TestItalic()
    {
        
        var processor = new Md(); 

        string result = processor.Render("��� _������_ �����.");
       
        Assert.Equal("��� <em>������</em> �����.", result);
    }

    [Fact]
    public void TestBold()
    {
        var processor = new Md();

        string result = processor.Render("��� __����������__ �����.");

        Assert.Equal("��� <strong>����������</strong> �����.", result);
    }

    [Fact]
    public void TestEscapedUnderscore()
    {
        var processor = new Md();

        string result = processor.Render("��� \\_�� ������\\_.");

        Assert.Equal("��� _�� ������_.", result);
    }

    [Fact]
    public void TestNestedItalicInBold()
    {
        var processor = new Md();

        string result = processor.Render("��� __��������� _������_ �����__.");

        Assert.Equal("��� <strong>��������� <em>������</em> �����</strong>.", result);
    }

    
    [Fact]
    public void TestItalicWithDigits()
    {
        var processor = new Md();

        string result = processor.Render("��� _��_ ������ ���� ��������: �����_12_3.");

        Assert.Equal("��� <em>��</em> ������ ���� ��������: �����_12_3.", result);
    }

    [Fact]
    public void TestHeading()
    {
        var processor = new Md();

        string result = processor.Render("# ��� ���������");

        Assert.Equal("<h1>��� ���������</h1>", result);
    }

    [Fact]
    public void TestHeadingWithBoldAndItalic()
    {
        var processor = new Md();

        string result = processor.Render("# ��������� __� _�������_ ���������__");

        Assert.Equal("<h1>��������� <strong>� <em>�������</em> ���������</strong></h1>", result);
    }

    [Fact]
    public void TestEscapedCharactersRemain()
    {
        var processor = new Md();

        string result = processor.Render("����� ���\\���� �������������\\ \\������ ��������.\\");

        Assert.Equal("����� ���\\���� �������������\\ \\������ ��������.", result);
    }

    [Fact]
    public void TestEscapedBackslash()
    {
        var processor = new Md();

        string result = processor.Render("\\\\_��� ��� ����� �������� �����_");

        Assert.Equal("<em>��� ��� ����� �������� �����</em>", result);
    }

    [Fact]
    public void TestBoldInsideItalicDoesNotWork()
    {
        var processor = new Md();

        string result = processor.Render("_��������� __�������__ ��_ ��������.");

        Assert.Equal("<em>��������� __�������__ ��</em> ��������.", result);
    }

    [Fact]
    public void TestNoItalicBetweenDifferentWords()
    {
        var processor = new Md();

        string result = processor.Render("��������� � ��_���� ��_���� �� ��������.");

        Assert.Equal("��������� � ��_���� ��_���� �� ��������.", result);
    }

    [Fact]
    public void TestUnpairedUnderscoreNoEffect()
    {
        var processor = new Md();

        string result = processor.Render("__��������_ ������� �� ��������� ����������.");

        Assert.Equal("__��������_ ������� �� ��������� ����������.", result);
    }

    [Fact]
    public void TestUnderscoreShouldHaveNonSpaceCharacterBeforeOpening()
    {
        var processor = new Md();

        string result = processor.Render("���_ ��������_ �� ��������� ����������.");

        Assert.Equal("���_ ��������_ �� ��������� ����������.", result);
    }

    [Fact]
    public void TestUnderscoreShouldHaveNonSpaceCharacterAfterClosing()
    {
        var processor = new Md();

        string result = processor.Render("��� _�������� _�� ��������� ���������� ���������.");

        Assert.Equal("��� _�������� _�� ��������� ���������� ���������.", result);
    }

    [Fact]
    public void TestIntersectionOfBoldAndItalicIsIgnored()
    {
        var processor = new Md();

        string result = processor.Render("__����������� _�������__ � ���������_ ��������� �� ��������� ����������.");

        Assert.Equal("__����������� _�������__ � ���������_ ��������� �� ��������� ����������.", result);
    }

    [Fact]
    public void TestEmptyStringInsideUnderscores()
    {
        var processor = new Md();

        string result = processor.Render("���� ������ ��������� ������ ������ ____, �� ��� �������� ��������� ��������.");

        Assert.Equal("���� ������ ��������� ������ ������ ____, �� ��� �������� ��������� ��������.", result);
    }

    [Fact]
    public void TestItalicInBeginningMiddleEnd()
    {
        var processor = new Md();

        string result = processor.Render("� � _���_���, � ���_���_�� � � ���_��_.");

        Assert.Equal("� � <em>���</em>���, � ���<em>���</em>�� � � ���<em>��</em>.", result);
    }

    [Fact]
    public void TestEmphasisWithSingleUnderscore()
    {

        var processor = new Md();

        string result = processor.Render("_������ __��������_");

        Assert.Equal("<em>������ __��������</em>", result);
    }

    [Fact]
    public void TestEmphasisWithDoubleUnderscore()
    {

        var processor = new Md();

        string result = processor.Render("__������ _��������__");

        Assert.Equal("<strong>������ _��������</strong>", result);
    }





}
