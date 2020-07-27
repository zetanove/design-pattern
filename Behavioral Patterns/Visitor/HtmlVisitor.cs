namespace Visitor
{
    public class HtmlVisitor : DocumentVisitor
    {
        public string Html { get;set;}

        public void VisitPlainText(PlainText part)
        {
            Html += "<span>"+ part.Text+"</span>";
        }

        public void VisitHyperlink(Hyperlink part)
        {
            Html +=  "<a href='"+part.Url+"'>"+part.Text+"</a>";
        }

        public void VisitImage(EmbeddedImage part)
        {
            Html += "<img alt='"+part.Text+"' src='" + part.UrlImage + "'></img>";
        }

        public void VisitNote(Note part)
        {
            Html += part.Text;
        }

        

        public void VisitTitle(Title part)
        {
            Html += "<h1>"+ part.Text+"</h1>";
        }
    }

}
