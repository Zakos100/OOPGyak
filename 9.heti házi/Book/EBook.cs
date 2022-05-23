using System;
using System.Collections.Generic;
using System.Text;

namespace myproducts
{
    /*

	 */
    public class EBook : Book
    {
        public string url;
        public EBook(string author, string title, int pages, int price, string style, string url) :
            base(author, title, pages, price, style)
        {
            this.url = url;
        }

        public string GetUrl()
        {
            return this.url;
        }

        public void SetUrl(string value)
        {
            this.url = value;
        }

        public override string ToString()
        {
            return base.ToString() + " URL: " + this.url;
        }
    }
}
