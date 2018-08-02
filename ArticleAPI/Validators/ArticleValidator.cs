using DataLayer.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleAPI.Validators
{
    public class ArticleValidator
        : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(art => art.Author).NotNull().NotEmpty().WithSeverity(Severity.Warning).WithMessage("Article author should not be null or empty.");
            RuleFor(art => art.Body).NotEmpty().NotNull().WithSeverity(Severity.Error).WithMessage("Article body is empty or null. Please provide a body.");
            RuleFor(art => art.Category).NotNull().WithSeverity(Severity.Error).WithMessage("Article has no category. Please provide a category ID.");
            RuleFor(art => art.Title).NotEmpty().NotNull().WithSeverity(Severity.Warning).WithMessage("Article has no title.");
            RuleFor(art => art.PublicationDate).NotEqual(default(DateTime)).WithSeverity(Severity.Warning).WithMessage("Publication date has not been set by the end user and will be defaulted by the system.");
            RuleFor(art => art.ID).NotEqual(default(Guid)).WithSeverity(Severity.Warning).WithMessage("GUID has not been set by the end user and will be defaulted by the system.");
        }
    }
}
