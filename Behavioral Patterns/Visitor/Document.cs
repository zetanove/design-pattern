using System.Collections.Generic;

namespace Visitor
{
    public class Document
    {
        public List<DocumentPart> Parts;

        public Document()
        {
            Parts = new List<DocumentPart>();
        }

        public void Accept(DocumentVisitor visitor)
        {
            foreach (DocumentPart part in this.Parts)
            {
                part.Accept(visitor);
            }
        }
    }

}
