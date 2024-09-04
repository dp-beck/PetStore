using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace PetStore.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name).NotEmpty();
            RuleFor(product => product.Price).GreaterThanOrEqualTo(0);
            RuleFor(product => product.Quantity).GreaterThanOrEqualTo(0);
            When(product => String.IsNullOrEmpty(product.Description), () => {
                RuleFor(product => product.Description).MinimumLength(10);
            }) ;

        }
        
    }
}