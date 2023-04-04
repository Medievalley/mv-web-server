using FluentValidation;

namespace DataTransferObjects.UserItemDTOs
{
    public class CreateUserItemDTO
    {
        public string UserId { get; set; }
        public Guid ItemId { get; set; }
    }

    public class CreateUserItemDTOValidator : AbstractValidator<CreateUserItemDTO>
    {
        public CreateUserItemDTOValidator()
        {
            RuleFor(x => x.UserId).NotEqual(string.Empty);
            RuleFor(x => x.ItemId).NotEqual(Guid.Empty);
        }
    }
}
