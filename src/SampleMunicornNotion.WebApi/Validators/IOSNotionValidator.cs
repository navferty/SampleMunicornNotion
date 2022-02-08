using FluentValidation;

using SampleMunicornNotion.Models.IOS;

namespace SampleMunicornNotion.WebApi.Validators
{
	public class IOSNotionValidator : AbstractValidator<NewIOSNotionDto>
	{
		public IOSNotionValidator()
		{
			RuleFor(x => x.PushToken)
				.NotEmpty()
				.WithMessage($"Поле {nameof(NewIOSNotionDto.PushToken)} не должно быть пустым!")
				.MaximumLength(50)
				.WithMessage($"Поле {nameof(NewIOSNotionDto.PushToken)} не должно превышать допустимый размер!");

			RuleFor(x => x.Alert)
				.NotEmpty()
				.WithMessage($"Поле {nameof(NewIOSNotionDto.Alert)} не должно быть пустым!")
				.MaximumLength(2000)
				.WithMessage($"Поле {nameof(NewIOSNotionDto.Alert)} не должно превышать допустимый размер!");
		}
	}
}
