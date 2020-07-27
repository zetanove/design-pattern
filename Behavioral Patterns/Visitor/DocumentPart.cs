namespace Visitor
{
    public abstract class DocumentPart
    {
        public string Text { get; set; }

        public abstract void Accept(DocumentVisitor visitor);
    }

    public class Title : DocumentPart
    {
        public override void Accept(DocumentVisitor visitor)
        {
            visitor.VisitTitle(this);
        }
    }

    public class Note : DocumentPart
    {
        public override void Accept(DocumentVisitor visitor)
        {
            visitor.VisitNote(this);
        }
    }

    public class PlainText : DocumentPart
    {
        public override void Accept(DocumentVisitor visitor)
        {
            visitor.VisitPlainText(this);
        }
    }

    public class EmbeddedImage : DocumentPart
    {
        public string UrlImage { get;  set; }

        public override void Accept(DocumentVisitor visitor)
        {
            visitor.VisitImage(this);
        }
    }

    public class Hyperlink : DocumentPart
    {
        public string Url { get; set; }

        public override void Accept(DocumentVisitor visitor)
        {
            visitor.VisitHyperlink(this);
        }
    }
}
