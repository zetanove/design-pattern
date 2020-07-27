namespace Visitor
{
    public interface DocumentVisitor
    {
        void VisitPlainText(PlainText part);
        void VisitHyperlink(Hyperlink part);
        void VisitImage(EmbeddedImage part);
        void VisitTitle(Title part);
        void VisitNote(Note note);
    }

}
