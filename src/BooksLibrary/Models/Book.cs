using System.Collections.Generic;
using Catel.Data;

namespace BooksLibrary.Models
{
    public class Book : ModelBase
    {
        public string Author
        {
            get { return GetValue<string>(AuthorProperty); }
            set { SetValue(AuthorProperty, value); }
        }
        public static readonly PropertyData AuthorProperty = RegisterProperty("Author", typeof(string), string.Empty);


        public string Title
        {
            get { return GetValue<string>(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly PropertyData TitleProperty = RegisterProperty("Title", typeof(string), string.Empty);


        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (string.IsNullOrEmpty(Author))
            {
                validationResults.Add(FieldValidationResult.CreateError(AuthorProperty, "Необходимо указать автора"));
            }

            if (string.IsNullOrEmpty(Title))
            {
                validationResults.Add(FieldValidationResult.CreateError(TitleProperty, "Необходимо указать название"));
            }
        }
    }
}
