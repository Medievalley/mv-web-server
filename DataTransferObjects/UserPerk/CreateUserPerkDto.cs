using FluentValidation;

namespace DataTransferObjects.UserPerkDTOs
{
    public class CreateUserPerkDTO
    {
        public string UserId { get; set; }
        public Guid PerkId { get; set; }
    }

    public class CreateUserPerkDTOValidator : AbstractValidator<CreateUserPerkDTO>
    {
        public CreateUserPerkDTOValidator()
        {
            RuleFor(x => x.UserId).NotEqual(string.Empty);
            RuleFor(x => x.PerkId).NotEqual(Guid.Empty);
        }
    }
}
