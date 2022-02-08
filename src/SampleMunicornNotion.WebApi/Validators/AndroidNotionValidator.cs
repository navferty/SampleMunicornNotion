using FluentValidation;

using SampleMunicornNotion.Models.Android;

namespace SampleMunicornNotion.WebApi.Validators
{
	public class AndroidNotionValidator : AbstractValidator<NewAndroidNotionDto>
	{
		public AndroidNotionValidator()
		{
			RuleFor(x => x.DeviceToken)
				.NotEmpty()
				.WithMessage($"Поле {nameof(NewAndroidNotionDto.DeviceToken)} не должно быть пустым!")
				.MaximumLength(50)
				.WithMessage($"Поле {nameof(NewAndroidNotionDto.DeviceToken)} не должно превышать допустимый размер!");

			RuleFor(x => x.Message)
				.NotEmpty()
				.WithMessage($"Поле {nameof(NewAndroidNotionDto.Message)} не должно быть пустым!")
				.MaximumLength(2000)
				.WithMessage($"Поле {nameof(NewAndroidNotionDto.Message)} не должно превышать допустимый размер!");

			RuleFor(x => x.Title)
				.NotEmpty()
				.WithMessage($"Поле {nameof(NewAndroidNotionDto.Title)} не должно быть пустым!")
				.MaximumLength(255)
				.WithMessage($"Поле {nameof(NewAndroidNotionDto.Title)} не должно превышать допустимый размер!");

			RuleFor(x => x.Condition)
				.NotEmpty()
				.WithMessage($"Поле {nameof(NewAndroidNotionDto.Condition)} не должно быть пустым!")
				.MaximumLength(2000)
				.WithMessage($"Поле {nameof(NewAndroidNotionDto.Condition)} не должно превышать допустимый размер!");
		}
	}
}
