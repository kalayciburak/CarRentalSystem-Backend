using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation {
    public class CarValidatior : AbstractValidator<Car> {
        public CarValidatior() {
            // RuleFor(c=>c.Description).NotEmpty();
            // RuleFor(c=>c.ModelYear).NotEmpty();
            // RuleFor(c => c.DailyPrice).GreaterThan(0);
        }
    }
}