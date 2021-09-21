using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Models.Entities
{
    public class Book : BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Isbn { get; set; }
        public bool IsHardCover { get; set; }
        public Guid? PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public Guid? CategoryId { get; set; }
        public BookCategory Category { get; set; }
        public DateTime PublicationDate { get; set; }
        public IList<Author> Authors { get; set; }
        //public IList<BookAuthor> BookAuthors { get; set; }

        public void Update(string title, string isbn, bool isHardCover, Guid? publisherId, Guid? bookCategoryId)
        {
            this.Title = title;
            this.Isbn = isbn;
            this.IsHardCover = isHardCover;
            this.PublisherId = publisherId == Guid.Empty ? null : publisherId;
            this.CategoryId =  bookCategoryId == Guid.Empty ? null: bookCategoryId;
        }
    }
}
