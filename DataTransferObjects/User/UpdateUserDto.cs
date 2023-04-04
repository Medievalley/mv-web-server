using FluentValidation;

namespace DataTransferObjects.UserDTOs
{
    public class UpdateUserDTO
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Ip { get; set; }
    }

    public class UpdateUserDTOValidator : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserDTOValidator()
        {
            RuleFor(x => x.Login).NotEmpty().Length(4, 20);
            RuleFor(x => x.Id).NotEqual(string.Empty);
            RuleFor(x => x.Ip).Matches(@"^((25[0-5]|(2[0-4]|1\d|[1-9]|)\d)\.?\b){4}$");
        }
    }
}
