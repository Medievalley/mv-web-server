using FluentValidation;
using System;

namespace DataTransferObjects.UserDTOs
{
    public class CreateUserDTO
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Ip { get; set; }
    }

    public class CreateUserDTOValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUserDTOValidator()
        {
            RuleFor(x => x.Login).NotEmpty().Length(4,20);
            RuleFor(x => x.Id).NotEqual(string.Empty);
            RuleFor(x => x.Ip).Matches(@"^((25[0-5]|(2[0-4]|1\d|[1-9]|)\d)\.?\b){4}$");
        }
    }
}
