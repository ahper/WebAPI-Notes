using FluentValidation;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    public class GetNoteListQueryValidator : AbstractValidator<GetNoteListQuery>
    {
        public GetNoteListQueryValidator()
        {
            RuleFor(getNoteListQueryValidator =>
                getNoteListQueryValidator.UserId).NotEqual(Guid.Empty);
        }
    }
}
